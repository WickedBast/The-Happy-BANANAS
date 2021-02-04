using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Entity.Application;
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
		public readonly IReservationRepository reservationRepo;

		public CommentController(
			IUserRepository userRepo,
			ICommentRepository commentRepo,
			IReservationRepository reservationRepo)
		{
			this.userRepo = userRepo;
			this.commentRepo = commentRepo;
			this.reservationRepo = reservationRepo;
		}

		public IActionResult Index()
		{
			var result = new CommentVM();

			var query = commentRepo.GetBy(x => true);

			result.Items = query.OrderByDescending(x => x.CreateDate).Take(100).Select(x => new CommentMM
			{
				Id = x.Id,
				PNRNumber = x.PNRNumber,
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
			var pnrNo = frm["txtPNRNumber"].ToString();
			var comment = frm["txtComment"];
			var rateGiven = frm["starRate"];			

			var user = userRepo.FirstOrDefaultBy(x => x.Id == Id);

			var res = reservationRepo.FirstOrDefaultBy(x => x.Id == Id);

			var pnr = reservationRepo.FirstOrDefaultBy(x => x.PNRNumber == pnrNo);

			if (!(User.Identity.IsAuthenticated))
            {
				TempData["Info"] = "Yorum yapabilmek için giriş yapmalısınız..";
				return RedirectToAction("Index", "Comment");
			}

			else if (string.IsNullOrWhiteSpace(comment))
			{
				TempData["Info"] = "Lütfen yorum yapacağınız alanı boş bırakmayın";
				return RedirectToAction("Index", "Comment");
			}
			//else if (string.IsNullOrWhiteSpace(rateGiven))
			//{
			//	TempData["Info"] = "Lütfen puanlama yapınız ";
			//	return RedirectToAction("Index", "Comment");
			//}

			else if(pnr != null)
			{
				commentRepo.Add(new Comment
				{
					ReservationID = res.Id,
					PNRNumber = pnrNo,
					CommentText = comment,
					RateGiven = decimal.Parse(rateGiven) / (10),
					UserID = CurrentUserID,
					FullName = CurrentUserName + " " + CurrentUserLastName
				});

				TempData["Info"] = "Yorum işleminiz başarıyla sonuçlanmıştır.";
				return RedirectToAction("Index", "Comment");
            }
            else
            {
				TempData["Info"] = "Hatalı işlem yaptınız.";
				return RedirectToAction("Index", "Comment");
			}
		}
	}
}
