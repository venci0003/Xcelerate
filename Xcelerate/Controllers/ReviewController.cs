using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Review;
using Xcelerate.Extension;
using static Xcelerate.Common.ApplicationConstants;


namespace Xcelerate.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IReviewService _reviewService;
		private readonly IMemoryCache _memoryCache;

		public ReviewController(IReviewService reviewServiceContext, IMemoryCache _memoryCacheContext)
		{
			_reviewService = reviewServiceContext;
			_memoryCache = _memoryCacheContext;
		}

		[HttpPost]
		public async Task<IActionResult> Add(ReviewViewModel reviewViewModel, int adId)
		{
			Guid userId = User.GetUserId();

			await _reviewService.CreateReviewAsync(reviewViewModel, userId.ToString(), adId);

			string carReviewsCacheKey = $"{CarReviewsCacheKey}_{adId}";

			_memoryCache.Remove(carReviewsCacheKey);

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

			string carReviewsCacheKey = $"{CarReviewsCacheKey}_{adId}";

			_memoryCache.Remove(carReviewsCacheKey);

			return RedirectToAction("Information", "Ad", new { adId = adId });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int reviewId, int adId)
		{
			TempData["ConfirmDelete"] = true;
			TempData["ReviewAdIdToDelete"] = reviewId;
			TempData["AdId"] = adId;
			return RedirectToAction("Information", "Ad", new { adId = adId });
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int reviewId, int? adId)
		{
			await _reviewService.DeleteReviewAsync(reviewId);
			TempData["DeleteMessage"] = true;

			string carReviewsCacheKey = $"{CarReviewsCacheKey}_{adId}";

			_memoryCache.Remove(carReviewsCacheKey);

			return RedirectToAction("Information", "Ad", new { adId = adId });
		}
	}
}
