using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Home;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Models;

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

		public async Task<IActionResult> HomePage(DataStatisticsViewModel dataStatisticsView)
		{
			var statistics = await _homeService.GetDataStatisticsAsync(dataStatisticsView);
			return View(statistics);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
