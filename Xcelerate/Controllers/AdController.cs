using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.Pager;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Controllers
{
	[Authorize]
	public class AdController : Controller
	{
		private readonly IAdService _adService;
		private readonly IAccessoriesService _accessoriesService;
		private readonly IReviewService _reviewService;

		public AdController(IAdService adServiceContext, IAccessoriesService accessoriesServiceContext, IReviewService reviewServiceContext)
		{
			_adService = adServiceContext;
			_accessoriesService = accessoriesServiceContext;
			_reviewService = reviewServiceContext;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Index(AdInformationViewModel adInformation, int firstCarId, bool compareClicked)
		{
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
			ViewBag.UserId = User.GetUserId();

			if (await _adService.IdExists<Ad>(adId) == false)
			{
				//RETURN TO ERROR PAGE 
				return RedirectToAction("Index");
			}

			AdInformationViewModel car = await _adService.GetCarsInformationAsync(adId);

			if (car == null)
			{
				return NotFound();
			}

			List<AccessoryViewModel> carAccessories = await _accessoriesService.GetCarAccessoriesForSaleAsync(adId);

			if (carAccessories == null)
			{
				return NotFound();
			}

			var carReviews = await _reviewService.GetUserReviewsAsync(adId);

			car.Reviews = carReviews;

			car.Accessories = carAccessories;

			return View(car);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			AdCreateViewModel adViewModel = await _accessoriesService.GetAccessories();
			return View(adViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(AdCreateViewModel adViewModel)
		{
			Guid userId = User.GetUserId();

			await _adService.CreateAdAsync(adViewModel, userId.ToString());

			TempData["AdCreatedSuccesfully"] = true;

			return RedirectToAction("UserAds", "Ad");
		}

		public async Task<IActionResult> UserAds(AdInformationViewModel adInformation)
		{
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
			if (await _adService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
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
		public IActionResult Delete(int? carId)
		{
			TempData["ConfirmDelete"] = true;
			TempData["CarIdToDelete"] = carId;
			return RedirectToAction("UserAds", "Ad");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int carId)
		{
			if (await _adService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
				return NotFound();
			}

			await _adService.DeleteCarAdAsync(carId);

			TempData["DeleteMessage"] = true;

			return RedirectToAction("UserAds", "Ad");
		}

		[HttpPost]
		public async Task<IActionResult> Buy(int carId)
		{
			Guid buyerUserId = User.GetUserId();

			if (await _adService.IdExists<Car>(carId) == false)
			{
				//RETURN TO ERROR PAGE 
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
			try
			{

				if (await _adService.IdExists<Car>(firstCarId) == false || await _adService.IdExists<Car>(secondCarId) == false)
				{
					//RETURN TO ERROR PAGE 
					return NotFound();
				}

				var (firstCar, secondCar) = await _adService.GetTwoCarsByIdAsync(firstCarId, secondCarId);

				if (firstCar.CarId == secondCar.CarId)
				{
					TempData["CompareError"] = true;
					return RedirectToAction("Index", "Ad");
				}

				// Optionally, you can map these cars to view models if needed

				return View((firstCar, secondCar));
			}
			catch (ArgumentException ex)
			{
				// Handle error (e.g., car not found) appropriately
				return RedirectToAction("Error", "Home");
			}
		}
	}
}
