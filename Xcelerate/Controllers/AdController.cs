using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Controllers
{
    public class AdController : Controller
    {
        private readonly XcelerateContext _dbContext;

        public AdController(XcelerateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cars = _dbContext.Cars
       .Include(car => car.Engine)
       .Include(car => car.Images)
       .ToList();

            // Map Car entities to AdViewModel
            var adViewModels = cars.Select(car => new AdPreviewViewModel
            {
                CarId = car.CarId,
                ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Engine = car.Engine.Model, 
                Condition = car.Condition,
                EuroStandard = car.EuroStandard,
                FuelType = car.FuelType,
                Price = car.Price,
            }).ToList();

            return View(adViewModels);
        }


        public IActionResult Information(int? carId)
        {
            var car = _dbContext.Cars
                .Include(c => c.Engine)
                .Include(c => c.Images)
                .Include(c => c.Manufacturer)
                .Include(c => c.Address)
                .Include(c => c.Ad)
                .Include(c => c.User)
                .Include(c => c.Accessories)
                .FirstOrDefault(c => c.CarId == carId);

            if (car == null)
            {
                // Handle the case where the car with the specified CarId is not found
                return NotFound();
            }

            var adViewModel = new AdInformationViewModel
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
            };

            return View(adViewModel);
        }

		public IActionResult Create()
        {
            return View();
        }
	}
}
