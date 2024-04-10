namespace Xcelerate.Tests.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using Infrastructure.Data;
	using Core.Services;
	using Core.Contracts;
	using static Xcelerate.Tests.DatabaseSeeder;
	using Microsoft.AspNetCore.Hosting;
	using Infrastructure.Data.Models;
	using NUnit.Framework.Legacy;

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
			this._adService = new АdService(this._dbContext, this._webHostEnvironment);
		}

		[Test]
		public async Task TestAdIdExistsMethod()
		{
			bool adIdExists = await _adService.IdExists<Ad>(23);

			bool carIdExists = await _adService.IdExists<Car>(23);

			Assert.That(adIdExists);

			Assert.That(carIdExists);
		}

		[TearDown]
		public void TearDown()
		{
			_dbContext.Database.EnsureDeleted();
			_dbContext.Dispose();
		}
	}
}
