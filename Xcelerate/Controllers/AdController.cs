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
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;

		private readonly IAdService _adService;
		private readonly IAccessoriesService _accessoriesService;

		public AdController(XcelerateContext dbContext, IWebHostEnvironment webHostEnvironment, IAdService adServiceContext, IAccessoriesService accessoriesServiceContext)
		{
			_dbContext = dbContext;
			_webHostEnvironment = webHostEnvironment;

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
			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
				// Handle validation errors appropriately
				return View(adViewModel);
			}

			try
			{
				var userId = User.GetUserId();
				var car = await _dbContext.Cars
					.Include(c => c.Engine)
					.Include(c => c.Manufacturer)
					.Include(c => c.Address)
					.Include(c => c.Ad)
					.Include(c => c.CarAccessories)
					.Include(c => c.Images)
					.FirstOrDefaultAsync(c => c.CarId == adViewModel.CarId);

				if (car == null)
				{
					return NotFound();
				}

				// Update the properties of the existing car entity based on the ViewModel
				car.Brand = adViewModel.Brand;
				car.Model = adViewModel.Model;
				car.Year = adViewModel.Year;
				car.Engine.Model = adViewModel.Engine;
				car.Condition = adViewModel.Condition;
				car.EuroStandard = adViewModel.EuroStandard;
				car.FuelType = adViewModel.FuelType;
				car.Colour = adViewModel.Colour;
				car.Transmition = adViewModel.Transmition;
				car.DriveTrain = adViewModel.DriveTrain;
				car.Weight = adViewModel.Weight;
				car.Mileage = adViewModel.Mileage;
				car.Price = adViewModel.Price;
				car.BodyType = adViewModel.BodyType;
				car.Manufacturer.Name = adViewModel.Manufacturer;
				car.Ad.CarDescription = adViewModel.CarDescription;
				car.Address.CountryName = adViewModel.Address.CountryName;
				car.Address.TownName = adViewModel.Address.TownName;
				car.Address.StreetName = adViewModel.Address.StreetName;

				// Update CarAccessories
				var selectedAccessories = adViewModel.SelectedCheckBoxId;
				var existingAccessories = car.CarAccessories.Select(ca => ca.AccessoryId).ToList();

				var accessoriesToAdd = selectedAccessories.Except(existingAccessories);
				var accessoriesToRemove = existingAccessories.Except(selectedAccessories);

				foreach (var accessoryId in accessoriesToAdd)
				{
					await _dbContext.CarAccessories.AddAsync(new CarAccessory()
					{
						CarId = car.CarId,
						AccessoryId = accessoryId
					});
				}

				foreach (var accessoryId in accessoriesToRemove)
				{
					var accessoryToRemove = car.CarAccessories.FirstOrDefault(ca => ca.AccessoryId == accessoryId);
					if (accessoryToRemove != null)
					{
						_dbContext.CarAccessories.Remove(accessoryToRemove);
					}
				}

				foreach (var oldImage in car.Images.ToList())
				{
					var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad", oldImage.ImageUrl);

					if (System.IO.File.Exists(oldImagePath))
					{
						using (var stream = new FileStream(oldImagePath, FileMode.Open, FileAccess.ReadWrite))
						{
							// Close and dispose of the FileStream before deletion
							stream.Close();
						}
						System.IO.File.Delete(oldImagePath);
					}

					// Remove the image from the database
					_dbContext.Images.Remove(oldImage);
				}


				// Update Images (assuming you want to replace all images on edit)
				var adImagesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad");
				foreach (var image in adViewModel.UploadedImages)
				{
					if (image != null && image.Length > 0)
					{
						var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
						var filePath = Path.Combine(adImagesDirectory, uniqueFileName);
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							image.CopyTo(stream);
						}

						Image imageToCreate = new Image()
						{
							CarId = car.CarId,
							ImageUrl = uniqueFileName
						};
						_dbContext.Images.Add(imageToCreate);
					}
				}

				await _dbContext.SaveChangesAsync();

				return RedirectToAction("Index", "Ad");
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "An error occurred while saving the ad.");
				// Handle exceptions appropriately (log, show error page, etc.)
				return View(adViewModel);
			}
		}

		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Delete(int? carId)
		{

			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
				// Handle validation errors appropriately
				return RedirectToAction("Information", new { carId = carId });
			}

			if (carId == null)
			{
				return NotFound();
			}

			var car = await _dbContext.Cars
				.Include(c => c.Ad)
				.Include(c => c.Images)
				.Include(c => c.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
					.Include(m => m.Manufacturer)
					.Include(a => a.Address)
					.Include(e => e.Engine)
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (car == null)
			{
				return NotFound();
			}

			try
			{
				// Remove associated images from file system and database
				foreach (var image in car.Images)
				{
					var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad", image.ImageUrl);

					if (System.IO.File.Exists(imagePath))
					{
						try
						{
							using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.ReadWrite))
							{
								// Close the file stream before deletion
								stream.Close();
							}
							// Attempt to delete the file
							System.IO.File.Delete(imagePath);
						}
						catch (IOException)
						{
							ModelState.AddModelError(string.Empty, "An error occurred while deleting the ad.");
						}
					}

					_dbContext.Images.Remove(image);
				}

				// Remove associated reviews
				if (car.Ad != null && car.Ad.Reviews != null)
				{
					_dbContext.Reviews.RemoveRange(car.Ad.Reviews);
				}

				// Remove associated ad
				if (car.Ad != null)
				{
					_dbContext.Ads.Remove(car.Ad);
				}

				// Remove associated car accessories
				if (car.CarAccessories != null)
				{
					_dbContext.CarAccessories.RemoveRange(car.CarAccessories);
				}

				// Remove associated address
				if (car.Address != null)
				{
					_dbContext.Addresses.Remove(car.Address);
				}

				// Remove associated manufacturer
				if (car.Manufacturer != null)
				{
					_dbContext.Manufacturers.Remove(car.Manufacturer);
				}

				// Remove associated engine
				if (car.Engine != null)
				{
					_dbContext.Engines.Remove(car.Engine);
				}

				// Remove car entity
				_dbContext.Cars.Remove(car);

				await _dbContext.SaveChangesAsync();

				return RedirectToAction("Index", "Ad");
			}
			catch (Exception)
			{
				// Handle exceptions appropriately (log, show error page, etc.)
				ModelState.AddModelError(string.Empty, "An error occurred while deleting the ad.");
				return RedirectToAction("Information", new { carId = carId });
			}
		}

	}
}
