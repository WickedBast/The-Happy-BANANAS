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

namespace HB.Presentation.Controllers
{
	public class ReservationController : BaseController
	{
		private readonly IUserRepository userRepo;
		private readonly IReservationRepository reservationRepo;
		private readonly IRoomRepository roomRepo;

		public ReservationController(
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

		[Authorize]
		public async Task<IActionResult> Reservation(IFormCollection frm)
		{
			var startDate = frm["txtStartDate"];
			var endDate = frm["txtEndDate"];
			var numberOfPerson = frm["txtNumberOfPerson"];
			var roomCount = frm["txtRoomCount"];
			var room = frm["txtRoom"];

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

			//else if ()
			//{

			//}
			else
			{
				reservationRepo.Add(new Reservation
				{
					StartDate = DateTime.Parse(startDate),
					EndDate = DateTime.Parse(endDate),
					NumberOfPerson = Int32.Parse(numberOfPerson),
					RoomCount = Int32.Parse(roomCount),
					Room =
					UserID = CurrentUserID
				});
			}
			TempData["Info"] = "Ödeme sayfasına yönlendiriliyorsunuz";
			return RedirectToAction("Index", "Payment");
		}

	}
}
