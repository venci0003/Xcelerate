using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Xcelerate.Areas.Admin.Contracts;

namespace Xcelerate.Areas.Admin.Controllers
{
	public class AdminReviewController : BaseAdminController
	{
		private readonly IAdminReviewService _adminReviewService;
		private readonly IMemoryCache _memoryCache;

		public AdminReviewController(IAdminReviewService reviewServiceContext, IMemoryCache _memoryCacheContext)
		{
			_adminReviewService = reviewServiceContext;
			_memoryCache = _memoryCacheContext;
		}

		[HttpPost]
		public IActionResult Delete(int reviewId, int adId)
		{
			TempData["ConfirmDelete"] = true;
			TempData["ReviewAdIdToDelete"] = reviewId;
			TempData["AdId"] = adId;
			return RedirectToAction("Index", "Home", new { Area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int reviewId)
		{
			await _adminReviewService.DeleteReviewAsync(reviewId);
			TempData["DeleteMessage"] = true;

			return RedirectToAction("Index", "Home", new { Area = "Admin" });
		}
	}
}
