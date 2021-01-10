using HB.Core.Security;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HB.Core.Extensions;
using MimeKit;
using MailKit.Net.Smtp;

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
		public async Task<IActionResult> Forgot(IFormCollection frm)
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
				var user = userRepo.FirstOrDefaultBy(x => x.Email == Email);
				if (user != null)
				{
					var claims = new List<Claim>
					{
						new Claim("Email", user.Email)
					};

					var newPassword = new Cryptography().GenerateKey(8, false);
					user.Password = newPassword;
					userRepo.Update(user);						
						
					var message = new MimeMessage();
					message.From.Add(new MailboxAddress("New Password", "alpnce@gmail.com"));
					message.To.Add(new MailboxAddress(user.Name, user.Email));
					message.Subject = "Temporary Password";
					message.Body = new TextPart("plain")
					{
						Text = "Tekrar giriş yapabilmeniz için geçici şifreniz: " + user.Password
					};
					using (var client = new SmtpClient())
					{
						client.Connect("smtp.gmail.com", 587, false);
						client.Authenticate("hotelstar43@gmail.com", "happyBananas");
						client.Send(message);
						client.Disconnect(true);
					}
					
				}
			}
			TempData["Info"] = "Mailiniz gönderilmiştir.";
			return RedirectToAction("Index", "Login");

		}

	}
}
