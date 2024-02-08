using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Controllers
{
	public class AdController : Controller
	{
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public AdController(XcelerateContext dbContext, IWebHostEnvironment webHostEnvironment)
		{
			_dbContext = dbContext;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> Index()
		{

			var cars = await _dbContext.Cars.Select(car => new AdPreviewViewModel
			{
				CarId = car.CarId,
				ImageUrls = car.Images.Select(car => car.ImageUrl).ToList(),
				Brand = car.Brand,
				Model = car.Model,
				Year = car.Year,
				Engine = car.Engine.Model,
				Condition = car.Condition,
				EuroStandard = car.EuroStandard,
				FuelType = car.FuelType,
				Price = car.Price,
				FirstName = car.User.FirstName,
				LastName = car.User.LastName,
			}).ToListAsync();

			return View(cars);
		}


		public async Task<IActionResult> Information(int? carId)
		{

			var car = await _dbContext.Cars.Where(c => c.CarId == carId).Select(car => new AdInformationViewModel
			{
				ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
				Accessories = car.CarAccessories.Select(accessory => new AccessoryViewModel
				{
					AccessoryId = accessory.AccessoryId,
					Name = accessory.Accessory.Name
				}).ToList(),
				Brand = car.Brand,
				Model = car.Model,
				Year = car.Year,
				Engine = car.Engine.Model,
				Condition = car.Condition,
				EuroStandard = car.EuroStandard,
				FuelType = car.FuelType,
				Colour = car.Colour,
				Transmition = car.Transmition,
				DriveTrain = car.DriveTrain,
				Weight = car.Weight,
				Mileage = car.Mileage,
				Price = car.Price,
				BodyType = car.BodyType,
				Manufacturer = car.Manufacturer.Name,
				Address = new AddressViewModel
				{
					CountryName = car.Address.CountryName,
					TownName = car.Address.TownName,
					StreetName = car.Address.StreetName,
				},
				CarDescription = car.Ad.CarDescription
			}).FirstOrDefaultAsync();

			if (car == null)
			{
				// Handle the case where the car with the specified CarId is not found
				return NotFound();
			}

			return View(car);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			AdInformationViewModel adViewModel = new AdInformationViewModel();

			List<AccessoryViewModel> accessories = await _dbContext.Accessories.Select(accessory => new AccessoryViewModel()
			{
				AccessoryId = accessory.AccessoryId,
				Name = accessory.Name
			}).ToListAsync();

			adViewModel.Accessories = accessories;

			return View(adViewModel);
		}

		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create(AdInformationViewModel adViewModel)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
			}

			if (ModelState.IsValid)
			{
				try
				{
					var userId = User.GetUserId();
					// Map the ViewModel to your Car model
					var car = new Car
					{
						UserId = userId,
						Brand = adViewModel.Brand,
						Model = adViewModel.Model,
						Year = adViewModel.Year,
						Engine = new Engine { Model = adViewModel.Engine },
						Condition = adViewModel.Condition,
						EuroStandard = adViewModel.EuroStandard,
						FuelType = adViewModel.FuelType,
						Colour = adViewModel.Colour,
						Transmition = adViewModel.Transmition,
						DriveTrain = adViewModel.DriveTrain,
						Weight = adViewModel.Weight,
						Mileage = adViewModel.Mileage,
						Price = adViewModel.Price,
						BodyType = adViewModel.BodyType,
						Manufacturer = new Manufacturer { Name = adViewModel.Manufacturer },
						Ad = new Ad
						{
							UserId = userId,
							CarDescription = adViewModel.CarDescription
						},
						Address = new Address
						{
							CountryName = adViewModel.Address.CountryName,
							TownName = adViewModel.Address.TownName,
							StreetName = adViewModel.Address.StreetName
						}
					};

					await _dbContext.AddAsync(car);
					await _dbContext.SaveChangesAsync();

					foreach (var accessoryId in adViewModel.SelectedCheckBoxId)
					{
						_dbContext.CarAccessories.Add(new CarAccessory()
						{
							CarId = car.CarId,
							AccessoryId = accessoryId
						});
					}

					await _dbContext.SaveChangesAsync();

					if (adViewModel.UploadedImages.Count != 6)
					{
						ModelState.AddModelError("Images", "Please upload exactly 6 images.");
						return View(adViewModel);
					}

					var adImagesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad");

					foreach (var image in adViewModel.UploadedImages)
					{
						//if (image.Length > 2097152) // 2 MB limit
						//{
						//	ModelState.AddModelError("UploadedImages", "Image size should be up to 2 MB.");
						//	return View(adViewModel);
						//}
						if (image != null && image.Length > 0)
						{
							var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
							var filePath = Path.Combine(adImagesDirectory, uniqueFileName);
							image.CopyTo(new FileStream(filePath, FileMode.Create));

							Image imageToCreate = new Image()
							{
								CarId = car.CarId,
								ImageUrl = uniqueFileName
							};
							await _dbContext.AddAsync(imageToCreate);
						}
					}
					// Save car to the database
					await _dbContext.SaveChangesAsync();


					return RedirectToAction("Index", "Ad");  // Redirect to the desired action after successful creation
				}
				catch (Exception)
				{
					// Handle exceptions appropriately (log, show error page, etc.)
					ModelState.AddModelError(string.Empty, "An error occurred while saving the ad.");
				}
			}

			// If ModelState is not valid, return to the Create view with the ViewModel
			return View(adViewModel);
		}

		public async Task<IActionResult> UserAds()
		{
			var userId = User.GetUserId();

			// Retrieve ads for the current user
			var userAds = await _dbContext.Ads
		.Where(ad => ad.UserId == userId)
		.Select(car => new AdPreviewViewModel
		{
			CarId = car.CarId,
			ImageUrls = car.Car.Images.Select(car => car.ImageUrl).ToList(),
			Brand = car.Car.Brand,
			Model = car.Car.Model,
			Year = car.Car.Year,
			Engine = car.Car.Engine.Model,
			Condition = car.Car.Condition,
			EuroStandard = car.Car.EuroStandard,
			FuelType = car.Car.FuelType,
			Price = car.Car.Price,
			FirstName = car.User.FirstName,
			LastName = car.User.LastName,
		})
		.ToListAsync();

			// Pass the ads to the view
			return View(userAds);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int? carId)
		{
			if (carId == null)
			{
				return NotFound();
			}

			var car = await _dbContext.Cars
				.Include(c => c.Engine)
				.Include(c => c.Manufacturer)
				.Include(c => c.Address)
				.Include(c => c.Ad)
				.Include(c => c.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
				.Include(c => c.Images)
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (car == null)
			{
				return NotFound();
			}

			AdInformationViewModel adViewModel = new AdInformationViewModel
			{
				CarId = car.CarId,
				ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
				Accessories = car.CarAccessories.Select(accessory => new AccessoryViewModel
				{
					AccessoryId = accessory.AccessoryId,
					Name = accessory.Accessory.Name
				}).ToList(),
				Brand = car.Brand,
				Model = car.Model,
				Year = car.Year,
				Engine = car.Engine.Model,
				Condition = car.Condition,
				EuroStandard = car.EuroStandard,
				FuelType = car.FuelType,
				Colour = car.Colour,
				Transmition = car.Transmition,
				DriveTrain = car.DriveTrain,
				Weight = car.Weight,
				Mileage = car.Mileage,
				Price = car.Price,
				BodyType = car.BodyType,
				Manufacturer = car.Manufacturer.Name,
				Address = new AddressViewModel
				{
					CountryName = car.Address.CountryName,
					TownName = car.Address.TownName,
					StreetName = car.Address.StreetName,
				},
				CarDescription = car.Ad.CarDescription
			};

			List<AccessoryViewModel> accessories = await _dbContext.Accessories
				.Select(accessory => new AccessoryViewModel
				{
					AccessoryId = accessory.AccessoryId,
					Name = accessory.Name
				})
				.ToListAsync();

			adViewModel.Accessories = accessories;

			return View(adViewModel);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(AdInformationViewModel adViewModel)
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
