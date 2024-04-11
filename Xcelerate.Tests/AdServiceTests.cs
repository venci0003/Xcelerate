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
	using Xcelerate.Core.Models.Ad;
	using Xcelerate.Core.Models.Pager;
	using Xcelerate.Core.Models.Review;
	using Xcelerate.Core.Models.Sorting;
	using Xcelerate.Infrastructure.Data.Enums;
	using static DatabaseSeeder;

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

			this._webHostEnvironment = new Mock<IWebHostEnvironment>().Object;

			this._adService = new АdService(this._dbContext, this._webHostEnvironment);
		}

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
		public async Task DeleteCarAdAsync_CarDoesNotExist_ExceptionThrown()
		{
			int carId = -100;

			// Act & Assert
			ArgumentException? exception = Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await _adService.DeleteCarAdAsync(carId);
			});

			Assert.That(exception.Message, Is.EqualTo("Car not found!"));
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
			// Arrange
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

			// Assert
			Assert.AreEqual(expectedCount, actualCount);
		}

		[Test]
		public async Task GetCarAdsCountAsync_Returns_CorrectCount_WithFilter()
		{

			var expectedCount = 1;
			// Arrange
			var adPreview = new AdInformationViewModel
			{
				UserId = Guid.NewGuid(),
				AdId = 1,
				CarId = 1,
				ImageUrls = new List<string> { "url1", "url2", "url3" },
				Brand = BrandsEnum.BMW,
				CreatedOn = DateTime.Now.ToString(),
				IsForSale = true,
				Model = "M5 Competition",
				Year = 0,
				Engine = "V6",
				HorsePower = 0,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				FuelType = FuelTypeEnum.Petrol,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 0,
				Mileage = 0,
				Price = 0,
				BodyType = BodyTypeEnum.Sedan,
				Manufacturer = "BMW",
				CarDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				Pager = new Pager(totalItems: 1, currentPage: 1, defaultPageSize: 1),
				SearchQuery = string.Empty,
				FirstName = "John",
				LastName = "Doe",
				Sorting = SortingEnums.YearDescending,
				StartYear = 2020,
				EndYear = 2023,
				MinPrice = 0,
				MaxPrice = 120000,
				MinHorsePower = 100,
				MaxHorsePower = 400,
				MinMileage = 0,
				MaxMileage = 1200
			};

			var actualCount = await _adService.GetCarAdsCountAsync(adPreview);

			// Assert
			Assert.AreEqual(expectedCount, actualCount);
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
