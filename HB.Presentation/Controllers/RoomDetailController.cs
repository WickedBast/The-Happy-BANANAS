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
		public IActionResult Index(string Slug)
		{
			var result = new RoomVM();

			var query = roomRepo.GetBy(x => true);

			var room = roomRepo.FirstOrDefaultBy(x => x.Slug == Slug);

			//Guid Id = room.Id;

			//var images = roomImageRepo.GetBy(x => x.RoomID == Id).Select(x => x.Image).ToList();

			result.Item = query.OrderByDescending(x => x.CreateDate).Take(10).Select(x => new RoomMM 
			{
				Id = x.Id,
				CreateDate = x.CreateDate,
				PersonCapacity = x.PersonCapacity,
				Cost = x.Price,
				Type = x.Type,
				//RoomImage = images

			}).ToList();

			return View(result);
		}
	}
}
