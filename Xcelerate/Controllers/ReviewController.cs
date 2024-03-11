using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.Review;
using Xcelerate.Core.Services;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;

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
		public async Task<IActionResult> Add(ReviewViewModel reviewViewModel, int adId, int carId)
		{
			Guid userId = User.GetUserId();

			await _reviewService.CreateReviewAsync(reviewViewModel, userId.ToString(), adId);

			return RedirectToAction("Information", "Ad", new { carId = carId, adId = adId });

		}

		[HttpGet]
		public async Task<IActionResult> Edit(int? reviewId , int carId)
		{
			if (reviewId == null)
			{
				return NotFound();
			}

			EditReviewViewModel editInformation = await _reviewService.GetEditInformationAsync(reviewId.Value, carId);

			return View(editInformation);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Edit(EditReviewViewModel reviewViewModel, int adId, int carId)
		{
			await _reviewService.EditReviewAsync(reviewViewModel);

			return RedirectToAction("Information", "Ad", new { carId = carId, adId = adId });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int reviewId, int adId, int carId)
		{
			await _reviewService.DeleteReviewAsync(reviewId);

			return RedirectToAction("Information", "Ad", new { carId = carId, adId = adId });

		}
	}
}
