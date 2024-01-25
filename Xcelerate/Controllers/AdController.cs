using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Xcelerate.Controllers
{
	public class AdController : Controller
	{
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public AdController(XcelerateContext dbContext , IWebHostEnvironment webHostEnvironment)
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
			}).ToListAsync();

			return View(cars);
		}


		public async Task<IActionResult> Information(int? carId)
		{

			var car = await _dbContext.Cars.Where(c => c.CarId == carId).Select(car => new AdInformationViewModel
			{
				ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
				Accessories = car.Accessories.Select(accessory => new AccessoryViewModel
				{
					GpsTrackingSystem = accessory.GpsTrackingSystem,
					AutomaticStabilityControl = accessory.AutomaticStabilityControl,
					AdaptiveHeadlights = accessory.AdaptiveHeadlights,
					Abs = accessory.Abs,
					RearAirbags = accessory.RearAirbags,
					FrontAirbags = accessory.FrontAirbags,
					SideAirbags = accessory.SideAirbags,
					Ebd = accessory.Ebd,
					Esp = accessory.Esp,
					Tpms = accessory.Tpms,
					Parktronic = accessory.Parktronic,
					Isofix = accessory.Isofix,
					DynamicStabilityControl = accessory.DynamicStabilityControl,
					Tcs = accessory.Tcs,
					DistanceControlSystem = accessory.DistanceControlSystem,
					DescentControlSystem = accessory.DescentControlSystem,
					Bas = accessory.Bas,
					AutoStartStopFunction = accessory.AutoStartStopFunction,
					BluetoothHandsfreeSystem = accessory.BluetoothHandsfreeSystem,
					DvdTv = accessory.DvdTv,
					SteptronicTiptronic = accessory.SteptronicTiptronic,
					UsbAudioVideoInAuxOutputs = accessory.UsbAudioVideoInAuxOutputs,
					AdaptiveAirSuspension = accessory.AdaptiveAirSuspension,
					KeylessIgnition = accessory.KeylessIgnition,
					DifferentialLock = accessory.DifferentialLock,
					OnBoardComputer = accessory.OnBoardComputer,
					LightSensor = accessory.LightSensor,
					ElectricMirrors = accessory.ElectricMirrors,
					ElectricGlass = accessory.ElectricGlass,
					ElectricSuspensionAdjustment = accessory.ElectricSuspensionAdjustment,
					ElectricSeatAdjustment = accessory.ElectricSeatAdjustment,
					ElectricPowerSteering = accessory.ElectricPowerSteering,
					AirConditioner = accessory.AirConditioner,
					Climatronic = accessory.Climatronic,
					MultifunctionSteeringWheel = accessory.MultifunctionSteeringWheel,
					NavigationSystem = accessory.NavigationSystem,
					SteeringWheelHeating = accessory.SteeringWheelHeating,
					WindshieldHeating = accessory.WindshieldHeating,
					SeatHeating = accessory.SeatHeating,
					SteeringWheelAdjustment = accessory.SteeringWheelAdjustment,
					RainSensor = accessory.RainSensor,
					PowerSteering = accessory.PowerSteering,
					HeadlampWashSystem = accessory.HeadlampWashSystem,
					CruiseControlSystem = accessory.CruiseControlSystem,
					StereoSystem = accessory.StereoSystem,
					CoolingGlovebox = accessory.CoolingGlovebox,
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
				Description = car.Ad.CarDescription
			}).FirstOrDefaultAsync();

			if (car == null)
			{
				// Handle the case where the car with the specified CarId is not found
				return NotFound();
			}

			return View(car);
		}

		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create(AdInformationViewModel adViewModel, List<IFormFile> Images)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Map the ViewModel to your Car model
					var car = new Car
					{
						// Map properties from ViewModel to Model
						Brand = adViewModel.Brand,
						Model = adViewModel.Model,
						Year = adViewModel.Year,
						Engine = new Engine { Model = adViewModel.Engine },
						// Map other properties as needed
					};

					if (Images.Count != 6)
					{
						ModelState.AddModelError("Images", "Please upload exactly 6 images.");
						return View(adViewModel);
					}

					// Save car to the database
					_dbContext.Cars.Add(car);
					await _dbContext.SaveChangesAsync();

					var adId = car.CarId; // Assuming there's an identifier for the ad (replace with the actual property)
					var adImagesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad");


					foreach (var image in Images)
					{
						if (image != null && image.Length > 0)
						{
							var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
							var filePath = Path.Combine(adImagesDirectory, uniqueFileName);
							image.CopyTo(new FileStream(filePath, FileMode.Create));
						}
					}

					return RedirectToAction("Index", "Ad");  // Redirect to the desired action after successful creation
				}
				catch (Exception ex)
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
