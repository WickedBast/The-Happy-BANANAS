using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Presentation.Code;
using HB.Presentation.Models.Comment;
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
			var result = new CommentVM();

			var query = commentRepo.GetBy(x => true);

			result.Items = query.OrderByDescending(x => x.CreateDate).Take(100).Select(x => new CommentMM
			{
				Id = x.Id,
				ReservationID = x.ReservationID,
				RateAVG = x.RateGiven,
				CreateDate = x.CreateDate.Value,
				Explanation = x.CommentText,
				Room = new RoomMM
                {
					Type = x.Room.Type
                },
				User = new UserMM
                {
					Id = x.UserID,
					Name = x.User.Name,
					Surname = x.User.Surname
                }


			}).ToList();

			return View(result);
		}

		[HttpPost]
		public IActionResult Comment(IFormCollection frm, Guid Id)
		{
			var resID = frm["txtReservationID"];
			var comment = frm["txtComment"];
			var rateGiven = frm["starRate"];
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
					ReservationID = Guid.Parse(resID),
					CommentText = comment,
					RateGiven = decimal.Parse(rateGiven) / (10),
					UserID = CurrentUserID,
					FullName = CurrentUserName + " " + CurrentUserLastName
				});

				TempData["Info"] = "Yorum işleminiz başarıyla sonuçlanmıştır.";
				return RedirectToAction("Index", "Comment");
			}
		}
	}
}
