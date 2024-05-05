namespace Xcelerate.Controllers
{
	using Core.Contracts;
	using Core.Models.Home;
	using Core.Models.Pager;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Xcelerate.Extension;
	using static Common.ApplicationConstants;

	[AllowAnonymous]
	public class HomeController : Controller
	{

		private readonly IHomeService _homeService;
		private readonly IMessageService _messageService;

		public HomeController(IHomeService context, IMessageService _messageServiceContext)
		{
			_homeService = context;
			_messageService = _messageServiceContext;
		}

		//Not used yet
		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		public async Task<IActionResult> About()
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			return View();
		}

		public async Task<IActionResult> HomePage(HomePageViewModel homePageView)
		{
			if (homePageView.CurrentPage < 1)
			{
				homePageView.CurrentPage = 1;
			}

			Pager pager = new Pager(await _homeService.GetNewsCountAsync(), homePageView.CurrentPage, DefaultPageSizeForNews);
			homePageView.Pager = pager;

			HomePageViewModel viewModel = await _homeService.GetHomePageDataAsync(homePageView);

			if (User.Identity.IsAuthenticated)
			{
				ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			}
			homePageView.DataStatistics = viewModel.DataStatistics;
			homePageView.NewsPreview = viewModel.NewsPreview;

			return View(homePageView);
		}


		public IActionResult Unauthorized()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 404 || statusCode == 400)
			{
				return this.View("Error404");
			}
			else if (statusCode == 401)
			{
				return View("Unauthorized");
			}
			return View("Error");
		}
	}
}
