using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Core.Services;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Controllers
{
	public class UserCarsController : Controller
	{
		private readonly IUserCarsService _userCarsService;
		private readonly IAccessoriesService _accessoriesService;

		public UserCarsController(IUserCarsService _userCarsServiceContext, IAccessoriesService accessoriesServiceContext)
		{
			_userCarsService = _userCarsServiceContext;
			_accessoriesService = accessoriesServiceContext;
		}

		public async Task<IActionResult> Index()
		{
			var cars = await _userCarsService.GetUserCarsPreviewAsync();

			return View(cars);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int? carId)
		{

			if (carId == null)
			{
				return NotFound();
			}

			UserCarsInformationViewModel car = await _userCarsService.GetCarsInformationAsync(carId);

			if (car == null)
			{
				return NotFound();
			}

			List<AccessoryViewModel> carAccessories = await _accessoriesService.GetCarAccessoriesAsync(carId.Value);

			if (carAccessories == null)
			{
				return NotFound();
			}

			car.Accessories = carAccessories;

			return View(car);
		}

		[HttpGet]
		public async Task<IActionResult> Sell(int? carId)
		{
			if (carId == null)
			{
				return NotFound();
			}

			UserCarsSellViewModel sellInformation = await _userCarsService.GetSellInformationForCarAsync(carId.Value);

			return View(sellInformation);
		}


		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Sell(UserCarsSellViewModel adViewModel)
		{
			/*var adEdit =*/
			await _userCarsService.SellCarAsync(adViewModel);

			//if (adEdit)
			//{
			//	return "message";
			//}

			return RedirectToAction("Index", "Ad");
		}
	}
}
