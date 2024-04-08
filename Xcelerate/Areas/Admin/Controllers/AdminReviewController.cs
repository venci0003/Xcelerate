using Microsoft.AspNetCore.Mvc;
using Xcelerate.Areas.Admin.Contracts;

namespace Xcelerate.Areas.Admin.Controllers
{
    public class AdminReviewController : BaseAdminController
	{
		private readonly IAdminReviewService _adminReviewService;

		public AdminReviewController(IAdminReviewService reviewServiceContext)
		{
			_adminReviewService = reviewServiceContext;
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
