using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Review;
using Xcelerate.Extension;

namespace Xcelerate.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IReviewService _reviewService;

		public ReviewController(IReviewService reviewServiceContext)
		{
			_reviewService = reviewServiceContext;
		}

		[HttpPost]
		public async Task<IActionResult> Add(ReviewViewModel reviewViewModel)
		{
			Guid userId = User.GetUserId();

			await _reviewService.CreateReviewAsync(reviewViewModel, userId.ToString());

			return RedirectToAction("Information", "Ad");
		}
	}
}
