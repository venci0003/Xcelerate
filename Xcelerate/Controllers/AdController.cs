using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.Review;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;

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
		public async Task<IActionResult> Index(int firstCarId, bool compareClicked = false)
		{
			ViewBag.FirstCarId = firstCarId;

			var cars = await _adService.GetCarsPreviewAsync();

			if (compareClicked == true)
			{
				TempData["CompareButtonClicked"] = true;
			}

			return View(cars);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int? carId, int adId)
		{
			ViewBag.UserId = User.GetUserId();

			if (carId == null)
			{
				return NotFound();
			}

			AdInformationViewModel car = await _adService.GetCarsInformationAsync(adId);

			if (car == null)
			{
				return NotFound();
			}

			List<AccessoryViewModel> carAccessories = await _accessoriesService.GetCarAccessoriesAsync(carId.Value);

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

		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create(AdCreateViewModel adViewModel)
		{
			Guid userId = User.GetUserId();

			await _adService.CreateAdAsync(adViewModel, userId.ToString());

			TempData["AdCreatedSuccesfully"] = true;

			return RedirectToAction("Index", "Ad");
		}

		public async Task<IActionResult> UserAds()
		{
			var userId = User.GetUserId();

			var userAds = await _adService.GetUserAdsAsync(userId);

			return View(userAds);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int? carId)
		{
			if (carId == null)
			{
				return NotFound();
			}

			AdEditViewModel editInformation = await _adService.GetEditInformationAsync(carId.Value);

			return View(editInformation);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(AdEditViewModel adViewModel)
		{
			/*var adEdit =*/
			await _adService.EditCarAdAsync(adViewModel);

			//if (adEdit)
			//{
			//	return "message";
			//}

			return RedirectToAction("Index", "Ad");
		}

		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Delete(int? carId)
		{

			await _adService.DeleteCarAdAsync(carId);

			TempData["DeleteMessage"] = true;

			return RedirectToAction("UserAds", "Ad");

		}

		[HttpPost]
		public async Task<IActionResult> Buy(int? carId)
		{

			Guid buyerUserId = User.GetUserId();

			Car carToBuy = await _adService.GetCarByIdAsync(carId.Value);

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
