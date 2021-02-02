using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Presentation.Models.Reservation;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Mvc;

namespace HB.Presentation.Controllers
{
	public class HistoryController : Controller
	{
		public readonly IReservationRepository reservationRepo;
		public readonly IRoomImageRepository imageRepo;

		public HistoryController(
			IReservationRepository reservationRepo,
			IRoomImageRepository imageRepo)
        {
			this.reservationRepo = reservationRepo;
			this.imageRepo = imageRepo;
        }
		public IActionResult Index()
		{
			var result = new ReservationVM();

			var query = reservationRepo.GetBy(x => true);

			result.Items = query.OrderByDescending(x => x.CreateDate).Take(10).Select(x => new ReservationMM
			{
				Id = x.Id,
				Cost = x.Cost,
				RoomCount = x.RoomCount,
				StartDate = x.StartDate,
				NumberOfPerson = x.NumberOfPerson,
				Night = x.Night,
				Type = x.Room.Type,
				CreateDate = x.CreateDate.Value,

			}).ToList();

			return View(result);
		}
	}
}
