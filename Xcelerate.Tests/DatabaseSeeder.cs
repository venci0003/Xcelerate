
namespace Xcelerate.Tests
{
	using Infrastructure.Data;
	using Infrastructure.Data.Enums;
	using Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;

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
			xcelerateContext.Users.AddRange(SeedUsers());
			var imageCollection = SeedImages();
			xcelerateContext.Accessories.AddRange(SeedAccesories());

			xcelerateContext.Images.AddRange(imageCollection);
			xcelerateContext.SaveChanges();

		}

		public static IEnumerable<Image> SeedImages()
		{
			List<Image> imageCollections = new List<Image>();

			imageCollections!.Add(new Image() { CarId = 1, ImageId = 1, ImageUrl = "2020_toyota_camry_trd_1.jpg" });
			imageCollections!.Add(new Image() { CarId = 2, ImageId = 2, ImageUrl = "2020_toyota_camry_trd_3.jpg" });
			imageCollections!.Add(new Image() { CarId = 1, ImageId = 3, ImageUrl = "2020_toyota_camry_trd_5.jpg" });
			imageCollections!.Add(new Image() { CarId = 1, ImageId = 4, ImageUrl = "2020_toyota_camry_trd_6.jpg" });
			imageCollections!.Add(new Image() { CarId = 1, ImageId = 5, ImageUrl = "2020_toyota_camry_trd_7.jpg" });
			imageCollections!.Add(new Image() { CarId = 1, ImageId = 6, ImageUrl = "2020_toyota_camry_trd_11.jpg" });

			imageCollections!.Add(new Image() { CarId = 2, ImageId = 7, ImageUrl = "2021_honda_civic_type_r_limited_edition.jpg" });
			imageCollections!.Add(new Image() { CarId = 2, ImageId = 8, ImageUrl = "2021_honda_civic_type_r_limited_edition_2.jpg" });
			imageCollections!.Add(new Image() { CarId = 2, ImageId = 9, ImageUrl = "2021_honda_civic_type_r_limited_edition_3.jpg" });
			imageCollections!.Add(new Image() { CarId = 2, ImageId = 10, ImageUrl = "2021_honda_civic_type_r_limited_edition_4.jpg" });
			imageCollections!.Add(new Image() { CarId = 2, ImageId = 11, ImageUrl = "2021_honda_civic_type_r_limited_edition_5.jpg" });
			imageCollections!.Add(new Image() { CarId = 2, ImageId = 12, ImageUrl = "2021_honda_civic_type_r_limited_edition_11.jpg" });

			imageCollections!.Add(new Image() { CarId = 3, ImageId = 13, ImageUrl = "2020_ford_mustang_shelby_gt350r.jpg" });
			imageCollections!.Add(new Image() { CarId = 3, ImageId = 14, ImageUrl = "2020_ford_mustang_shelby_gt350r_1.jpg" });
			imageCollections!.Add(new Image() { CarId = 3, ImageId = 15, ImageUrl = "2020_ford_mustang_shelby_gt350r_2.jpg" });
			imageCollections!.Add(new Image() { CarId = 3, ImageId = 16, ImageUrl = "2020_ford_mustang_shelby_gt350r_3.jpg" });
			imageCollections!.Add(new Image() { CarId = 3, ImageId = 17, ImageUrl = "2020_ford_mustang_shelby_gt350r_5.jpg" });
			imageCollections!.Add(new Image() { CarId = 3, ImageId = 18, ImageUrl = "2020_ford_mustang_shelby_gt350r_7.jpg" });

			imageCollections!.Add(new Image() { CarId = 4, ImageId = 19, ImageUrl = "2020_volkswagen_golf.jpg" });
			imageCollections!.Add(new Image() { CarId = 4, ImageId = 20, ImageUrl = "2020_volkswagen_golf_47.jpg" });
			imageCollections!.Add(new Image() { CarId = 4, ImageId = 21, ImageUrl = "2020_volkswagen_golf_48.jpg" });
			imageCollections!.Add(new Image() { CarId = 4, ImageId = 22, ImageUrl = "2020_volkswagen_golf_50.jpg" });
			imageCollections!.Add(new Image() { CarId = 4, ImageId = 23, ImageUrl = "2020_volkswagen_golf_51.jpg" });
			imageCollections!.Add(new Image() { CarId = 4, ImageId = 24, ImageUrl = "2020_volkswagen_golf_23.jpg" });

			return imageCollections;
		}

		public static User firstUser;

		public static User secondUser;

		public static User thirdUser;

		public static User fourthUser;

		public static IEnumerable<User> SeedUsers()
		{
			List<User> users = new List<User>();
			PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

			firstUser = new User()
			{
				Id = Guid.Parse("8ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				FirstName = "Ava",
				LastName = "Simson",
				Email = "ava.simson@example.com"
			};
			firstUser.PasswordHash = passwordHasher.HashPassword(firstUser, "8vX&3gZ!7qR");
			users.Add(firstUser);

			secondUser = new User()
			{
				Id = Guid.Parse("3CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				FirstName = "Rob",
				LastName = "Hanson",
				Email = "rob.hanson@example.com"
			};
			secondUser.PasswordHash = passwordHasher.HashPassword(secondUser, "K@8z6#Vc0&Y");
			users.Add(secondUser);

			thirdUser = new User()
			{
				Id = Guid.Parse("7A31BB92-7EC2-45E3-81A8-912542B314C6"),
				FirstName = "Charles",
				LastName = "Baker",
				Email = "charles.baker@example.com"
			};
			thirdUser.PasswordHash = passwordHasher.HashPassword(thirdUser, "Z5!u8$Xp6^Z");
			users.Add(thirdUser);

			fourthUser = new User()
			{
				Id = Guid.Parse("595CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				FirstName = "Dave",
				LastName = "Black",
				Email = "dave.black@example.com"
			};
			fourthUser.PasswordHash = passwordHasher.HashPassword(fourthUser, "N3^y7#Bn9*V");
			users.Add(fourthUser);

			return users;
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

			firstAd = new Ad()
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
			secondAd = new Ad()
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
			thirdAd = new Ad()
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
			fourthAd = new Ad()
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
				Mileage = 1000,
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

		//public static IEnumerable<Image> SeedImages()
		//{
		//	List<Image> imageCollections = new List<Image>();

		//	// Car 1
		//	imageCollections!.Add(new Image() { CarId = 100, ImageId = 100, ImageUrl = "2020_toyota_camry_trd_1.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 100, ImageId = 200, ImageUrl = "2020_toyota_camry_trd_3.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 100, ImageId = 300, ImageUrl = "2020_toyota_camry_trd_5.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 100, ImageId = 400, ImageUrl = "2020_toyota_camry_trd_6.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 100, ImageId = 500, ImageUrl = "2020_toyota_camry_trd_7.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 100, ImageId = 600, ImageUrl = "2020_toyota_camry_trd_11.jpg" });

		//	// Car 2
		//	imageCollections!.Add(new Image() { CarId = 200, ImageId = 700, ImageUrl = "2021_honda_civic_type_r_limited_edition.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 200, ImageId = 800, ImageUrl = "2021_honda_civic_type_r_limited_edition_2.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 200, ImageId = 900, ImageUrl = "2021_honda_civic_type_r_limited_edition_3.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 200, ImageId = 1000, ImageUrl = "2021_honda_civic_type_r_limited_edition_4.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 200, ImageId = 1100, ImageUrl = "2021_honda_civic_type_r_limited_edition_5.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 200, ImageId = 1200, ImageUrl = "2021_honda_civic_type_r_limited_edition_11.jpg" });

		//	// Car 3
		//	imageCollections!.Add(new Image() { CarId = 300, ImageId = 1300, ImageUrl = "2020_ford_mustang_shelby_gt350r.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 300, ImageId = 1400, ImageUrl = "2020_ford_mustang_shelby_gt350r_1.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 300, ImageId = 1500, ImageUrl = "2020_ford_mustang_shelby_gt350r_2.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 300, ImageId = 1600, ImageUrl = "2020_ford_mustang_shelby_gt350r_3.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 300, ImageId = 1700, ImageUrl = "2020_ford_mustang_shelby_gt350r_5.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 300, ImageId = 1800, ImageUrl = "2020_ford_mustang_shelby_gt350r_7.jpg" });


		//	// Car 4
		//	imageCollections!.Add(new Image() { CarId = 400, ImageId = 1900, ImageUrl = "2020_volkswagen_golf.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 400, ImageId = 2000, ImageUrl = "2020_volkswagen_golf_47.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 400, ImageId = 2100, ImageUrl = "2020_volkswagen_golf_48.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 400, ImageId = 2200, ImageUrl = "2020_volkswagen_golf_50.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 400, ImageId = 2300, ImageUrl = "2020_volkswagen_golf_51.jpg" });
		//	imageCollections!.Add(new Image() { CarId = 400, ImageId = 2400, ImageUrl = "2020_volkswagen_golf_23.jpg" });

		//	return imageCollections;
		//}

		public static IEnumerable<Manufacturer> SeedManufacturers()
		{
			List<Manufacturer> manufacturers = new List<Manufacturer>();

			Manufacturer manufacturerOne = new Manufacturer()
			{
				ManufacturerId = 1,
				Name = "BMW"
			};
			manufacturers.Add(manufacturerOne);

			Manufacturer manufacturerTwo = new Manufacturer()
			{
				ManufacturerId = 2,
				Name = "MercedesBenz"
			};
			manufacturers.Add(manufacturerTwo);

			Manufacturer manufacturerThree = new Manufacturer()
			{
				ManufacturerId = 3,
				Name = "Audi"
			};
			manufacturers.Add(manufacturerThree);

			Manufacturer manufacturerFour = new Manufacturer()
			{
				ManufacturerId = 4,
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
				NewsId = 1,
				Title = "Driving Forward: Accelerating into the Future of Mobility",
				Content = "Explore the dynamic landscape of mobility solutions, from ride-sharing advancements to urban transport innovations." +
				" Delve into the latest trends shaping the way we move and discover how technology is reshaping the concept of transportation as we know it."
			};
			news.Add(newsOne);

			News newsTwo = new News()
			{
				NewsId = 2,
				Title = "Revolutionizing the Road: The Rise of Electric Vehicles",
				Content = "Discover the electrifying revolution sweeping through the automotive world as electric vehicles take center stage." +
				" From Tesla's latest models to emerging EV startups, uncover the driving force behind the shift towards sustainable transportation."
			};
			news.Add(newsTwo);

			News newsThree = new News()
			{
				NewsId = 3,
				Title = "Beyond the Horizon: Exploring the Future of Autonomous Cars",
				Content = "Step into the world of autonomous driving and discover the transformative potential of self-driving technology." +
				" From AI-powered navigation systems to advanced sensor technology, explore the journey towards a safer and more efficient driving experience."
			};
			news.Add(newsThree);

			News newsFour = new News()
			{
				NewsId = 4,
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
				ReviewId = 1,
				Comment = "Love the sporty feel of my Toyota Camry TRD!" +
			   " The handling is superb, and the interior is stylish." +
			   " The TRD enhancements really add a punch." +
			   " A great choice for those seeking a blend of performance and comfort.",
				StarsCount = 5,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				AdId = 1
			};
			reviews.Add(firstCarFirstReview);

			secondCarFirstReview = new Review()
			{
				ReviewId = 6,
				Comment = "The Honda Civic Type R is an absolute blast to drive!" +
			  " Its turbocharged engine delivers exhilarating performance, and the sharp handling makes every corner a joy." +
			  " The aggressive styling sets it apart from the crowd. Highly recommended!",
				StarsCount = 5,
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				AdId = 2
			};
			reviews.Add(secondCarFirstReview);

			thirdCarFirstReview = new Review()
			{
				ReviewId = 11,
				Comment = "The Ford Mustang GT350R is a true performance machine!" +
			   " Its V8 engine roars with power, and the precise handling makes every drive exhilarating." +
			   " The aggressive styling and track-focused features set it apart." +
			   " A must-have for any enthusiast!",
				StarsCount = 5,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				AdId = 3
			};
			reviews.Add(thirdCarFirstReview);

			fourthCarFirstReview = new Review()
			{
				ReviewId = 16,
				Comment = "The Golf is a versatile and practical hatchback." +
			   " Its fuel-efficient engine delivers impressive performance, and the handling is nimble around city streets." +
			   " The interior is well-built and spacious, making it a great choice for daily commuting or weekend getaways.",
				StarsCount = 5,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 4
			};
			reviews.Add(fourthCarFirstReview);

			return reviews;
		}

		public static IEnumerable<Accessory> SeedAccesories()
		{
			List<Accessory> accessories = new List<Accessory>();

			Accessory firstAccessory = new Accessory
			{
				AccessoryId = 1,
				Name = "GpsTrackingSystem"
			};
			accessories.Add(firstAccessory);

			Accessory secondAccessory = new Accessory
			{
				AccessoryId = 2,
				Name = "AutomaticStabilityControl"
			};
			accessories.Add(secondAccessory);

			Accessory thirdAccessory = new Accessory
			{
				AccessoryId = 3,
				Name = "AdaptiveHeadlights"
			};
			accessories.Add(thirdAccessory);

			Accessory fourthAccessory = new Accessory
			{
				AccessoryId = 4,
				Name = "Abs"
			};
			accessories.Add(fourthAccessory);

			Accessory fifthAccessory = new Accessory
			{
				AccessoryId = 5,
				Name = "RearAirbags"
			};
			accessories.Add(fifthAccessory);

			Accessory sixthAccessory = new Accessory
			{
				AccessoryId = 6,
				Name = "FrontAirbags"
			};
			accessories.Add(sixthAccessory);

			Accessory seventhAccessory = new Accessory
			{
				AccessoryId = 7,
				Name = "SideAirbags"
			};
			accessories.Add(seventhAccessory);

			Accessory eighthAccessory = new Accessory
			{
				AccessoryId = 8,
				Name = "Ebd"
			};
			accessories.Add(eighthAccessory);

			Accessory ninthAccessory = new Accessory
			{
				AccessoryId = 9,
				Name = "Esp"
			};
			accessories.Add(ninthAccessory);

			Accessory tenthAccessory = new Accessory
			{
				AccessoryId = 10,
				Name = "Tpms"
			};
			accessories.Add(tenthAccessory);

			Accessory eleventhAccessory = new Accessory
			{
				AccessoryId = 11,
				Name = "Parktronic"
			};
			accessories.Add(eleventhAccessory);

			Accessory twelfthAccessory = new Accessory
			{
				AccessoryId = 12,
				Name = "Isofix"
			};
			accessories.Add(twelfthAccessory);

			Accessory thirteenthAccessory = new Accessory
			{
				AccessoryId = 13,
				Name = "DynamicStabilityControl"
			};
			accessories.Add(thirteenthAccessory);

			Accessory fourteenthAccessory = new Accessory
			{
				AccessoryId = 14,
				Name = "Tcs"
			};
			accessories.Add(fourteenthAccessory);

			Accessory fifteenthAccessory = new Accessory
			{
				AccessoryId = 15,
				Name = "DistanceControlSystem"
			};
			accessories.Add(fifteenthAccessory);

			Accessory sixteenthAccessory = new Accessory
			{
				AccessoryId = 16,
				Name = "DescentControlSystem"
			};
			accessories.Add(sixteenthAccessory);

			Accessory seventeenthAccessory = new Accessory
			{
				AccessoryId = 17,
				Name = "Bas"
			};
			accessories.Add(seventeenthAccessory);

			Accessory eighteenthAccessory = new Accessory
			{
				AccessoryId = 18,
				Name = "AutoStartStopFunction"
			};
			accessories.Add(eighteenthAccessory);

			Accessory nineteenthAccessory = new Accessory
			{
				AccessoryId = 19,
				Name = "BluetoothHandsfreeSystem"
			};
			accessories.Add(nineteenthAccessory);

			Accessory twentiethAccessory = new Accessory
			{
				AccessoryId = 20,
				Name = "DvdTv"
			};
			accessories.Add(twentiethAccessory);

			Accessory twentyFirstAccessory = new Accessory
			{
				AccessoryId = 21,
				Name = "SteptronicTiptronic"
			};
			accessories.Add(twentyFirstAccessory);

			Accessory twentySecondAccessory = new Accessory
			{
				AccessoryId = 22,
				Name = "UsbAudioVideoInAuxOutputs"
			};
			accessories.Add(twentySecondAccessory);

			Accessory twentyThirdAccessory = new Accessory
			{
				AccessoryId = 23,
				Name = "AdaptiveAirSuspension"
			};
			accessories.Add(twentyThirdAccessory);

			Accessory twentyFourthAccessory = new Accessory
			{
				AccessoryId = 24,
				Name = "KeylessIgnition"
			};
			accessories.Add(twentyFourthAccessory);

			Accessory twentyFifthAccessory = new Accessory
			{
				AccessoryId = 25,
				Name = "DifferentialLock"
			};
			accessories.Add(twentyFifthAccessory);

			Accessory twentySixthAccessory = new Accessory
			{
				AccessoryId = 26,
				Name = "OnBoardComputer"
			};
			accessories.Add(twentySixthAccessory);

			Accessory twentySeventhAccessory = new Accessory
			{
				AccessoryId = 27,
				Name = "LightSensor"
			};
			accessories.Add(twentySeventhAccessory);

			Accessory twentyEighthAccessory = new Accessory
			{
				AccessoryId = 28,
				Name = "ElectricMirrors"
			};
			accessories.Add(twentyEighthAccessory);

			Accessory twentyNinthAccessory = new Accessory
			{
				AccessoryId = 29,
				Name = "ElectricGlass"
			};
			accessories.Add(twentyNinthAccessory);

			Accessory thirtiethAccessory = new Accessory
			{
				AccessoryId = 30,
				Name = "ElectricSuspensionAdjustment"
			};
			accessories.Add(thirtiethAccessory);

			Accessory thirtyFirstAccessory = new Accessory
			{
				AccessoryId = 31,
				Name = "ElectricSeatAdjustment"
			};
			accessories.Add(thirtyFirstAccessory);

			Accessory thirtySecondAccessory = new Accessory
			{
				AccessoryId = 32,
				Name = "ElectricPowerSteering"
			};
			accessories.Add(thirtySecondAccessory);

			Accessory thirtyThirdAccessory = new Accessory
			{
				AccessoryId = 33,
				Name = "AirConditioner"
			};
			accessories.Add(thirtyThirdAccessory);

			Accessory thirtyFourthAccessory = new Accessory
			{
				AccessoryId = 34,
				Name = "Climatronic"
			};
			accessories.Add(thirtyFourthAccessory);

			Accessory thirtyFifthAccessory = new Accessory
			{
				AccessoryId = 35,
				Name = "MultifunctionSteeringWheel"
			};
			accessories.Add(thirtyFifthAccessory);

			Accessory thirtySixthAccessory = new Accessory
			{
				AccessoryId = 36,
				Name = "NavigationSystem"
			};
			accessories.Add(thirtySixthAccessory);

			Accessory thirtySeventhAccessory = new Accessory
			{
				AccessoryId = 37,
				Name = "SteeringWheelHeating"
			};
			accessories.Add(thirtySeventhAccessory);

			Accessory thirtyEighthAccessory = new Accessory
			{
				AccessoryId = 38,
				Name = "WindshieldHeating"
			};
			accessories.Add(thirtyEighthAccessory);

			Accessory thirtyNinthAccessory = new Accessory
			{
				AccessoryId = 39,
				Name = "SeatHeating"
			};
			accessories.Add(thirtyNinthAccessory);

			Accessory fortiethAccessory = new Accessory
			{
				AccessoryId = 40,
				Name = "SteeringWheelAdjustment"
			};
			accessories.Add(fortiethAccessory);

			Accessory fortyFirstAccessory = new Accessory
			{
				AccessoryId = 41,
				Name = "RainSensor"
			};
			accessories.Add(fortyFirstAccessory);

			Accessory fortySecondAccessory = new Accessory
			{
				AccessoryId = 42,
				Name = "PowerSteering"
			};
			accessories.Add(fortySecondAccessory);

			Accessory fortyThirdAccessory = new Accessory
			{
				AccessoryId = 43,
				Name = "HeadlampWashSystem"
			};
			accessories.Add(fortyThirdAccessory);

			Accessory fortyFourthAccessory = new Accessory
			{
				AccessoryId = 44,
				Name = "CruiseControlSystem"
			};
			accessories.Add(fortyFourthAccessory);

			Accessory fortyFifthAccessory = new Accessory
			{
				AccessoryId = 45,
				Name = "StereoSystem"
			};
			accessories.Add(fortyFifthAccessory);

			Accessory fortySixthAccessory = new Accessory
			{
				AccessoryId = 46,
				Name = "CoolingGlovebox"
			};
			accessories.Add(fortySixthAccessory);

			return accessories;
		}


		public class EntityWithoutPrimaryKey
		{
			public int FaultyId { get; set; }
			public string Name { get; set; }
			public int Age { get; set; }
			// Add other properties as needed
		}
	}
}
