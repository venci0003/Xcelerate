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
		public async Task<IActionResult> Add(ReviewViewModel reviewViewModel, int adId , int carId)
		{
			Guid userId = User.GetUserId();

			await _reviewService.CreateReviewAsync(reviewViewModel, userId.ToString(), adId);

			return RedirectToAction("Information", "Ad", new { carId = carId, adId = adId });

		}

		[HttpPost]
		public async Task<IActionResult> Delete(int reviewId, int adId , int carId)
		{
			await _reviewService.DeleteReviewAsync(reviewId);

			return RedirectToAction("Information", "Ad", new { carId = carId, adId = adId });

		}
	}
}
