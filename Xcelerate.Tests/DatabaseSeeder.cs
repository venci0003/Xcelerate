using Xcelerate.Infrastructure.Data.Enums;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Tests
{
	public static class DatabaseSeeder
	{
		public static Address firstAddress;

		public static Address secondAddress;

		public static Address thirdAddress;

		public static Address fourthAddress;

		public static IEnumerable<Address> SeedAddresses()
		{
			List<Address> addressesToSeed = new List<Address>();

			firstAddress = new Address()
			{
				AddressId = 1,
				CountryName = "France",
				TownName = "Marseille",
				StreetName = "Rue de la République"
			};
			addressesToSeed.Add(firstAddress);

			secondAddress = new Address()
			{
				AddressId = 2,
				CountryName = "United States",
				TownName = "New York",
				StreetName = "Broadway"
			};
			addressesToSeed.Add(secondAddress);

			thirdAddress = new Address()
			{
				AddressId = 3,
				CountryName = "Bulgaria",
				TownName = "Sofia",
				StreetName = "Vitosha Boulevard"
			};
			addressesToSeed.Add(thirdAddress);

			fourthAddress = new Address()
			{
				AddressId = 4,
				CountryName = "Australia",
				TownName = "Sydney",
				StreetName = "George Street"
			};
			addressesToSeed.Add(fourthAddress);

			return addressesToSeed;
		}

		public static Ad firstAd;

		public static Ad secondAd;

		public static Ad thirdAd;

		public static Ad fourthAd;

		//CHANGE USERIDS
		public static IEnumerable<Ad> SeedAds()
		{
			List<Ad> adsToSeed = new List<Ad>();

			Ad firstAd = new Ad()
			{
				AdId = 1,
				CarId = 1,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				CarDescription = "The 2020 Toyota Camry TRD is a sporty, performance-oriented version of the long-standing mid-size sedan1." +
				" It’s the first Camry that could be construed as \"sporty\".\nPerformance The TRD’s front brake rotors are larger than those on the next-sportiest Camry, the XSE V-6 model, and are squeezed by two-piston calipers instead of single-piston units." +
				" It’s equipped with stiffer springs and larger-diameter anti-roll bars, stiffer underbody braces, and a V-brace behind the rear seats.",
				CreatedOn = "2023-11-08"
			};
			adsToSeed.Add(firstAd);
			//CHANGE USERIDS
			Ad secondAd = new Ad()
			{
				AdId = 2,
				CarId = 2,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				CarDescription = "The 2021 Honda Civic Type R Limited Edition is a high-performance, four-door hatchback that stands out in its class." +
				" Despite its bold and somewhat juvenile bodywork, it offers a transformative driving experience, volcanic acceleration, and is entirely practical for daily use.\r\n\r\nThe car is powered by a 306-hp turbocharged four-cylinder engine and a six-speed manual transmission, making it one of the quickest sport compacts. Honda has managed to virtually eliminate the dreaded torque steer that plagues powerful front-drive cars, providing talkative steering, tremendous cornering grip, and a ride that’s surprisingly smooth",
				CreatedOn = "2019-03-04"
			};
			adsToSeed.Add(secondAd);
			//CHANGE USERIDS
			Ad thirdAd = new Ad()
			{
				AdId = 3,
				CarId = 3,
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				CarDescription = "The 2020 Ford Mustang Shelby GT350R is a powerful, high-strung muscle car designed to rock race tracks while still being at home on the street." +
				" Its special 5.2-liter V-8 engine, code-named Voodoo, makes 526 horsepower and revs to a dizzying 8250 rpm." +
				" The GT350R has been designed to handle cornering at race-track speeds without being too harsh on the street. It’s equipped with a tautly tuned suspension and robust brakes.",
				CreatedOn = "2020-22-01"
			};
			adsToSeed.Add(thirdAd);
			//CHANGE USERIDS
			Ad fourthAd = new Ad()
			{
				AdId = 4,
				CarId = 4,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				CarDescription = "The 2020 Volkswagen Golf TSI is a compact hatchback that offers a blend of performance, comfort, and practicality. It’s powered by a 1.4L Turbo Inline-4 Gas engine that produces 147 horsepower at 5000 rpm and 184 lb-ft of torque at 1400 rpm" +
				". The Golf is fun to drive with well-calibrated transmissions and confident in corners." +
				" It’s not as fast as its sportier GTI counterpart, but it’s still enjoyable to drive.",
				CreatedOn = "2022-18-09"
			};
			adsToSeed.Add(fourthAd);
			//CHANGE USERIDS
			return adsToSeed;
		}

		public static IEnumerable<CarAccessory> SeedCarAccessories()
		{
			List<CarAccessory> carAccessories = new List<CarAccessory>();

			var firstcarAccessories = new List<int> { 8, 14, 3, 19, 10, 2, 7, 16, 5, 11, 20, 4, 18, 13, 9, 6, 1, 12, 17, 15 };
			carAccessories.AddRange(firstcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 1 }));

			var secondcarAccessories = new List<int> { 25, 7, 16, 4, 10, 19, 12, 3, 18, 6, 15, 22, 1, 8, 13, 5, 11, 9, 14, 17 };
			carAccessories.AddRange(secondcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 2 }));

			var thirdcarAccessories = new List<int> { 20, 9, 14, 7, 18, 5, 11, 15, 8, 3, 16, 12, 2, 10, 6, 1, 13, 19, 4, 17 };
			carAccessories.AddRange(thirdcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 3 }));

			var fourthcarAccessories = new List<int> { 25, 6, 14, 33, 9, 41, 18, 3, 11, 36, 28, 7, 22, 15, 30, 8, 13, 45, 2, 39 };
			carAccessories.AddRange(fourthcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 4 }));

			return carAccessories;
		}

		public static Car firstCar;

		public static Car secondCar;

		public static Car thirdCar;

		public static Car fourthCar;

		public static IEnumerable<Car> SeedCars()
		{
			List<Car> cars = new List<Car>();

			Car firstCar = new Car()
			{
				CarId = 1,
				Brand = BrandsEnum.BMW,
				Model = "M5 Competition",
				Year = 2022,
				IsForSale = true,
				EngineId = 1,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1850.8m,
				Mileage = 0,
				Price = 110000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 1,
				AddressId = 1,
				AdId = 1,
				UserId = Guid.NewGuid()
			};
			cars.Add(firstCar);

			Car secondCar = new Car()
			{
				CarId = 2,
				Brand = BrandsEnum.MercedesBenz,
				Model = "E63 AMG",
				Year = 2023,
				IsForSale = true,
				EngineId = 2,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Blue,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 1980.6m,
				Mileage = 0,
				Price = 120000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 2,
				AddressId = 2,
				AdId = 2,
				UserId = Guid.NewGuid()
			};
			cars.Add(secondCar);

			Car thirdCar = new Car()
			{
				CarId = 3,
				Brand = BrandsEnum.Audi,
				Model = "RS7",
				Year = 2022,
				IsForSale = true,
				EngineId = 3,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 2060.4m,
				Mileage = 20000,
				Price = 130000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 3,
				AddressId = 3,
				AdId = 3,
				UserId = Guid.NewGuid()
			};
			cars.Add(thirdCar);

			Car fourthCar = new Car()
			{
				CarId = 4,
				Brand = BrandsEnum.Chevrolet,
				Model = "Corvette",
				Year = 2023,
				IsForSale = true,
				EngineId = 4,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.SlateGray,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 2250.2m,
				Mileage = 12000,
				Price = 140000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 4,
				AddressId = 4,
				AdId = 4,
				UserId = Guid.NewGuid()
			};
			cars.Add(fourthCar);

			return cars;

		}

		public static IEnumerable<Engine> SeedEngines()
		{
			List<Engine> engines = new List<Engine>();

			Engine engineOne = new Engine()
			{
				EngineId = 1,
				Model = "V6",
				Horsepower = 301,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineOne);

			Engine engineTwo = new Engine()
			{
				EngineId = 2,
				Model = "In-Line 4-Cylinder with Turbocharger",
				Horsepower = 306,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineTwo);

			Engine engineThree = new Engine()
			{
				EngineId = 3,
				Model = "5.2-liter V-8 engine",
				Horsepower = 526,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineThree);

			Engine engineFour = new Engine()
			{
				EngineId = 4,
				Model = "1.4L Turbo Inline-4",
				Horsepower = 147,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineFour);

			return engines;
		}
	}
}
