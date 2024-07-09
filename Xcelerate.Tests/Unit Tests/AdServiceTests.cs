namespace Xcelerate.Tests.UnitTests
{
	using Core.Contracts;
	using Core.Services;
	using Infrastructure.Data;
	using Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.EntityFrameworkCore;
	using Moq;
	using NUnit.Framework;
	using System;
	using System.Text;
	using Xcelerate.Core.Models.Ad;
	using Xcelerate.Core.Models.Pager;
	using Xcelerate.Core.Models.Sorting;
	using Xcelerate.Infrastructure.Data.Enums;
	using static Tests.DatabaseSeeder;

	[TestFixture]
	public class AdServiceTests
	{
		private DbContextOptions<XcelerateContext> dbOptions;
		private XcelerateContext _dbContext;
		private IWebHostEnvironment _webHostEnvironment;
		private IAdService _adService;


		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<XcelerateContext>()
				.UseInMemoryDatabase("XcelerateInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions, false);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
			mockWebHostEnvironment.Setup(m => m.WebRootPath).Returns("fake/web/root/path");

			this._webHostEnvironment = mockWebHostEnvironment.Object;

			this._adService = new АdService(this._dbContext, this._webHostEnvironment);

		}

		[Test]
		public async Task CreateAdAsync_ShouldUploadImagesUnSuccessfully()
		{
			var selectedCheckBoxIds = new List<int>
			{
				1,
				3,
				5,
			};
			var adViewModel = new AdCreateViewModel
			{
				Brand = BrandsEnum.Toyota,
				Model = "Camry",
				Year = 2020,
				Engine = "V6",
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				FuelType = FuelTypeEnum.Petrol,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1850.8m,
				Mileage = 1000,
				Price = 110000,
				BodyType = BodyTypeEnum.Sedan,
				Manufacturer = "Toyota",
				CarDescription = "Lorem ipsum dolor sit amet",
				Address = new AddressViewModel
				{
					CountryName = "Country",
					TownName = "Town",
					StreetName = "Street"
				},
				UploadedImages = new List<IFormFile>
				{
					new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.jpg")
				}
				,
				SelectedCheckBoxId = selectedCheckBoxIds
			};
			var userId = Guid.NewGuid().ToString();

			await _adService.CreateAdAsync(adViewModel, userId);

			var createdAd = _dbContext.Ads.FirstOrDefault(a => a.UserId == Guid.Parse(userId));
			Assert.IsNotNull(createdAd, "Ad was not created successfully.");

			var createdCar = _dbContext.Cars.FirstOrDefault(c => c.UserId == Guid.Parse(userId));
			Assert.IsNotNull(createdCar, "Car was not created successfully.");

			var carImage = createdCar.Images.Select(c => c.ImageId).FirstOrDefault();

			var createdImages = _dbContext.Images.Where(i => i.ImageId == carImage).ToList();
			Assert.IsFalse(createdImages.Count > 0, "No images were uploaded for the car.");

			// Additional assertion: Verify if the uploaded image matches the expected filename
			var uploadedImage = createdImages.FirstOrDefault();
			Assert.IsNull(uploadedImage, "Image was not uploaded successfully.");

		}


		[Test]
		public async Task EditCarAdAsync_ReturnsTrue_WhenCarAdIsEdited()
		{
			var selectedCheckBoxIds = new List<int>
			{
				1,
				3,
				5,
			};
			var image1 = new Mock<IFormFile>();
			image1.Setup(x => x.FileName).Returns("image1.jpg");

			var image2 = new Mock<IFormFile>();
			image2.Setup(x => x.FileName).Returns("image2.jpg");

			var adViewModel = new AdEditViewModel
			{
				CarId = 1,
				Brand = BrandsEnum.Toyota,
				Model = "Camry",
				Year = 2020,
				Engine = "V6",
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				FuelType = FuelTypeEnum.Petrol,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1850.8m,
				Mileage = 1000,
				Price = 110000,
				BodyType = BodyTypeEnum.Sedan,
				Manufacturer = "Toyota",
				CarDescription = "Lorem ipsum dolor sit amet",
				Address = new AddressViewModel
				{
					CountryName = "Country",
					TownName = "Town",
					StreetName = "Street"
				},
				UploadedImages = new List<IFormFile> { image1.Object, image2.Object },
				SelectedCheckBoxId = selectedCheckBoxIds
			};

			var result = await _adService.EditCarAdAsync(adViewModel);

			Assert.IsTrue(result);

			var editedCar = await _dbContext.Cars
			.Include(c => c.CarAccessories)
			.FirstOrDefaultAsync(c => c.CarId == adViewModel.CarId);

			Assert.IsNotNull(editedCar);
			Assert.AreEqual(selectedCheckBoxIds.Count, editedCar.CarAccessories.Count);

			foreach (var accessoryId in selectedCheckBoxIds)
			{
				var accessoryExists = editedCar.CarAccessories.Any(ca => ca.AccessoryId == accessoryId);
				Assert.IsTrue(accessoryExists);
			}
		}



		[Test]
		public async Task GetEditInformationAsync_ReturnsEditInformation_WhenCarExists()
		{
			var carId = 1;

			var result = await _adService.GetEditInformationAsync(carId);

			Assert.IsNotNull(result);
			Assert.AreEqual(carId, result.CarId);
		}

		[Test]
		public async Task GetUserAdsAsync_ReturnsUserAds_WhenUserHasAds()
		{
			var userId = Guid.Parse("8ABB04A0-36A0-4A35-8C1A-34D324AA169E");

			var adViewModel = new AdInformationViewModel
			{
				UserId = Guid.Parse("8ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
			};

			var result = await _adService.GetUserAdsAsync(userId, adViewModel);

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Count());

			var firstAd = result.First();
			Assert.AreEqual(1, firstAd.AdId);
			Assert.AreEqual(1, firstAd.CarId);
			Assert.AreEqual(BrandsEnum.BMW, firstAd.Brand);
			Assert.AreEqual("M5 Competition", firstAd.Model);
			Assert.AreEqual(2022, firstAd.Year);
			Assert.AreEqual(110000, firstAd.Price);
			Assert.AreEqual("Ava", firstAd.FirstName);
			Assert.AreEqual("Simson", firstAd.LastName);
			Assert.AreEqual("2020_toyota_camry_trd_1.jpg", firstAd.ImageUrls.FirstOrDefault());

		}



		[Test]
		public async Task GetCarsInformationAsync_ReturnsNull_WhenAdIdIsNull()
		{
			var result = await _adService.GetCarsInformationAsync(null);

			Assert.IsNull(result);
			Assert.That(result, Is.Null);

		}





		[Test]
		public async Task GetCarsPreviewAsync_ReturnsCorrectPreviewModels()
		{
			// Arrange
			var adViewModel = new AdInformationViewModel
			{
				UserId = Guid.NewGuid(),
				AdId = 1,
				CarId = 1,
				ImageUrls = new List<string> { "url1", "url2", "url3" },
				Brand = BrandsEnum.Default,
				CreatedOn = DateTime.Now.ToString(),
				IsForSale = true,
				Model = string.Empty,
				Year = 0,
				Engine = "V6",
				HorsePower = 0,
				Condition = ConditionEnum.Default,
				EuroStandard = EuroStandardEnum.Default,
				FuelType = FuelTypeEnum.Default,
				Colour = ColourEnum.Default,
				Transmission = TransmissionEnum.Default,
				DriveTrain = DriveTrainEnum.Default,
				Weight = 0,
				Mileage = 0,
				Price = 0,
				BodyType = BodyTypeEnum.Default,
				Manufacturer = string.Empty,
				CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
				SearchQuery = string.Empty,
				FirstName = "John",
				LastName = "Doe",
				Sorting = SortingEnums.Default,
				StartYear = 0,
				EndYear = 0,
				MinPrice = null,
				MaxPrice = null,
				MinHorsePower = null,
				MaxHorsePower = null,
				MinMileage = null,
				MaxMileage = null
			};

			// Act
			var result = await _adService.GetCarsPreviewAsync(adViewModel);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Count());
		}


		[Test]
		public async Task GetTwoCarsByIdAsync_ReturnsTwoCars_WhenBothExist()
		{
			int firstCarId = 1;
			int secondCarId = 2;

			var firstCar = await _dbContext.Cars.Where(c => c.CarId == firstCarId).FirstOrDefaultAsync();

			var secondCar = await _dbContext.Cars.Where(c => c.CarId == secondCarId).FirstOrDefaultAsync();


			// Act
			var result = await _adService.GetTwoCarsByIdAsync(firstCar.CarId, secondCar.CarId);

			// Assert
			Assert.IsNotNull(result.firstCar);
			Assert.IsNotNull(result.secondCar);
		}

		[Test]
		public void GetTwoCarsByIdAsync_ThrowsArgumentException_WhenOneOrBothCarsDoNotExist()
		{
			int nonExistingCarId = 999;
			int existingCarId = 1;

			var aggregateException = Assert.Throws<AggregateException>(() =>
			{
				_adService.GetTwoCarsByIdAsync(nonExistingCarId, existingCarId).Wait();
			});

			Assert.IsInstanceOf<ArgumentException>(aggregateException.InnerException);
			Assert.AreEqual("One or both cars not found!", aggregateException.InnerException.Message);
		}


		//[Test]
		//public async Task BuyCarAsync_RemovesAdAndReviewsAndUpdateStatistics_WhenCarAdExists()
		//{
		//	var existingCar = await _dbContext.Cars.Where(c => c.CarId == 1).FirstOrDefaultAsync();

		//	Assert.IsNotNull(existingCar, "No existing car found in the database.");

		//	var result = await _adService.BuyCarAsync(existingCar);

		//	Assert.IsTrue(result);

		//	var adRemoved = !_dbContext.Ads.Any(a => a.AdId == existingCar.AdId);
		//	var reviewsRemoved = !_dbContext.Reviews.Any(r => r.AdId == existingCar.AdId);

		//	Assert.IsTrue(adRemoved);
		//	Assert.IsTrue(reviewsRemoved);

		//	var statisticsUpdated = await _dbContext.StatisticalData.FirstOrDefaultAsync();
		//	Assert.IsNotNull(statisticsUpdated);
		//	Assert.AreEqual(statisticsUpdated.SoldCars, statisticsUpdated.SoldCars);
		//}

		//[Test]
		//public async Task BuyCarAsync_ReturnsFalse_WhenCarAdDoesNotExist()
		//{
		//	var nonExistingCar = new Car { CarId = 999 };

		//	var result = await _adService.BuyCarAsync(nonExistingCar);

		//	Assert.IsFalse(result);
		//}

		[Test]
		public async Task IdExists_Exists()
		{
			bool adIdExists = await _adService.IdExists<Ad>(1);

			bool carIdExists = await _adService.IdExists<Car>(1);

			Assert.That(adIdExists);

			Assert.That(carIdExists);
		}

		[Test]
		public async Task IdExists_DoesNotExist()
		{
			bool adIdExists = await _adService.IdExists<Ad>(-100);

			bool carIdExists = await _adService.IdExists<Car>(0);

			Assert.That(!adIdExists);

			Assert.That(!carIdExists);
		}

		[Test]
		public async Task DeleteCarAdAsync_CarExists_CarAndRelatedEntitiesDeleted()
		{
			int carId = 1;

			bool result = await _adService.DeleteCarAdAsync(carId);

			Assert.That(result);

			Car? deletedCar = await _dbContext.Cars.FindAsync(carId);
			Assert.That(deletedCar, Is.Null);
		}

		[Test]
		public void DeleteCarAdAsync_CarDoesNotExist_ExceptionThrown()
		{
			int carId = -100;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await _adService.DeleteCarAdAsync(carId);
			});

			Assert.That(ex.Message, Is.EqualTo("Car not found!"));
		}

		[Test]
		public async Task GetCarByIdAsync_CarExists_ReturnsCar()
		{
			int carId = 1;

			var result = await _adService.GetCarByIdAsync(carId);

			Assert.IsNotNull(result);
			Assert.AreEqual(carId, result.CarId);
		}

		[Test]
		public async Task GetCarByIdAsync_CarDoesNotExist_ExceptionThrown()
		{
			int carId = -100;

			ArgumentException exception = null;
			try
			{
				await _adService.GetCarByIdAsync(carId);
			}
			catch (ArgumentException ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
			Assert.AreEqual("Car not found!", exception.Message);
		}




		//[Test]
		//public async Task GetCarsPreviewAsync_ReturnsCorrectNumberOfAdPreviewViewModels()
		//{
		//	// Arrange
		//	var adViewModel = new AdInformationViewModel
		//	{
		//		// Set up the properties of adViewModel as needed for the test
		//	};

		//	// Act
		//	var result = await _adService.GetCarsPreviewAsync(adViewModel);

		//	// Assert
		//	Assert.IsNotNull(result);
		//	// Add assertions to verify the correctness of the returned data
		//}

		[Test]
		public async Task GetCarAdsCountAsync_Returns_CorrectCount()
		{
			var expectedCount = 4;
			var adPreview = new AdInformationViewModel
			{
				UserId = Guid.NewGuid(),
				AdId = 1,
				CarId = 1,
				ImageUrls = new List<string> { "url1", "url2", "url3" },
				Brand = BrandsEnum.Default,
				CreatedOn = DateTime.Now.ToString(),
				IsForSale = true,
				Model = string.Empty,
				Year = 0,
				Engine = "V6",
				HorsePower = 0,
				Condition = ConditionEnum.Default,
				EuroStandard = EuroStandardEnum.Default,
				FuelType = FuelTypeEnum.Default,
				Colour = ColourEnum.Default,
				Transmission = TransmissionEnum.Default,
				DriveTrain = DriveTrainEnum.Default,
				Weight = 0,
				Mileage = 0,
				Price = 0,
				BodyType = BodyTypeEnum.Default,
				Manufacturer = string.Empty,
				CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
				SearchQuery = string.Empty,
				FirstName = "John",
				LastName = "Doe",
				Sorting = SortingEnums.Default,
				StartYear = 0,
				EndYear = 0,
				MinPrice = null,
				MaxPrice = null,
				MinHorsePower = null,
				MaxHorsePower = null,
				MinMileage = null,
				MaxMileage = null
			};

			var actualCount = await _adService.GetCarAdsCountAsync(adPreview);

			Assert.AreEqual(expectedCount, actualCount);
		}


		[Test]
		public async Task GetUserAdsCountAsync_Returns_CorrectCount()
		{
			int expectedCount = 1;
			var userId = "8ABB04A0-36A0-4A35-8C1A-34D324AA169E";
			var adPreview = new AdInformationViewModel
			{
				UserId = Guid.Parse("8ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				AdId = 1,
				CarId = 1,
				ImageUrls = new List<string> { "url1", "url2", "url3" },
				Brand = BrandsEnum.Default,
				CreatedOn = DateTime.Now.ToString(),
				IsForSale = false,
				Model = string.Empty,
				Year = 0,
				Engine = string.Empty,
				HorsePower = 0,
				Condition = ConditionEnum.Default,
				EuroStandard = EuroStandardEnum.Default,
				FuelType = FuelTypeEnum.Default,
				Colour = ColourEnum.Default,
				Transmission = TransmissionEnum.Default,
				DriveTrain = DriveTrainEnum.Default,
				Weight = 0,
				Mileage = 0,
				Price = 0,
				BodyType = BodyTypeEnum.Default,
				Manufacturer = string.Empty,
				CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
				SearchQuery = string.Empty,
				FirstName = "John",
				LastName = "Doe",
				Sorting = SortingEnums.Default,
				StartYear = 0,
				EndYear = 0,
				MinPrice = null,
				MaxPrice = null,
				MinHorsePower = null,
				MaxHorsePower = null,
				MinMileage = null,
				MaxMileage = null
			};

			var result = await _adService.GetUserAdsCountAsync(adPreview, userId);

			Assert.AreEqual(expectedCount, result);
		}

		//[Test]
		//public async Task GetCarsPreviewAsync_Returns_CorrectCount()
		//{

		//	var expectedCount = 4;
		//	// Arrange
		//	var adPreview = new AdInformationViewModel
		//	{
		//		UserId = Guid.NewGuid(),
		//		AdId = 1,
		//		CarId = 1,
		//		ImageUrls = new List<string> { "url1", "url2", "url3" },
		//		Brand = BrandsEnum.Default,
		//		CreatedOn = DateTime.Now.ToString(),
		//		IsForSale = true,
		//		Model = string.Empty,
		//		Year = 0,
		//		Engine = "V6",
		//		HorsePower = 0,
		//		Condition = ConditionEnum.Default,
		//		EuroStandard = EuroStandardEnum.Default,
		//		FuelType = FuelTypeEnum.Default,
		//		Colour = ColourEnum.Default,
		//		Transmission = TransmissionEnum.Default,
		//		DriveTrain = DriveTrainEnum.Default,
		//		Weight = 0,
		//		Mileage = 0,
		//		Price = 0,
		//		BodyType = BodyTypeEnum.Default,
		//		Manufacturer = string.Empty,
		//		CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
		//		Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
		//		SearchQuery = string.Empty,
		//		FirstName = "John",
		//		LastName = "Doe",
		//		Sorting = SortingEnums.Default,
		//		StartYear = 0,
		//		EndYear = 0,
		//		MinPrice = null,
		//		MaxPrice = null,
		//		MinHorsePower = null,
		//		MaxHorsePower = null,
		//		MinMileage = null,
		//		MaxMileage = null
		//	};

		//	IEnumerable<AdPreviewViewModel> actualCount = await _adService.GetCarsPreviewAsync(adPreview);

		//	// Assert
		//	Assert.IsNotNull(actualCount); // Ensure actualCount is not null
		//	Assert.IsInstanceOf<IEnumerable<AdPreviewViewModel>>(actualCount); // Ensure actualCount is of the correct type
		//	Assert.AreEqual(expectedCount, actualCount.Count());
		//}

		[Test]
		public async Task GetCarAdsCountAsync_Returns_CorrectCount_WithFilters(
	[Values] SortingEnums sorting)
		{
			var expectedCount = 1;

			var adPreview = new AdInformationViewModel
			{
				ImageUrls = new List<string> { "url1", "url2", "url3" },
				Brand = BrandsEnum.BMW,
				CreatedOn = DateTime.Now.ToString(),
				IsForSale = true,
				Model = "M5 Competition",
				Year = 2020,
				Engine = "V6",
				HorsePower = 300,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				FuelType = FuelTypeEnum.Petrol,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1850.8m,
				Mileage = 1000,
				Price = 110000,
				BodyType = BodyTypeEnum.Sedan,
				Manufacturer = "BMW",
				CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
				SearchQuery = "BMW",
				FirstName = "John",
				LastName = "Doe",
				Sorting = sorting, // Set sorting option here
				StartYear = 2020,
				EndYear = 2023,
				MinPrice = 100,
				MaxPrice = 120000,
				MinHorsePower = 100,
				MaxHorsePower = 400,
				MinMileage = 100,
				MaxMileage = 30000
			};

			var actualCount = await _adService.GetCarAdsCountAsync(adPreview);

			Assert.AreEqual(expectedCount, actualCount);
		}

		[Test]
		public async Task CreateAdAsync_SuccessfullyCreatesAd()
		{
			var adViewModel = new AdCreateViewModel
			{
				ImageUrls = new List<string> { "url1", "url2", "url3" },
				Brand = BrandsEnum.BMW,
				IsForSale = true,
				Model = "M5 Competition",
				Year = 2020,
				Engine = "V6",
				HorsePower = 300,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				FuelType = FuelTypeEnum.Petrol,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1850.8m,
				Mileage = 1000,
				Price = 110000,
				BodyType = BodyTypeEnum.Sedan,
				Manufacturer = "BMW",
				CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				Address = new AddressViewModel
				{
					CountryName = "Country",
					TownName = "Town",
					StreetName = "Street"
				},
				SelectedCheckBoxId = Enumerable.Range(1, 20).ToList()
			};


			var userId = "8ABB04A0-36A0-4A35-8C1A-34D324AA169E";

			await _adService.CreateAdAsync(adViewModel, userId);

			var createdAd = await _dbContext.Ads.FirstOrDefaultAsync(a => a.UserId == Guid.Parse(userId));
			Assert.IsNotNull(createdAd);

			int expectedImageCount = 5;
			int actualImageCount = await _dbContext.Images.CountAsync(image => image.CarId == createdAd.CarId);
			Assert.AreEqual(expectedImageCount, actualImageCount);

			int expectedAccessories = 20;

			var accessoriesCount = await _dbContext.CarAccessories
	   .CountAsync(ca => ca.CarId == createdAd.CarId);
			Assert.AreEqual(expectedAccessories, accessoriesCount);

			var adImagesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad");
			foreach (var image in adViewModel.UploadedImages)
			{
				if (image != null && image.Length > 0)
				{
					var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
					var filePath = Path.Combine(adImagesDirectory, uniqueFileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await image.CopyToAsync(stream);
					}

					var imageToCreate = new Xcelerate.Infrastructure.Data.Models.Image()
					{
						CarId = createdAd.CarId,
						ImageUrl = uniqueFileName
					};
					await _dbContext.AddAsync(imageToCreate);

					var savedImage = await _dbContext.Images.FirstOrDefaultAsync(i => i.ImageUrl == uniqueFileName);
					Assert.IsNotNull(savedImage);
					Assert.AreEqual(createdAd.CarId, savedImage.CarId);
				}
			}
		}


		[Test]
		public async Task CreateAdAsync_FailsToCreateAd()
		{
			// Arrange
			var adViewModel = new AdCreateViewModel
			{
			};

			var userId = "invalid-user-id";

			Assert.Throws<ArgumentException>(() => _adService.CreateAdAsync(adViewModel, userId).GetAwaiter().GetResult());
		}


		[Test]
		public void Configure_Pagination_Calculates_Correctly()
		{
			int totalItems = 50;
			int currentPage = 1;
			int defaultPageSize = 10;

			var pager = new Pager(totalItems, currentPage, defaultPageSize);

			Assert.AreEqual(5, pager.TotalPages);
			Assert.AreEqual(1, pager.StartPage);
			Assert.AreEqual(5, pager.EndPage);
			Assert.AreEqual(50, pager.TotalItems);
		}

		[TearDown]
		public void TearDown()
		{
			_dbContext.Database.EnsureDeleted();
			_dbContext.Dispose();
		}
	}
}
