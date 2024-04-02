using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Home;
using Xcelerate.Core.Models.Pager;
using Xcelerate.Models;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{

		private readonly IHomeService _homeService;

		public HomeController(IHomeService context)
		{
			_homeService = context;
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult About()
		{
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

			homePageView.DataStatistics = viewModel.DataStatistics;
			homePageView.NewsPreview = viewModel.NewsPreview;

			return View(homePageView);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
