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
using HB.Presentation.Models.Reservation;
using HB.Presentation.Models.SearchRoom;

namespace HB.Presentation.Controllers
{
	public class ReservationController : BaseController
	{
		private readonly IUserRepository userRepo;
		private readonly IReservationRepository reservationRepo;
		private readonly IRoomRepository roomRepo;
		private readonly IRoomImageRepository imageRepository;

		public ReservationController(
			IUserRepository userRepo,
			IReservationRepository reservationRepo,
			IRoomRepository roomRepo,
			IRoomImageRepository roomImageRepository
			)
		{
			this.userRepo = userRepo;
			this.reservationRepo = reservationRepo;
			this.roomRepo = roomRepo;
			this.imageRepository = roomImageRepository;
		}
		public IActionResult Index()
		{
			return View();
		}

		//public IActionResult SearchResult(SearchRoomVM vm)
  //      {
		//	if(vm.DateFrom == null || vm.DateTo == null)
  //          {
		//		return View();
		//	}

		//	var roomsBooked = from b in _context.Reservation
		//					  where
		//							((vm.DateFrom >= b.DateFrom) && (vm.DateFrom <= b.DateTo)) ||
		//							((vm.DateTo >= b.DateFrom) && (vm.DateTo <= b.DateTo)) ||
		//							((vm.DateFrom <= b.DateFrom) && (vm.DateTo >= b.DateFrom) && (vm.DateTo <= b.DateTo)) ||
		//							((vm.DateFrom >= b.DateFrom) && (vm.DateFrom <= b.DateTo) && (vm.DateTo >= b.DateTo)) ||
		//							((vm.DateFrom <= b.DateFrom) && (vm.DateTo >= b.DateTo))
		//					  select b;

		//	var availableRooms = _context.Rooms.Where(r => !roomsBooked.Any(b => b.RoomId == r.Id)).Include(x => x.Type).ToList();

		//	foreach (var item in availableRooms)
		//	{
		//		if ((item.MaxPeople >= vm.NoOfPerson))
		//		{
		//			vm.NoOfRooms.Add(item);
		//		}
		//	}
		//	return View(vm);
		//}

		public IActionResult Detail(string Slug)
        {
			var result = new ReservationDetailVM();

			var reservation = reservationRepo.FirstOrDefaultBy(x => x.Slug == Slug);

			Guid Id = reservation.Id;

			var images = imageRepository.GetBy(x => x.RoomID == Id).Select(x => x.Image).ToList();
			//var type= ;
			//var noPerson = ;
			//var price = ;
			//var name = ;

			result.Item = new ReservationDetailMM
			{
				Id = reservation.Id,
				CreateDate = reservation.CreateDate.Value,
				Images = images,
				Slug = reservation.Slug
			};

			return View(result);
        }

        [Authorize]
        public IActionResult Reservation(IFormCollection frm)
        {
            var startDate = frm["txtStartDate"];
            var endDate = frm["txtEndDate"];
            var numberOfPerson = frm["txtNoPerson"];
            var roomCount = frm["txtRoom"];
            var room = frm["txtRoomType"];

            var SdateConverted = DateTime.Parse(startDate);
            var EdateConverted = DateTime.Parse(endDate);
            var today = DateTime.Today;
            int resultSE = DateTime.Compare(SdateConverted, EdateConverted);
            int resultST = DateTime.Compare(SdateConverted, today);

            if (
                string.IsNullOrWhiteSpace(startDate) ||
                string.IsNullOrWhiteSpace(endDate) ||
                string.IsNullOrWhiteSpace(numberOfPerson) ||
                string.IsNullOrWhiteSpace(roomCount) ||
                string.IsNullOrWhiteSpace(room)
                )
            {
                TempData["Info"] = "Lütfen bütün alanları doldurun.";
                return RedirectToAction("Index", "Reservation");
            }

            else if (resultSE < 0)
            {
                TempData["Info"] = "Çıkış tarihiniz giriş tarihinizden önce olamaz.";
                return RedirectToAction("Index", "Reservation");
            }
            else if (resultSE == 0)
            {
                TempData["Info"] = "Giriş tarihinizle çıkış tarihiniz aynı olamaz.";
                return RedirectToAction("Index", "Reservation");
            }
            else if (resultST < 0)
            {
                TempData["Info"] = "Giriş tarihiniz bugünden önce olamaz.";
                return RedirectToAction("Index", "Reservation");
            }
            else
            {
                var PNRCode = new Cryptography().GenerateKey(6, true);

                reservationRepo.Add(new Reservation
                {
                    StartDate = DateTime.Parse(startDate),
                    EndDate = DateTime.Parse(endDate),
                    NumberOfPerson = Int32.Parse(numberOfPerson),
                    RoomCount = Int32.Parse(roomCount),
                    //Room = ,
                    UserID = CurrentUserID,
                    PNRNumber = PNRCode
                });
            }
            TempData["Info"] = "Ödeme sayfasına yönlendiriliyorsunuz";
            return RedirectToAction("Index", "Payment");
        }

        public IActionResult Cancel(IFormCollection frm, Reservation res)
        {
            reservationRepo.Delete(res);
            TempData["Info"] = "Rezervasyonunuz başarıyla silindi.";
            return RedirectToAction("Index", "History");
        }

    }
}
