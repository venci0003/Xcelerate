namespace Xcelerate.Tests.UnitTests
{
	using static DatabaseSeeder;
	using Microsoft.EntityFrameworkCore;
	using Infrastructure.Data;
	using Core.Services;
	using Core.Contracts;
	using Microsoft.AspNetCore.Hosting;
	using Infrastructure.Data.Models;
	using NUnit.Framework.Legacy; 
	using Moq;

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
				.UseInMemoryDatabase("XcelerateSystemInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			this._webHostEnvironment = new Mock<IWebHostEnvironment>().Object;

			this._adService = new АdService(this._dbContext, this._webHostEnvironment);
		}

		[Test]
		public async Task IdExists_Exists()
		{
			bool adIdExists = await _adService.IdExists<Ad>(100);

			bool carIdExists = await _adService.IdExists<Car>(100);

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

		[TearDown]
		public void TearDown()
		{
			_dbContext.Database.EnsureDeleted();
			_dbContext.Dispose();
		}
	}
}
