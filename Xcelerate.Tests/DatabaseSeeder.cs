
namespace Xcelerate.Tests
{
	using Infrastructure.Data;
	using Infrastructure.Data.Enums;
	using Infrastructure.Data.Models;
	public static class DatabaseSeeder
	{

		public static void SeedDatabase(XcelerateContext xcelerateContext)
		{
			xcelerateContext.Addresses.AddRange(SeedAddresses());
			xcelerateContext.Ads.AddRange(SeedAds());
			xcelerateContext.CarAccessories.AddRange(SeedCarAccessories());
			xcelerateContext.Cars.AddRange(SeedCars());
			xcelerateContext.Engines.AddRange(SeedEngines());
			xcelerateContext.Manufacturers.AddRange(SeedManufacturers());
			xcelerateContext.NewsData.AddRange(SeedNews());
			xcelerateContext.Reviews.AddRange(SeedReviews());
			//xcelerateContext.RoomBasis.AddRange(SeedRoomBasis());
			//xcelerateContext.Pictures.Add(new Picture() { Id = 1, Path = "test/path", HotelId = 2, IsDeleted = false });
			xcelerateContext.SaveChanges();
		}
		public static Address firstAddress;

		public static Address secondAddress;

		public static Address thirdAddress;

		public static Address fourthAddress;

		public static IEnumerable<Address> SeedAddresses()
		{
			List<Address> addressesToSeed = new List<Address>();

			firstAddress = new Address()
			{
				AddressId = 100,
				CountryName = "France",
				TownName = "Marseille",
				StreetName = "Rue de la République"
			};
			addressesToSeed.Add(firstAddress);

			secondAddress = new Address()
			{
				AddressId = 200,
				CountryName = "United States",
				TownName = "New York",
				StreetName = "Broadway"
			};
			addressesToSeed.Add(secondAddress);

			thirdAddress = new Address()
			{
				AddressId = 300,
				CountryName = "Bulgaria",
				TownName = "Sofia",
				StreetName = "Vitosha Boulevard"
			};
			addressesToSeed.Add(thirdAddress);

			fourthAddress = new Address()
			{
				AddressId = 400,
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

			firstAd = new Ad()
			{
				AdId = 100,
				CarId = 100,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				CarDescription = "The 2020 Toyota Camry TRD is a sporty, performance-oriented version of the long-standing mid-size sedan1." +
			   " It’s the first Camry that could be construed as \"sporty\".\nPerformance The TRD’s front brake rotors are larger than those on the next-sportiest Camry, the XSE V-6 model, and are squeezed by two-piston calipers instead of single-piston units." +
			   " It’s equipped with stiffer springs and larger-diameter anti-roll bars, stiffer underbody braces, and a V-brace behind the rear seats.",
				CreatedOn = "2023-11-08"
			};
			adsToSeed.Add(firstAd);
			//CHANGE USERIDS
			secondAd = new Ad()
			{
				AdId = 200,
				CarId = 200,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				CarDescription = "The 2021 Honda Civic Type R Limited Edition is a high-performance, four-door hatchback that stands out in its class." +
			   " Despite its bold and somewhat juvenile bodywork, it offers a transformative driving experience, volcanic acceleration, and is entirely practical for daily use.\r\n\r\nThe car is powered by a 306-hp turbocharged four-cylinder engine and a six-speed manual transmission, making it one of the quickest sport compacts. Honda has managed to virtually eliminate the dreaded torque steer that plagues powerful front-drive cars, providing talkative steering, tremendous cornering grip, and a ride that’s surprisingly smooth",
				CreatedOn = "2019-03-04"
			};
			adsToSeed.Add(secondAd);
			//CHANGE USERIDS
			thirdAd = new Ad()
			{
				AdId = 300,
				CarId = 300,
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				CarDescription = "The 2020 Ford Mustang Shelby GT350R is a powerful, high-strung muscle car designed to rock race tracks while still being at home on the street." +
			   " Its special 5.2-liter V-8 engine, code-named Voodoo, makes 526 horsepower and revs to a dizzying 8250 rpm." +
			   " The GT350R has been designed to handle cornering at race-track speeds without being too harsh on the street. It’s equipped with a tautly tuned suspension and robust brakes.",
				CreatedOn = "2020-22-01"
			};
			adsToSeed.Add(thirdAd);
			//CHANGE USERIDS
			fourthAd = new Ad()
			{
				AdId = 400,
				CarId = 400,
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
			carAccessories.AddRange(firstcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 100 }));

			var secondcarAccessories = new List<int> { 25, 7, 16, 4, 10, 19, 12, 3, 18, 6, 15, 22, 1, 8, 13, 5, 11, 9, 14, 17 };
			carAccessories.AddRange(secondcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 200 }));

