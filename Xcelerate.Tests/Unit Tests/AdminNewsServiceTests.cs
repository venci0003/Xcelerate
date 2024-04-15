
namespace Xcelerate.Tests.Unit_Tests
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Moq;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Xcelerate.Areas.Admin.Contracts;
	using Xcelerate.Areas.Admin.Models;
	using Xcelerate.Areas.Admin.Services;
	using Xcelerate.Core.Contracts;
	using Xcelerate.Core.Services;
	using Xcelerate.Infrastructure.Data;
	using static Tests.DatabaseSeeder;
	public class AdminNewsServiceTests
	{
		private DbContextOptions<XcelerateContext> dbOptions;
		private XcelerateContext _dbContext;
		private IAdminNewsService _adminNewsService;


		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<XcelerateContext>()
				.UseInMemoryDatabase("XcelerateInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions, false);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			this._adminNewsService = new AdminNewsService(this._dbContext);
		}

		[Test]
		public async Task GetHomePageDataAsync_ReturnsCorrectData()
		{
			// Arrange
			var homePageView = new AdminHomeViewModel { CurrentPage = 1 };

			// Act
			var result = await _adminNewsService.GetHomePageDataAsync(homePageView);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.NewsPreview.Count());
		}

		[Test]
		public async Task GetNewsCountAsync_ReturnsCorrectCount()
		{
			// Act
			var result = await _adminNewsService.GetNewsCountAsync();

			// Assert
			Assert.AreEqual(4, result); // Assuming there are 3 news items in the database
		}

		[Test]
		public void GenerateNews_ReturnsValidNews()
		{
			// Act
			var result = _adminNewsService.GenerateNews();

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrEmpty(result.Title));
			Assert.IsFalse(string.IsNullOrEmpty(result.Content));
		}

		[Test]
		public async Task ApproveNewsAsync_AddsNewsToDatabase()
		{
			// Arrange
			var generatedNewsView = new GeneratedNewsViewModel
			{
				Title = "Test News",
				Content = "This is a test news content."
			};

			// Act
			await _adminNewsService.ApproveNewsAsync(generatedNewsView);

			// Assert
			var addedNews = await _dbContext.NewsData.FirstOrDefaultAsync(n => n.Title == generatedNewsView.Title);
			Assert.IsNotNull(addedNews);
			Assert.AreEqual(generatedNewsView.Content, addedNews.Content);
		}
	}
}
