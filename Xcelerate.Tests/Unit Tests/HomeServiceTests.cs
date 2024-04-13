namespace Xcelerate.Tests.Unit_Tests
{
	using Core.Contracts;
	using Core.Services;
	using Infrastructure.Data;
	using Microsoft.EntityFrameworkCore;
	using Xcelerate.Core.Models.Home;
	using static Tests.DatabaseSeeder;

	public class HomeServiceTests
	{
		private DbContextOptions<XcelerateContext> dbOptions;
		private XcelerateContext _dbContext;
		private IHomeService _homeService;

		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<XcelerateContext>()
				.UseInMemoryDatabase("XcelerateInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions, false);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			this._homeService = new HomeService(this._dbContext);
		}

		[Test]
		public async Task GetHomePageDataAsync_Returns_CorrectViewModel()
		{
			var homePageView = new HomePageViewModel { CurrentPage = 1 };

			var result = await _homeService.GetHomePageDataAsync(homePageView);

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.DataStatistics);
			Assert.IsNotNull(result.NewsPreview);
			Assert.AreEqual(3, result.NewsPreview.Count());

			Assert.AreEqual(20, result.DataStatistics.SoldCars);
			Assert.AreEqual(30, result.DataStatistics.CreatedCars);
			Assert.AreEqual(50, result.DataStatistics.CreatedReviews);

			var newsItem = result.NewsPreview.First();
			Assert.IsNotNull(newsItem);
			Assert.IsNotNull(newsItem.NewsId);
			Assert.IsNotNull(newsItem.Title);
			Assert.IsNotNull(newsItem.Content);

			Assert.IsTrue(result.NewsPreview.All(n => n.NewsId > 0));
			Assert.IsTrue(result.NewsPreview.All(n => !string.IsNullOrWhiteSpace(n.Title)));
			Assert.IsTrue(result.NewsPreview.All(n => !string.IsNullOrWhiteSpace(n.Content)));
		}

		[Test]
		public async Task GetNewsCountAsync_Returns_CorrectCount()
		{
			var expectedCount = 4;

			var result = await _homeService.GetNewsCountAsync();

			Assert.IsNotNull(result);
			Assert.AreEqual(expectedCount, result);
		}
	}
}
