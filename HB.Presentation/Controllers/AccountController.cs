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

namespace HB.Presentation.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IUserRepository userRepo;

		public AccountController(IUserRepository userRepo)
		{
			this.userRepo = userRepo;
		}
		public IActionResult Index()
		{
			var user = userRepo.GetById(CurrentUserID);
			return View(user);
		}

		[HttpPost]
		public IActionResult Update(IFormCollection frm)
		{
			var PhnNo = frm["txtPhnNo"];
			var PasswordP = frm["txtPasswordP"];
			var Password = frm["txtPassword"];
			var PasswordRetry = frm["txtPasswordR"];

			string pass = userRepo.GetById(CurrentUserID).Password;

			PasswordP = new Cryptography().EncryptString(frm["txtPasswordP"]);
			var need = new Cryptography().EncryptString(frm["txtPassword"]);

			if (
				string.IsNullOrWhiteSpace(PasswordP) ||
				string.IsNullOrWhiteSpace(Password) ||
				string.IsNullOrWhiteSpace(PasswordRetry)
				)
			{
				TempData["Info"] = "Lütfen bütün alanları doldurun.";
				return RedirectToAction("Index", "Account");
			}
			else if (PasswordP != pass)
			{
				TempData["Info"] = "Güncel şifrenizi doğru girmediniz.";
				return RedirectToAction("Index", "Account");
			}
			else if (PasswordP == need)
			{
				TempData["Info"] = "Güncel şifreniz yeni şifrenizle aynı olmamalıdır.";
				return RedirectToAction("Index", "Account");
			}
			else if (Password.ToString().Length < 6)
			{
				TempData["Info"] = "Hesap şifreniz minimum 6 karakterden oluşmalıdır.";
				return RedirectToAction("Index", "Account");
			}
			else if (Password.ToString().Length > 16)
			{
				TempData["Info"] = "Hesap şifreniz maksimum 16 karakterden oluşmalıdır.";
				return RedirectToAction("Index", "Account");
			}
			else if (Password != PasswordRetry)
			{
				TempData["Info"] = "Girmiş olduğunuz şifreler birbiri ile uyuşmamaktadır.";
				return RedirectToAction("Index", "Account");
			}

			Password = new Cryptography().EncryptString(frm["txtPassword"]);

			var user = userRepo.FirstOrDefaultBy(x => x.Id == CurrentUserID);
			user.Password = Password;

			if (string.IsNullOrWhiteSpace(PhnNo))
			{
				userRepo.Update(user);
			}
			else
			{
				user.PhoneNumber = PhnNo;
				userRepo.Update(user);
			}

			TempData["Info"] = "Bilgileriniz başarılı bir şekilde değiştirilmiştir.";
			return RedirectToAction("Index", "Account");
		}
	}
}
