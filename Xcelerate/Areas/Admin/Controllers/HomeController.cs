using Microsoft.AspNetCore.Mvc;
using Xcelerate.Areas.Admin.Contracts;
using Xcelerate.Areas.Admin.Models;

namespace Xcelerate.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
	{
		private readonly IAdminReviewService _adminReviewService;

		public HomeController(IAdminReviewService adminReviewServiceContext)
		{
			_adminReviewService = adminReviewServiceContext;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var reviewsToCheck = await _adminReviewService.GetUserReviewsForCheckAsync();

			var viewModel = new AdminHomeViewModel
			{
				Reviews = reviewsToCheck
			};

			return View(viewModel);
		}
	}
}
