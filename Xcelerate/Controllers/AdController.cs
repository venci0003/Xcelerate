namespace Xcelerate.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using Core.Contracts;
	using Core.Models.Ad;
	using Core.Models.Pager;
	using Core.Models.Review;
	using Extension;
	using Infrastructure.Data.Models;
	using static Common.ApplicationConstants;
	using static Common.NotificationMessages.AlertMessages;
	[Authorize]
	public class AdController : Controller
	{
		private readonly IAdService _adService;
		private readonly IAccessoriesService _accessoriesService;
		private readonly IReviewService _reviewService;
		private readonly IMessageService _messageService;
		private readonly IMemoryCache _memoryCache;

		public AdController(IAdService adServiceContext,
			IAccessoriesService accessoriesServiceContext,
			IReviewService reviewServiceContext,
			IMessageService messageServiceContext,
			IMemoryCache _memoryCacheContext)
		{
			_adService = adServiceContext;
			_accessoriesService = accessoriesServiceContext;
			_reviewService = reviewServiceContext;
			_messageService = messageServiceContext;
			_memoryCache = _memoryCacheContext;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index(AdInformationViewModel adInformation, int firstCarId, bool compareClicked)
		{
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			}

			if (adInformation.CurrentPage < 1)
			{
				adInformation.CurrentPage = 1;
			}

			ViewBag.FirstCarId = firstCarId;

			if (compareClicked == true)
			{
				TempData["CompareButtonClicked"] = true;
			}

			Pager pager = new Pager(await _adService.GetCarAdsCountAsync(adInformation), adInformation.CurrentPage, DefaultPageSizeForAds);
			adInformation.Pager = pager;

			IEnumerable<AdPreviewViewModel> carsPreview = await _adService.GetCarsPreviewAsync(adInformation);

			adInformation.Ads = carsPreview;

			return View(adInformation);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int adId)
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			ViewBag.UserId = User.GetUserId();

			if (await _adService.IdExists<Ad>(adId) == false)
			{
				return NotFound();
			}

			string carAdInformationCacheKey = $"{CarAdInformationCacheKey}_{adId}";

			AdInformationViewModel? carAdInfo = _memoryCache.Get<AdInformationViewModel>(carAdInformationCacheKey);

			if (carAdInfo == null)
			{
				carAdInfo = await _adService.GetCarsInformationAsync(adId);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(CarAdInformationExpirationToMinutes));

				_memoryCache.Set(carAdInformationCacheKey, carAdInfo, cacheOptions);
			}

			if (carAdInfo == null)
			{
				return NotFound();
			}

			string carAccessoriesCacheKey = $"{CarAccessoriesCacheKey}_{adId}";

			List<AccessoryViewModel> carAccessories = _memoryCache.Get<List<AccessoryViewModel>>(carAccessoriesCacheKey);

			if (carAccessories == null || carAccessories.Any() == false)
			{
				carAccessories = await _accessoriesService.GetCarAccessoriesForSaleAsync(adId);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(CarAccessoriesExpirationToMinutes));

				_memoryCache.Set(carAccessoriesCacheKey, carAccessories, cacheOptions);
			}

			if (carAccessories == null)
			{
				return NotFound();
			}

			string carReviewsCacheKey = $"{CarReviewsCacheKey}_{adId}";

			List<UsersReviewsViewModel> carReviews = _memoryCache.Get<List<UsersReviewsViewModel>>(carReviewsCacheKey);

			if (carReviews == null || carReviews.Any() == false)
			{
				carReviews = await _reviewService.GetUserReviewsAsync(adId);

				var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(CarReviewsExpirationToMinutes));

				_memoryCache.Set(carReviewsCacheKey, carReviews, cacheOptions);
			}

			carAdInfo.Reviews = carReviews;

			carAdInfo.Accessories = carAccessories;

			return View(carAdInfo);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			AdCreateViewModel adViewModel = await _accessoriesService.GetAccessories();
			return View(adViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(AdCreateViewModel adViewModel)
		{
			Guid userId = User.GetUserId();

			await _adService.CreateAdAsync(adViewModel, userId.ToString());

			TempData[AdCreatedSuccesfullyTempData] = AdCreatedSuccesfullyMessage;

			return RedirectToAction("UserAds", "Ad");
		}

		public async Task<IActionResult> UserAds(AdInformationViewModel adInformation)
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			var userId = User.GetUserId();

			if (adInformation.CurrentPage < 1)
			{
				adInformation.CurrentPage = 1;
			}

			Pager pager = new Pager(await _adService.GetUserAdsCountAsync(adInformation, userId.ToString()), adInformation.CurrentPage, DefaultPageSizeForAds);
			adInformation.Pager = pager;

			IEnumerable<AdPreviewViewModel> userAds = await _adService.GetUserAdsAsync(userId, adInformation);

			adInformation.Ads = userAds;

			return View(adInformation);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int carId)
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			if (await _adService.IdExists<Car>(carId) == false)
			{
				return NotFound();
			}

			AdEditViewModel editInformation = await _adService.GetEditInformationAsync(carId);

			return View(editInformation);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AdEditViewModel adViewModel)
		{
			await _adService.EditCarAdAsync(adViewModel);

			return RedirectToAction("UserAds", "Ad");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int carId)
		{
			if (await _adService.IdExists<Car>(carId) == false)
			{
				return NotFound();
			}

			await _adService.DeleteCarAdAsync(carId);

			TempData[AdDeletedSuccesfullyTempData] = AdDeletedSuccesfullyMessage;

			return Json(new { success = true });
		}


		[HttpPost]
		public async Task<IActionResult> Buy(int carId)
		{
			Guid buyerUserId = User.GetUserId();

			if (await _adService.IdExists<Car>(carId) == false)
			{
				return NotFound();
			}

			Car carToBuy = await _adService.GetCarByIdAsync(carId);

			if (carToBuy == null)
			{
				return NotFound();
			}

			carToBuy.UserId = buyerUserId;

			await _adService.BuyCarAsync(carToBuy);

			return RedirectToAction("Index", "UserCars");

		}

		public async Task<IActionResult> Compare(int firstCarId, int secondCarId)
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			try
			{

				if (await _adService.IdExists<Car>(firstCarId) == false || await _adService.IdExists<Car>(secondCarId) == false)
				{
					return NotFound();
				}

				var (firstCar, secondCar) = await _adService.GetTwoCarsByIdAsync(firstCarId, secondCarId);

				if (firstCar.CarId == secondCar.CarId)
				{
					TempData[AdCompareErrorTempData] = AdCompareErrorMessage;
					return RedirectToAction("Index", "Ad");
				}

				return View((firstCar, secondCar));
			}
			catch (ArgumentException ex)
			{
				return RedirectToAction("Error", "Home");
			}
		}
	}
}
