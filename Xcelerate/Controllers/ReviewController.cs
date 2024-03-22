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
		public async Task<IActionResult> Add(ReviewViewModel reviewViewModel, int adId)
		{
			Guid userId = User.GetUserId();

			await _reviewService.CreateReviewAsync(reviewViewModel, userId.ToString(), adId);

			return RedirectToAction("Information", "Ad", new { adId = adId });

		}

		[HttpGet]
		public async Task<IActionResult> Edit(int? reviewId)
		{
			if (reviewId == null)
			{
				return NotFound();
			}

			EditReviewViewModel editInformation = await _reviewService.GetEditInformationAsync(reviewId.Value);

			return View(editInformation);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditReviewViewModel reviewViewModel, int adId)
		{
			await _reviewService.EditReviewAsync(reviewViewModel);

			return RedirectToAction("Information", "Ad", new { adId = adId });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int reviewId, int adId)
		{
			await _reviewService.DeleteReviewAsync(reviewId);

			return RedirectToAction("Information", "Ad", new { adId = adId });

		}
	}
}
