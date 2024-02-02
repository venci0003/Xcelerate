using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Xcelerate.Core.Models.Ad;
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
					var userId = "C10F4EB6-EB46-453E-7ADE-08DC240767C7";
					// Map the ViewModel to your Car model
					var car = new Car
					{
						UserId = Guid.Parse(userId),
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
							UserId = Guid.Parse(userId),
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
	}
}
