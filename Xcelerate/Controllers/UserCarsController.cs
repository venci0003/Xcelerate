using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.Pager;
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

		public async Task<IActionResult> Index(AdInformationViewModel adInformation)
		{
			if (adInformation.CurrentPage < 1)
			{
				adInformation.CurrentPage = 1;
			}

			Pager pager = new Pager(await _adService.GetCountAsync(adInformation), adInformation.CurrentPage);
			adInformation.Pager = pager;

			Guid userId = User.GetUserId();

			IEnumerable<AdPreviewViewModel> cars = await _userCarsService.GetUserCarsPreviewAsync(userId, adInformation);

			adInformation.Ads = cars;

			return View(adInformation);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int? carId)
		{

			if (carId == null)
			{
				return NotFound();
			}

			AdInformationViewModel car = await _userCarsService.GetCarsInformationAsync(carId);

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

		[HttpPost]
		public IActionResult Delete(int? carId)
		{
			TempData["ConfirmUserCarDelete"] = true;
			TempData["UserCarIdToDelete"] = carId;
			return RedirectToAction("Index", "UserCars");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int? carId)
		{
			if (carId == null)
			{
				return NotFound();
			}

			await _userCarsService.DeleteCarAdAsync(carId);

			TempData["DeleteMessage"] = true;

			return RedirectToAction("Index", "UserCars");
		}
	}
}
