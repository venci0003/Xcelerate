namespace Xcelerate.Controllers
{
	using Core.Contracts;
	using Core.Models.Review;
	using Extension;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using static Common.ApplicationConstants;

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

			_memoryCache.Remove(AdminReviewsCacheKey);

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

			_memoryCache.Remove(AdminReviewsCacheKey);

			return RedirectToAction("Information", "Ad", new { adId = adId });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int reviewId, int? adId)
		{
			await _reviewService.DeleteReviewAsync(reviewId);

			TempData["DeleteMessage"] = "Review deleted successfully.";

			string carReviewsCacheKey = $"{CarReviewsCacheKey}_{adId}";

			_memoryCache.Remove(carReviewsCacheKey);

			return Json(new { success = true });
		}
	}
}
