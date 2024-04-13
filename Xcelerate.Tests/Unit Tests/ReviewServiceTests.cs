namespace Xcelerate.Tests.Unit_Tests
{
	using Microsoft.EntityFrameworkCore;
	using System;
	using Xcelerate.Core.Contracts;
	using Xcelerate.Core.Models.Review;
	using Xcelerate.Core.Services;
	using Xcelerate.Infrastructure.Data;
	using Xcelerate.Infrastructure.Data.Models;
	using static Tests.DatabaseSeeder;
	public class ReviewServiceTests
	{
		private DbContextOptions<XcelerateContext> dbOptions;
		private XcelerateContext _dbContext;
		private IReviewService _reviewService;

		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<XcelerateContext>()
				.UseInMemoryDatabase("XcelerateInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions, false);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			this._reviewService = new ReviewService(this._dbContext);
		}

		[Test]
		public async Task CreateReviewAsync_CreatesReviewAndUpdatesStatistics()
		{
			// Arrange
			var reviewModel = new ReviewViewModel { Comment = "Test comment", StarsCount = 5 };
			var userId = Guid.NewGuid().ToString();
			var adId = 1;

			// Act
			await _reviewService.CreateReviewAsync(reviewModel, userId, adId);

			// Assert
			var createdReview = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Comment == reviewModel.Comment);
			Assert.IsNotNull(createdReview);
			Assert.AreEqual(adId, createdReview.AdId);
			Assert.AreEqual(Guid.Parse(userId), createdReview.UserId);
			Assert.AreEqual(reviewModel.Comment, createdReview.Comment);
			Assert.AreEqual(reviewModel.StarsCount, createdReview.StarsCount);

			try
			{
				await _reviewService.CreateReviewAsync(reviewModel, userId, adId);
			}
			catch (ArgumentException ex)
			{
				// Assert
				Assert.AreEqual("Failed creating review!", ex.Message);
			}

			// Assert that statistics are not updated
			var statistics = await _dbContext.StatisticalData.FirstOrDefaultAsync();
			Assert.IsNotNull(statistics);
			Assert.AreEqual(52, statistics.CreatedReviews);
		}

		[Test]
		public async Task CreateReviewAsync_ExceptionThrown_ArgumentException()
		{
			// Arrange
			var reviewModel = new ReviewViewModel { Comment = "Test comment", StarsCount = 5 };
			var userId = string.Empty;
			var adId = 1;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await _reviewService.CreateReviewAsync(reviewModel, userId, adId);
			});

			Assert.That(ex.Message, Is.EqualTo("Failed creating review!"));
		}

		[Test]
		public async Task DeleteReviewAsync_ReturnsTrue_WhenReviewExistsAndIsDeleted()
		{
			int existingReviewId = 1;

			var result = await _reviewService.DeleteReviewAsync(existingReviewId); // Changed from _adService to _reviewService

			Assert.IsTrue(result);

			var reviewDeleted = !_dbContext.Reviews.Any(r => r.ReviewId == existingReviewId);
			Assert.IsTrue(reviewDeleted);
		}



	}
}
