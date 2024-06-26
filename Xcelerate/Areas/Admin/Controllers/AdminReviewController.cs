﻿namespace Xcelerate.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using Areas.Admin.Contracts;
	using static Common.ApplicationConstants;
	using static Common.NotificationMessages.AlertMessages;

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
		public async Task<IActionResult> Delete(int reviewId)
		{
			await _adminReviewService.DeleteReviewAsync(reviewId);

			TempData[DeleteAdminReviewTempData] = DeleteAdminReviewMessage;

			_memoryCache.Remove(AdminReviewsCacheKey);

			return Json(new { success = true });
		}
	}
}
