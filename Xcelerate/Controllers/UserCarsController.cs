using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Controllers
{
	[Authorize]
	public class UserCarsController : Controller
	{
		private readonly IUserCarsService _userCarsService;
		private readonly IAccessoriesService _accessoriesService;
		private readonly IAdService _adService;

		public UserCarsController(IUserCarsService _userCarsServiceContext, IAccessoriesService accessoriesServiceContext, IAdService _adServiceContext)
		{
			_userCarsService = _userCarsServiceContext;
			_accessoriesService = accessoriesServiceContext;
			_adService = _adServiceContext;
		}

		public async Task<IActionResult> Index()
		{
			Guid userId = User.GetUserId();

			var cars = await _userCarsService.GetUserCarsPreviewAsync(userId);

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

			List<AccessoryViewModel> carAccessories = await _accessoriesService.GetCarAccessoriesForOwnedCarsAsync(carId.Value);

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
		public async Task<IActionResult> Sell(UserCarsSellViewModel adViewModel)
		{
			Guid userId = User.GetUserId();

			await _userCarsService.SellCarAsync(adViewModel, userId.ToString());

			return RedirectToAction("Index", "Ad");
		}

		public async Task<IActionResult> Cancel(int carId, int adId)
		{

			Car adToCancel = await _adService.GetCarByIdAsync(carId);

			if (adToCancel == null)
			{
				return NotFound();
			}

			//CancelCarAsync
			await _userCarsService.CancelSellAdAsync(adToCancel, adId);

			return RedirectToAction("Index", "UserCars");
		}
	}
}
