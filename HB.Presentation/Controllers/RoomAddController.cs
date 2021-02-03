using HB.Core.Extensions;
using HB.Entity.Application;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> AddAsync(IFormCollection frm, List<IFormFile> Images)
        {
            var RoomName = frm["txtRoomName"];
            var RoomType = frm["txtRoomType"];
            var RoomNumber = frm["txtRoomNumber"].ToString();
            var MaxPerson = frm["txtPersonCapacity"];
            var Price = frm["txtPrice"];

            var ImageList = new List<RoomImage>();

            if (Images != null && Images.Any())
            {
                foreach (var Image in Images)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    string Extension = Path.GetExtension(fileName).ToLower();
                    string NewFileName = Guid.NewGuid().ToString();
                    if (Extension == ".jpg" || Extension == ".png" || Extension == ".jfif")
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName + Extension);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(fileSteam);
                        }

                        ImageList.Add(new RoomImage
                        {
                            Image = NewFileName + Extension,
                        });
                    }
                }
            }

            if (
               string.IsNullOrWhiteSpace(RoomName)||
               string.IsNullOrWhiteSpace(RoomType) ||
               string.IsNullOrWhiteSpace(RoomNumber) ||
               string.IsNullOrWhiteSpace(MaxPerson) ||
               string.IsNullOrWhiteSpace(Price)
               )
            {
                TempData["Info"] = "Lütfen bütün alanları doldurun.";
                return RedirectToAction("Index", "RoomAdd");
            }
            else if (roomRepo.Any(x => x.RoomNumber == RoomNumber))
            {
                TempData["Info"] = RoomNumber + " numaralı oda daha önce eklenmiştir.";
                return RedirectToAction("Index", "RoomAdd");
            }

            roomRepo.Add(new Room
            {
                Name = RoomName.ToString(),
                Type = RoomType.ToString(),
                RoomNumber = RoomNumber.ToString(),
                PersonCapacity = Int32.Parse(MaxPerson),
                Price = Int32.Parse(Price),
                Slug = RoomName.ToString().ToUrlSlug(),
                RoomImages = ImageList
            });

            TempData["Info"] = "Oda kayıt işleminiz gerçekleştirilmiştir.";
            return RedirectToAction("Index", "RoomAdd");
        }
    }
}
