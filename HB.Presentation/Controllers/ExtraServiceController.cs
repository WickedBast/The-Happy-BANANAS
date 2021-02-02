using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Entity.Application;
using HB.Presentation.Code;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HB.Presentation.Controllers
{
	public class ExtraServiceConroller : BaseController
	{
		private readonly IReservationRepository reservationRepo;
		private readonly IRoomRepository roomRepo;
		private readonly IUserRepository userRepo;
		private readonly IExtraServiceRepository extraServiceRepo;

		public ExtraServiceConroller(
			IReservationRepository reservationRepo,
			IUserRepository userRepo,
			IRoomRepository roomRepo,
			IExtraServiceRepository extraServiceRepo)
		{
			this.reservationRepo = reservationRepo;
			this.userRepo = userRepo;
			this.roomRepo = roomRepo;
			this.extraServiceRepo = extraServiceRepo;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> ExtraService(IFormCollection frm)
		{
			var serviceType = frm["txtServiceType"];
			var numberOfPerson = frm["txtNumberOfPerson"];
			var date = frm["txtDate"];
			var time = frm["txtTime"];
			var pnrNo = frm["txtPnrNo"];
			var quota = -1;

			var reservation = reservationRepo.FirstOrDefaultBy(x => x.PNRNumber == pnrNo);

			var dateConverted = DateTime.Parse(date);
			var today = DateTime.Today;
			int result = DateTime.Compare(dateConverted, today);

			if (
				string.IsNullOrWhiteSpace(serviceType) ||
				string.IsNullOrWhiteSpace(numberOfPerson) ||
				string.IsNullOrWhiteSpace(date) ||
				string.IsNullOrWhiteSpace(time) ||
				string.IsNullOrWhiteSpace(pnrNo)
				)
			{
				TempData["Info"] = "Lütfen bütün alanları doldurun.";
				return RedirectToAction("Index", "ExtraService");
			}
			else if (result < 0)
			{
				TempData["Info"] = "Geçmiş tarih seçemezsiniz.";
				return RedirectToAction("Index", "ExtraService");
			}
			else if (reservation == null)
			{
				TempData["Info"] = "PNR numaranız rezarvasyonunzla eşleşmemektedir.";
				return RedirectToAction("Index", "ExtraService");
			}
			else
			{
				extraServiceRepo.Add(new ExtraService
				{
					ServiceType = serviceType,
					NumberOfPerson = Int32.Parse(numberOfPerson),
					Date = DateTime.Parse(date),
					Hour = time,
					PNRNumber = pnrNo,
					UserID = CurrentUserID,

				});
				TempData["Info"] = "Ödeme sayfasına yönlendiriliyorsunuz.";
				return RedirectToAction("Index", "Payment");
			}

		}
	}
}
