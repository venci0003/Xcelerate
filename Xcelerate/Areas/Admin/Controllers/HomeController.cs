using Microsoft.AspNetCore.Mvc;
using Xcelerate.Areas.Admin.Contracts;
using Xcelerate.Areas.Admin.Models;
using Xcelerate.Core.Models.Pager;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Areas.Admin.Controllers
{
	public class HomeController : BaseAdminController
	{
		private readonly IAdminReviewService _adminReviewService;
		private readonly IAdminNewsService _adminNewsService;

		public HomeController(IAdminReviewService adminReviewServiceContext, IAdminNewsService _adminNewsServiceContext)
		{
			_adminNewsService = _adminNewsServiceContext;
			_adminReviewService = adminReviewServiceContext;
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


			var viewModel = await _adminNewsService.GetHomePageDataAsync(adminHomeView);

			adminHomeView.NewsPreview = viewModel.NewsPreview;

			//return View(homePageView);
			var reviewsToCheck = await _adminReviewService.GetUserReviewsForCheckAsync();

			adminHomeView.Reviews = reviewsToCheck;

			return View(adminHomeView);
		}
	}
}
