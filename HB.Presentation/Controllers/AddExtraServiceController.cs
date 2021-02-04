using HB.Core.Extensions;
using HB.Entity.Application;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HB.Presentation.Controllers
{
	[Authorize]
	public class AddExtraServiceController : Controller
	{
		private readonly IExtraServiceRepository extraServiceRepo;

		public AddExtraServiceController(
			IExtraServiceRepository extraServiceRepo)
		{
			this.extraServiceRepo = extraServiceRepo;
		}
		public IActionResult Index()
		{
			return View();
		}
		[Authorize]
		public async Task<IActionResult> AddExtraService(IFormCollection frm)
		{
			var serviceType = frm["txtServiceType"];
			var numberOfPerson = frm["txtNumberOfPerson"];
			var prize = frm["txtPrize"];
			var quota = frm["txtQuota"];

			if (string.IsNullOrWhiteSpace(serviceType) ||
				 string.IsNullOrWhiteSpace(numberOfPerson) ||
				 string.IsNullOrWhiteSpace(prize) ||
				 string.IsNullOrWhiteSpace(quota))
			{
				TempData["Info"] = "Lütfen bütün alanları doldurun.";
				return RedirectToAction("Index", "RoomAdd");
			}
			else
			{
				extraServiceRepo.Add(new ExtraService
				{
					ServiceType = serviceType,
					NumberOfPerson = Int32.Parse(numberOfPerson),
					Cost = Int32.Parse(prize),
					Quota = Int32.Parse(quota)

				});
				TempData["Info"] = "Ekstra servis kayıt işleminiz gerçekleştirilmiştir.";
				return RedirectToAction("Index", "ExtraServiceAdd");
			}
		}
	}
}
