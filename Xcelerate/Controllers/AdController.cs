using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using static Xcelerate.Common.EntityValidation;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;
using Xcelerate.Common;
using Xcelerate.Core.Contracts;

namespace Xcelerate.Controllers
{
	public class AdController : Controller
	{
		private readonly IAdService _adService;
		private readonly IAccessoriesService _accessoriesService;

		public AdController(IAdService adServiceContext, IAccessoriesService accessoriesServiceContext)
		{
			_adService = adServiceContext;
			_accessoriesService = accessoriesServiceContext;
		}

		public async Task<IActionResult> Index()
		{
			var cars = await _adService.GetCarsPreviewAsync();

			return View(cars);
		}

		[HttpGet]
		public async Task<IActionResult> Information(int? carId)
		{

			if (carId == null)
			{
				return NotFound();
			}

			AdInformationViewModel car = await _adService.GetCarsInformationAsync(carId);

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

			/*var deletedAd =*/
			await _adService.DeleteCarAdAsync(carId);

			//if (deletedAd)
			//{
			//	return "message";
			//}

			return RedirectToAction("UserAds", "Ad");

		}
	}
}
