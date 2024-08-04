namespace Xcelerate.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using Core.Contracts;
	using Core.Models.Ad;
	using Core.Models.Pager;
	using Core.Models.UserCars;
	using Extension;
	using Infrastructure.Data.Models;
	using static Common.ApplicationConstants;
	using static Common.NotificationMessages.AlertMessages;


	[Authorize]
	public class UserCarsController : Controller
	{
		private readonly IUserCarsService _userCarsService;
		private readonly IAccessoriesService _accessoriesService;
		private readonly IAdService _adService;
		private readonly IMessageService _messageService;
		private readonly IMemoryCache _memoryCache;

		public UserCarsController(IUserCarsService _userCarsServiceContext,
			IAccessoriesService accessoriesServiceContext,
			IAdService _adServiceContext,
			IMessageService _messageServiceContext,
			IMemoryCache _memoryCacheContext)
		{
			_userCarsService = _userCarsServiceContext;
			_accessoriesService = accessoriesServiceContext;
			_adService = _adServiceContext;
			_messageService = _messageServiceContext;
			_memoryCache = _memoryCacheContext;
		}

		public async Task<IActionResult> Index(AdInformationViewModel adInformation)
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());

			Guid userId = User.GetUserId();

			if (adInformation.CurrentPage < 1)
			{
				adInformation.CurrentPage = 1;
			}

			Pager pager = new Pager(await _userCarsService.GetUserCarsCountAsync(adInformation, userId.ToString()), adInformation.CurrentPage, DefaultPageSizeForAds);
			adInformation.Pager = pager;

			IEnumerable<AdPreviewViewModel> cars = await _userCarsService.GetUserCarsPreviewAsync(userId, adInformation);

			adInformation.Ads = cars;

			if (TempData["Notification"] != null)
			{
				ViewBag.Notification = TempData["Notification"].ToString();
			}

			return View(adInformation);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int carId)
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());

			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				return NotFound();
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
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());

			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				return NotFound();
			}

			UserCarsSellViewModel sellInformation = await _userCarsService.GetSellInformationForCarAsync(carId);

			return View(sellInformation);
		}


		[HttpPost]
		public async Task<IActionResult> Sell(UserCarsSellViewModel adViewModel)
		{
			Guid userId = User.GetUserId();

			await _userCarsService.SellCarAsync(adViewModel, userId.ToString());

			return RedirectToAction("UserAds", "Ad");
		}

		public async Task<IActionResult> Cancel(int carId, int adId)
		{
			if (await _userCarsService.IdExists<Car>(carId) == false)
			{
				return NotFound();
			}

			if (await _userCarsService.IdExists<Ad>(adId) == false)
			{
				return NotFound();
			}
			Car adToCancel = await _adService.GetCarByIdAsync(carId);

			if (adToCancel == null)
			{
				return NotFound();
			}

			await _userCarsService.CancelSellAdAsync(adToCancel, adId);

			return RedirectToAction("Index", "UserCars");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int carId)
		{
			if (await _adService.IdExists<Car>(carId) == false)
			{
				return NotFound();
			}

			await _userCarsService.DeleteCarAdAsync(carId);

			TempData[AdDeletedSuccesfullyTempData] = AdDeletedSuccesfullyMessage;

			return Json(new { success = true });
		}
	}
}
