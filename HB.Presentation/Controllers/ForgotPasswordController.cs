using HB.Core.Security;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HB.Core.Extensions;

namespace HB.Presentation.Controllers
{
	public class ForgotPasswordController : Controller
	{

		private readonly IUserRepository userRepo;

		public ForgotPasswordController(IUserRepository userRepo)
		{
			this.userRepo = userRepo;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ForgotPassword(IFormCollection frm)
		{
			var Email = frm["txtEmail"];

			if (string.IsNullOrEmpty(Email))
			{
				TempData["Info"] = "Lütfen bütün alanları doldurun.";
				return RedirectToAction("Index", "ForgotPassword");
			}
			else if (!Email.ToString().IsValidEmailAddress())
			{
				TempData["Info"] = "Lütfen geçerli bir e-posta adresi girin.";
				return RedirectToAction("Index", "ForgotPassword");
			}
			else
			{
				//TODO: SEND MAIL 
			}

		}

	}
}
