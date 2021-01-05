using HB.Core.Extensions;
using HB.Core.Security;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HB.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserRepository userRepo;

        public RegisterController(
            IUserRepository userRepo
            )
        {
            this.userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(IFormCollection frm)
        {
            var FirstName = frm["txtFirstName"];
            var LastName = frm["txtLastName"];
            var Email = frm["txtEmail"];
            var PhnNo = frm["txtPhnNo"];
            var Password = frm["txtPassword"];
            var PasswordRetry = frm["txtPasswordRetry"];

            if (
                string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(PasswordRetry)
                )
            {
                TempData["Info"] = "Lütfen bütün alanları doldurun.";
                return RedirectToAction("Index", "Register");
            }
            else if (!Email.ToString().IsValidEmailAddress())
            {
                TempData["Info"] = "Lütfen geçerli bir e-posta adresi girin.";
                return RedirectToAction("Index", "Register");
            }
            else if (userRepo.Any(x => x.Email == Email))
            {
                TempData["Info"] = "Bu e-posta adresi başka bir kullanıcı tarafından kullanılmaktadır.";
                return RedirectToAction("Index", "Register");
            }
            else if (Password.ToString().Length < 6)
            {
                TempData["Info"] = "Hesap şifreniz minimum 6 karakterden oluşmalıdır.";
                return RedirectToAction("Index", "Register");
            }
            else if (Password != PasswordRetry)
            {
                TempData["Info"] = "Girmiş olduğunuz şifreler birbiri ile uyuşmamaktadır.";
                return RedirectToAction("Index", "Register");
            }

            Password = new Cryptography().EncryptString(frm["txtPassword"]);

            userRepo.Add(new Entity.Application.User
            {
                Name = FirstName,
                Surname = LastName,
                Email = Email,
                PhoneNumber = PhnNo,
                Role = Core.Enum.Enums.Role.User,
                Password = Password
            });

            //TODO: Doğrulama e-postası gönderilecek.
            TempData["Info"] = "Kayıt işleminiz gerçekleştirilmiştir.";
            return RedirectToAction("Index", "Register");
        }

    }
}