using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.Pager;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Controllers
{
	[Authorize]
	public class UserCarsController : Controller
	{
		private readonly IUserCarsService _userCarsService;
		private readonly IAccessoriesService _accessoriesService;
		private readonly IAdService _adService;
		private readonly IMemoryCache _memoryCache;

		public UserCarsController(IUserCarsService _userCarsServiceContext,
			IAccessoriesService accessoriesServiceContext,
			IAdService _adServiceContext,
			IMemoryCache _memoryCacheContext)
		{
			_userCarsService = _userCarsServiceContext;
			_accessoriesService = accessoriesServiceContext;
			_adService = _adServiceContext;
			_memoryCache = _memoryCacheContext;
		}

		public async Task<IActionResult> Index(AdInformationViewModel adInformation)
		{
			Guid userId = User.GetUserId();

			if (adInformation.CurrentPage < 1)
			{
				adInformation.CurrentPage = 1;
			}

			Pager pager = new Pager(await _userCarsService.GetUserCarsCountAsync(adInformation, userId.ToString()), adInformation.CurrentPage, DefaultPageSizeForAds);
			adInformation.Pager = pager;

			IEnumerable<AdPreviewViewModel> cars = await _userCarsService.GetUserCarsPreviewAsync(userId, adInformation);

			adInformation.Ads = cars;

			return View(adInformation);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int carId)
		{

			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}

			string userCarsInformationCacheKey = $"{UserCarsInformationCacheKey}_{carId}";

			AdInformationViewModel car = _memoryCache.Get<AdInformationViewModel>(userCarsInformationCacheKey);

			if (car == null)
			{
				car = await _userCarsService.GetCarsInformationAsync(carId);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(UserCarsInformationExpirationToMinutes));

				_memoryCache.Set(userCarsInformationCacheKey, car, cacheOptions);
			}

			if (car == null)
			{
				return NotFound();
			}

			string userCarsAccessoriesCacheKey = $"{UserCarsAccessoriesCacheKey}_{carId}";

			List<AccessoryViewModel> carAccessories = _memoryCache.Get<List<AccessoryViewModel>>(userCarsAccessoriesCacheKey);

			if (carAccessories == null || carAccessories.Any() == false)
			{
				carAccessories = await _accessoriesService.GetCarAccessoriesForOwnedCarsAsync(carId);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(UserCarsAccessoriesExpirationToMinutes));

				_memoryCache.Set(userCarsAccessoriesCacheKey, carAccessories, cacheOptions);
			}

			if (carAccessories == null)
			{
				return NotFound();
			}

			car.Accessories = carAccessories;

			return View(car);
		}

		[HttpGet]
		public async Task<IActionResult> Sell(int carId)
		{
			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}

			UserCarsSellViewModel sellInformation = await _userCarsService.GetSellInformationForCarAsync(carId);

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
			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}


			if (await _userCarsService.IdExists<Ad>(adId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}
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
		public async Task<IActionResult> Delete(int carId)
		{
			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}

			TempData["ConfirmUserCarDelete"] = true;
			TempData["UserCarIdToDelete"] = carId;
			return RedirectToAction("Index", "UserCars");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int carId)
		{
			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}

			await _userCarsService.DeleteCarAdAsync(carId);

			TempData["DeleteMessage"] = true;

			return RedirectToAction("Index", "UserCars");
		}
	}
}
