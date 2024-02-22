using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Services;

namespace Xcelerate.Controllers
{
	public class UserCarsController : Controller
	{
		private readonly IUserCarsService _userCarsService;

		public UserCarsController(IUserCarsService _userCarsServiceContext)
		{
			_userCarsService = _userCarsServiceContext;
		}

		public async Task<IActionResult> Index()
		{
			var cars = await _userCarsService.GetUserCarsPreviewAsync();

			return View(cars);
		}

		public IActionResult Sell()
		{
			return View();
		}
	}
}
