namespace Xcelerate.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using Contracts;
	using Models;
	using Core.Models.Pager;
	using static Common.ApplicationConstants;
	public class HomeController : BaseAdminController
	{
		private readonly IAdminReviewService _adminReviewService;
		private readonly IAdminNewsService _adminNewsService;
		private readonly IMemoryCache _memoryCache;

		public HomeController(IAdminReviewService adminReviewServiceContext, IAdminNewsService _adminNewsServiceContext, IMemoryCache _memoryCacheContext)
		{
			_adminNewsService = _adminNewsServiceContext;
			_adminReviewService = adminReviewServiceContext;
			_memoryCache = _memoryCacheContext;
		}
		[HttpGet]
		public async Task<IActionResult> Index(AdminHomeViewModel adminHomeView)
		{
			if (adminHomeView.CurrentPage < 1)
			{
				adminHomeView.CurrentPage = 1;
			}

			Pager pager = new Pager(await _adminNewsService.GetNewsCountAsync(), adminHomeView.CurrentPage, DefaultPageSizeForNews);
			adminHomeView.Pager = pager;

			AdminHomeViewModel viewModel = _memoryCache.Get<AdminHomeViewModel>(AdminNewsCacheKey);

			if (viewModel == null)
			{

				viewModel = await _adminNewsService.GetHomePageDataAsync(adminHomeView);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminNewsExpirationFromMinutes));

				_memoryCache.Set(AdminNewsCacheKey, viewModel, cacheOptions);
			}

			adminHomeView.NewsPreview = viewModel.NewsPreview;

			List<AdminReviewViewModel> reviewsToCheck = _memoryCache.Get<List<AdminReviewViewModel>>(AdminReviewsCacheKey);

			if (reviewsToCheck == null || reviewsToCheck.Any() == false)
			{
				reviewsToCheck = await _adminReviewService.GetUserReviewsForCheckAsync();

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminReviewsExpirationFromMinutes));

				_memoryCache.Set(AdminReviewsCacheKey, reviewsToCheck, cacheOptions);
			}


			adminHomeView.Reviews = reviewsToCheck;

			return View(adminHomeView);
		}
	}
}
