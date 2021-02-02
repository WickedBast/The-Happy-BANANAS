using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Presentation.Controllers
{
    public class RoomAddController : Controller
    {

        private readonly IRoomRepository roomRepo;

        public RoomAddController(
            IRoomRepository roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormCollection frm)
        {
            var RoomType = frm["txtRoomType"];
            var RoomNumber = frm["txtRoomNumber"];
            var MaxPerson = frm["txtPersonCapacity"];
            var Price = frm["txtPrice"];

            if (
               string.IsNullOrWhiteSpace(RoomType) ||
               string.IsNullOrWhiteSpace(RoomNumber) ||
               string.IsNullOrWhiteSpace(MaxPerson) ||
               string.IsNullOrWhiteSpace(Price)
               )
            {
                TempData["Info"] = "Lütfen bütün alanları doldurun.";
                return RedirectToAction("Index", "RoomAdd");
            }
            //else if (RoomNumber)
            //{

            //}

            roomRepo.Add(new Entity.Application.Room
            {
                Type = RoomType.ToString(),
                RoomNumber = RoomNumber.ToString(),
                PersonCapacity = Int32.Parse(MaxPerson) ,
                Price = Int32.Parse(Price)
            });

            TempData["Info"] = "Oda kayıt işleminiz gerçekleştirilmiştir.";
            return RedirectToAction("Index", "RoomAdd");
        }
    }
}
