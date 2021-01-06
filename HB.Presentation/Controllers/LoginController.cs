using HB.Core.Security;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HB.Presentation.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserRepository userRepo;

		public LoginController(IUserRepository userRepo)
		{
			this.userRepo = userRepo;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(IFormCollection frm)
		{
			var Email = frm["txtEmail"];
			var Password = new Cryptography().EncryptString(frm["txtPassword"]);

			var user = userRepo.FirstOrDefaultBy(x => x.Email == Email && x.Password == Password);
			if (user != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Email),
					new Claim("Email", user.Email),
					new Claim("Name", user.Name),
					new Claim("Id", user.Id.ToString()),
					new Claim("Surname", user.Surname.ToString())
				};

				var userIdentity = new ClaimsIdentity(claims, "login");

				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				TempData["Info"] = "Email ya da şifrenizi yanlış girdiniz";
				return RedirectToAction("Index", "Login");
			}
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