			var thirdcarAccessories = new List<int> { 20, 9, 14, 7, 18, 5, 11, 15, 8, 3, 16, 12, 2, 10, 6, 1, 13, 19, 4, 17 };
			carAccessories.AddRange(thirdcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 300 }));

			var fourthcarAccessories = new List<int> { 25, 6, 14, 33, 9, 41, 18, 3, 11, 36, 28, 7, 22, 15, 30, 8, 13, 45, 2, 39 };
			carAccessories.AddRange(fourthcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 400 }));

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
				CarId = 100,
				Brand = BrandsEnum.BMW,
				Model = "M5 Competition",
				Year = 2022,
				IsForSale = true,
				EngineId = 100,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1850.8m,
				Mileage = 0,
				Price = 110000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 100,
				AddressId = 100,
				AdId = 100,
				UserId = Guid.NewGuid()
			};
			cars.Add(firstCar);

			Car secondCar = new Car()
			{
				CarId = 200,
				Brand = BrandsEnum.MercedesBenz,
				Model = "E63 AMG",
				Year = 2023,
				IsForSale = true,
				EngineId = 200,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Blue,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 1980.6m,
				Mileage = 0,
				Price = 120000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 200,
				AddressId = 200,
				AdId = 200,
				UserId = Guid.NewGuid()
			};
			cars.Add(secondCar);

			Car thirdCar = new Car()
			{
				CarId = 300,
				Brand = BrandsEnum.Audi,
				Model = "RS7",
				Year = 2022,
				IsForSale = true,
				EngineId = 300,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 2060.4m,
				Mileage = 20000,
				Price = 130000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 300,
				AddressId = 300,
				AdId = 300,
				UserId = Guid.NewGuid()
			};
			cars.Add(thirdCar);

			Car fourthCar = new Car()
			{
				CarId = 400,
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
				ManufacturerId = 400,
				AddressId = 400,
				AdId = 400,
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
				EngineId = 100,
				Model = "V6",
				Horsepower = 301,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineOne);

			Engine engineTwo = new Engine()
			{
				EngineId = 200,
				Model = "In-Line 4-Cylinder with Turbocharger",
				Horsepower = 306,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineTwo);

			Engine engineThree = new Engine()
			{
				EngineId = 300,
				Model = "5.2-liter V-8 engine",
				Horsepower = 526,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineThree);

			Engine engineFour = new Engine()
			{
				EngineId = 400,
				Model = "1.4L Turbo Inline-4",
				Horsepower = 147,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineFour);

			return engines;
		}

		public static IEnumerable<Image> SeedImages()
		{
			List<Image> imageCollections = new List<Image>();

			// Car 1
			imageCollections!.Add(new Image() { CarId = 100, ImageId = 100, ImageUrl = "2020_toyota_camry_trd_1.jpg" });
			imageCollections!.Add(new Image() { CarId = 100, ImageId = 200, ImageUrl = "2020_toyota_camry_trd_3.jpg" });
			imageCollections!.Add(new Image() { CarId = 100, ImageId = 300, ImageUrl = "2020_toyota_camry_trd_5.jpg" });
			imageCollections!.Add(new Image() { CarId = 100, ImageId = 400, ImageUrl = "2020_toyota_camry_trd_6.jpg" });
			imageCollections!.Add(new Image() { CarId = 100, ImageId = 500, ImageUrl = "2020_toyota_camry_trd_7.jpg" });
			imageCollections!.Add(new Image() { CarId = 100, ImageId = 600, ImageUrl = "2020_toyota_camry_trd_11.jpg" });

			// Car 2
			imageCollections!.Add(new Image() { CarId = 200, ImageId = 700, ImageUrl = "2021_honda_civic_type_r_limited_edition.jpg" });
			imageCollections!.Add(new Image() { CarId = 200, ImageId = 800, ImageUrl = "2021_honda_civic_type_r_limited_edition_2.jpg" });
			imageCollections!.Add(new Image() { CarId = 200, ImageId = 900, ImageUrl = "2021_honda_civic_type_r_limited_edition_3.jpg" });
			imageCollections!.Add(new Image() { CarId = 200, ImageId = 1000, ImageUrl = "2021_honda_civic_type_r_limited_edition_4.jpg" });
			imageCollections!.Add(new Image() { CarId = 200, ImageId = 1100, ImageUrl = "2021_honda_civic_type_r_limited_edition_5.jpg" });
			imageCollections!.Add(new Image() { CarId = 200, ImageId = 1200, ImageUrl = "2021_honda_civic_type_r_limited_edition_11.jpg" });

			// Car 3
			imageCollections!.Add(new Image() { CarId = 300, ImageId = 1300, ImageUrl = "2020_ford_mustang_shelby_gt350r.jpg" });
			imageCollections!.Add(new Image() { CarId = 300, ImageId = 1400, ImageUrl = "2020_ford_mustang_shelby_gt350r_1.jpg" });
			imageCollections!.Add(new Image() { CarId = 300, ImageId = 1500, ImageUrl = "2020_ford_mustang_shelby_gt350r_2.jpg" });
			imageCollections!.Add(new Image() { CarId = 300, ImageId = 1600, ImageUrl = "2020_ford_mustang_shelby_gt350r_3.jpg" });
			imageCollections!.Add(new Image() { CarId = 300, ImageId = 1700, ImageUrl = "2020_ford_mustang_shelby_gt350r_5.jpg" });
			imageCollections!.Add(new Image() { CarId = 300, ImageId = 1800, ImageUrl = "2020_ford_mustang_shelby_gt350r_7.jpg" });


			// Car 4
			imageCollections!.Add(new Image() { CarId = 400, ImageId = 1900, ImageUrl = "2020_volkswagen_golf.jpg" });
			imageCollections!.Add(new Image() { CarId = 400, ImageId = 2000, ImageUrl = "2020_volkswagen_golf_47.jpg" });
			imageCollections!.Add(new Image() { CarId = 400, ImageId = 2100, ImageUrl = "2020_volkswagen_golf_48.jpg" });
			imageCollections!.Add(new Image() { CarId = 400, ImageId = 2200, ImageUrl = "2020_volkswagen_golf_50.jpg" });
			imageCollections!.Add(new Image() { CarId = 400, ImageId = 2300, ImageUrl = "2020_volkswagen_golf_51.jpg" });
			imageCollections!.Add(new Image() { CarId = 400, ImageId = 2400, ImageUrl = "2020_volkswagen_golf_23.jpg" });

			return imageCollections;
		}

		public static IEnumerable<Manufacturer> SeedManufacturers()
		{
			List<Manufacturer> manufacturers = new List<Manufacturer>();

			Manufacturer manufacturerOne = new Manufacturer()
			{
				ManufacturerId = 100,
				Name = "BMW"
			};
			manufacturers.Add(manufacturerOne);

			Manufacturer manufacturerTwo = new Manufacturer()
			{
				ManufacturerId = 200,
				Name = "MercedesBenz"
			};
			manufacturers.Add(manufacturerTwo);

			Manufacturer manufacturerThree = new Manufacturer()
			{
				ManufacturerId = 300,
				Name = "Audi"
			};
			manufacturers.Add(manufacturerThree);

			Manufacturer manufacturerFour = new Manufacturer()
			{
				ManufacturerId = 400,
				Name = "Chevrolet"
			};
			manufacturers.Add(manufacturerFour);

			return manufacturers;
		}

		public static IEnumerable<News> SeedNews()
		{
			List<News> news = new List<News>();

			News newsOne = new News()
			{
				NewsId = 100,
				Title = "Driving Forward: Accelerating into the Future of Mobility",
				Content = "Explore the dynamic landscape of mobility solutions, from ride-sharing advancements to urban transport innovations." +
				" Delve into the latest trends shaping the way we move and discover how technology is reshaping the concept of transportation as we know it."
			};
			news.Add(newsOne);

			News newsTwo = new News()
			{
				NewsId = 200,
				Title = "Revolutionizing the Road: The Rise of Electric Vehicles",
				Content = "Discover the electrifying revolution sweeping through the automotive world as electric vehicles take center stage." +
				" From Tesla's latest models to emerging EV startups, uncover the driving force behind the shift towards sustainable transportation."
			};
			news.Add(newsTwo);

			News newsThree = new News()
			{
				NewsId = 300,
				Title = "Beyond the Horizon: Exploring the Future of Autonomous Cars",
				Content = "Step into the world of autonomous driving and discover the transformative potential of self-driving technology." +
				" From AI-powered navigation systems to advanced sensor technology, explore the journey towards a safer and more efficient driving experience."
			};
			news.Add(newsThree);

			News newsFour = new News()
			{
				NewsId = 400,
				Title = "Designing Tomorrow: The Art and Science of Automotive Styling",
				Content = "Delve into the captivating world of automotive design and uncover the fusion of artistry and engineering shaping the cars of tomorrow." +
				" From iconic classics to futuristic concepts, explore the evolution of automotive styling through the ages.\r\n"
			};
			news.Add(newsFour);

			return news;
		}

		public static Review firstCarFirstReview;

		public static Review secondCarFirstReview;

		public static Review thirdCarFirstReview;

		public static Review fourthCarFirstReview;

		public static IEnumerable<Review> SeedReviews()
		{
			List<Review> reviews = new List<Review>();

			firstCarFirstReview = new Review()
			{
				ReviewId = 100,
				Comment = "Love the sporty feel of my Toyota Camry TRD!" +
			   " The handling is superb, and the interior is stylish." +
			   " The TRD enhancements really add a punch." +
			   " A great choice for those seeking a blend of performance and comfort.",
				StarsCount = 5,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				AdId = 100
			};
			reviews.Add(firstCarFirstReview);

			secondCarFirstReview = new Review()
			{
				ReviewId = 600,
				Comment = "The Honda Civic Type R is an absolute blast to drive!" +
			  " Its turbocharged engine delivers exhilarating performance, and the sharp handling makes every corner a joy." +
			  " The aggressive styling sets it apart from the crowd. Highly recommended!",
				StarsCount = 5,
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				AdId = 200
			};
			reviews.Add(secondCarFirstReview);

			thirdCarFirstReview = new Review()
			{
				ReviewId = 1100,
				Comment = "The Ford Mustang GT350R is a true performance machine!" +
			   " Its V8 engine roars with power, and the precise handling makes every drive exhilarating." +
			   " The aggressive styling and track-focused features set it apart." +
			   " A must-have for any enthusiast!",
				StarsCount = 5,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				AdId = 300
			};
			reviews.Add(thirdCarFirstReview);

			fourthCarFirstReview = new Review()
			{
				ReviewId = 1600,
				Comment = "The Golf is a versatile and practical hatchback." +
			   " Its fuel-efficient engine delivers impressive performance, and the handling is nimble around city streets." +
			   " The interior is well-built and spacious, making it a great choice for daily commuting or weekend getaways.",
				StarsCount = 5,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 400
			};
			reviews.Add(fourthCarFirstReview);

			return reviews;
		}
	}
}
