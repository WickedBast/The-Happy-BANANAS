using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Presentation.Models.Room;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Mvc;

namespace HB.Presentation.Controllers
{
	public class RoomDetailController : Controller
	{
		public readonly IRoomRepository roomRepo;
		public readonly IRoomImageRepository roomImageRepo;

		public RoomDetailController(
			IRoomRepository roomRepo,
			IRoomImageRepository roomImageRepo)
        {
			this.roomRepo = roomRepo;
			this.roomImageRepo = roomImageRepo;
        }
		public IActionResult Index()
		{
			var result = new RoomVM();

			var query = roomRepo.GetBy(x => true);

			result.Item = query.OrderByDescending(x => x.CreateDate).Take(10).Select(x => new RoomMM 
			{
				Id = x.Id,
				CreateDate = x.CreateDate,
				PersonCapacity = x.PersonCapacity,
				Cost = x.Price,
				Type = x.Type,

			}).ToList();

			return View(result);
		}
	}
}
