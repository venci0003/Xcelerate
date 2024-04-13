namespace Xcelerate.Tests.Unit_Tests
{
	using Microsoft.EntityFrameworkCore;
	using Xcelerate.Core.Contracts;
	using Core.Services;
	using Infrastructure.Data;
	using static Tests.DatabaseSeeder;
	using Xcelerate.Core.Models.Ad;
	using Xcelerate.Infrastructure.Data.Models;

	public class AccessoriesServiceTests
	{
		private DbContextOptions<XcelerateContext> dbOptions;
		private XcelerateContext _dbContext;
		private IAccessoriesService _accessoriesService;

		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<XcelerateContext>()
				.UseInMemoryDatabase("XcelerateInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions, false);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			this._accessoriesService = new AccessoriesService(this._dbContext);
		}

		[Test]
		public async Task GetAccessories_ReturnsListOfAccessories()
		{
			var accessory1 = new Accessory { AccessoryId = 47, Name = "Accessory 1" };
			var accessory2 = new Accessory { AccessoryId = 48, Name = "Accessory 2" };
			var accessory3 = new Accessory { AccessoryId = 49, Name = "Accessory 3" };

			_dbContext.Accessories.AddRange(accessory1, accessory2, accessory3);
			await _dbContext.SaveChangesAsync();

			var result = await _accessoriesService.GetAccessories();

			Assert.IsNotNull(result);
			Assert.IsInstanceOf<AdCreateViewModel>(result);
			Assert.IsNotNull(result.Accessories);
			Assert.AreEqual(49, result.Accessories.Count);

			Assert.IsTrue(result.Accessories.Any(a => a.AccessoryId == accessory1.AccessoryId && a.Name == accessory1.Name));
			Assert.IsTrue(result.Accessories.Any(a => a.AccessoryId == accessory2.AccessoryId && a.Name == accessory2.Name));
			Assert.IsTrue(result.Accessories.Any(a => a.AccessoryId == accessory3.AccessoryId && a.Name == accessory3.Name));
		}

		[Test]
		public async Task GetCarAccessoriesForOwnedCarsAsync_ReturnsListOfAccessories_WhenCarExists()
		{
			var carId = 1;

			var result = await _accessoriesService.GetCarAccessoriesForOwnedCarsAsync(carId);

			Assert.IsNotNull(result);
			Assert.IsInstanceOf<List<AccessoryViewModel>>(result);
			Assert.AreEqual(20, result.Count);

			var accessoryIds = result.Select(a => a.AccessoryId).ToList();
			CollectionAssert.AreEqual(
				new List<int> { 8, 14, 3, 19, 10, 2, 7, 16, 5, 11, 20, 4, 18, 13, 9, 6, 1, 12, 17, 15 },
				accessoryIds);
		}



		[Test]
		public async Task GetCarAccessoriesForOwnedCarsAsync_ReturnsNull_WhenCarDoesNotExist()
		{
			var carId = 999;

			var result = await _accessoriesService.GetCarAccessoriesForOwnedCarsAsync(carId);

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetCarAccessoriesForSaleAsync_ReturnsListOfAccessories_WhenCarExists()
		{
			var adId = 1;

			var result = await _accessoriesService.GetCarAccessoriesForSaleAsync(adId);

			Assert.IsNotNull(result);
			Assert.IsInstanceOf<List<AccessoryViewModel>>(result);
			Assert.AreEqual(20, result.Count);

			var accessoryIds = result.Select(a => a.AccessoryId).ToList();
			CollectionAssert.AreEqual(
				new List<int> { 8, 14, 3, 19, 10, 2, 7, 16, 5, 11, 20, 4, 18, 13, 9, 6, 1, 12, 17, 15 },
				accessoryIds);
		}

		[Test]
		public async Task GetCarAccessoriesForSaleAsync_ReturnsNull_WhenCarDoesNotExist()
		{
			var nonExistingAdId = 999;

			var result = await _accessoriesService.GetCarAccessoriesForSaleAsync(nonExistingAdId);

			Assert.IsNull(result);
		}


	}
}
