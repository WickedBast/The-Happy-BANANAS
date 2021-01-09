using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Presentation.Code;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HB.Presentation.Controllers
{
	public class CommentController : BaseController
	{
		public readonly IUserRepository userRepo;
		public readonly ICommentRepository commentRepo;

		public CommentController(
			IUserRepository userRepo,
			ICommentRepository commentRepo)
		{
			this.userRepo = userRepo;
			this.commentRepo = commentRepo;
		}

		public IActionResult Index()
		{
			var comment = commentRepo.GetAll();
			return View(comment);
		}

		[HttpPost]
		public IActionResult Comment(IFormCollection frm, Guid Id)
		{
			var comment = frm["txtComment"];
			var rateGiven = frm["rate"];
			var roomType = frm["roomtype"];

			var user = userRepo.FirstOrDefaultBy(x => x.Id == Id);

			if (string.IsNullOrWhiteSpace(comment))
			{
				TempData["Info"] = "Lütfen yorum yapacağınız alanı boş bırakmayın";
				return RedirectToAction("Index", "Comment");
			}
			else
			{
				commentRepo.Add(new Entity.Application.Comment
				{
					CommentText = comment,
					RateGiven = decimal.Parse(rateGiven) / (10),
					UserID = CurrentUserID,
					FullName = CurrentUserName + " " + CurrentUserLastName,
				});

				TempData["Info"] = "Yorum işleminiz başarıyla sonuçlanmıştır.";
				return RedirectToAction("Index", "Comment");
			}
		}
	}
}
