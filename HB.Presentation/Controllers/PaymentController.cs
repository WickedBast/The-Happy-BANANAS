using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HB.Core.Extensions;
using HB.Core.Security;
using HB.Presentation.Code;
using Microsoft.AspNetCore.Authorization;
using HB.Entity.Application;
using MimeKit;
using MailKit.Net.Smtp;

namespace HB.Presentation.Controllers
{
	public class PaymentController : BaseController
	{
		private readonly IUserRepository userRepo;
		private readonly IReservationRepository reservationRepo;
		private readonly IRoomRepository roomRepo;

		public PaymentController(
			IUserRepository userRepo,
			IReservationRepository reservationRepo,
			IRoomRepository roomRepo
			)
		{
			this.userRepo = userRepo;
			this.reservationRepo = reservationRepo;
			this.roomRepo = roomRepo;
		}
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Payment(IFormCollection frm)
        {
            var fullname = frm["txtFullName"];
            var email = frm["txtEmail"].ToString();
            var address = frm["txtAddress"];
            var city = frm["txtCity"];
            var zip = frm["txtZip"];
            var state = frm["txtState"];

            var name = frm["txtCardname"];
            var cardNo = frm["txtCardnumber"];
            var expMonth = frm["txtExpmonth"];
            var cvv = frm["txtCVV"];
            var expYear = frm["txtExpyear"];
            var expYear2 = Int32.Parse(expYear);

            var reservation = reservationRepo.FirstOrDefaultBy(x => x.Id == CurrentUserID);
            var total = reservation.Room.Price;

            if (
                string.IsNullOrWhiteSpace(fullname) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(zip) ||
                string.IsNullOrWhiteSpace(state) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(cardNo) ||
                string.IsNullOrWhiteSpace(expMonth) ||
                string.IsNullOrWhiteSpace(cvv) ||
                string.IsNullOrWhiteSpace(expYear)
                )
            {
                TempData["Info"] = "Lütfen bütün alanları doldurun.";
                return RedirectToAction("Index", "Payment");
            }
            else if (!email.ToString().IsValidEmailAddress())
            {
                TempData["Info"] = "Lütfen geçerli bir e-posta adresi girin.";
                return RedirectToAction("Index", "Payment");
            }
            else if (expYear2 <= 2021)
            {
                TempData["Info"] = "Kartınızın son geçerlilik tarihi dolmuştur.";
                return RedirectToAction("Index", "Payment");
            }
            else
            {
                //var PNRCode = new Cryptography().GenerateKey(6, true);
                var PNRCode = reservation.PNRNumber;
                var user = userRepo.FirstOrDefaultBy(x => x.Id == CurrentUserID);
                reservation.IsPaid = true;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PNRNumber", "alpnce@gmail.com"));
                message.To.Add(new MailboxAddress(user.Name, user.Email));
                message.Subject = "PNR Number:";
                message.Body = new TextPart("plain")
                {
                    Text = "Rezervasyonunuz alınmıştır. Rezervasyonunuz için PNR Numaranız:  " + reservation.PNRNumber
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("hotelstar43@gmail.com", "happyBananas");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            TempData["Info"] = "Satın alım işleminiz gerçekleştirilmiştir.";
            return RedirectToAction("Index", "Home");

        }
    }
}
