﻿namespace Xcelerate.Tests.Unit_Tests
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

			var result = await _reviewService.DeleteReviewAsync(existingReviewId);

			Assert.IsTrue(result);

			var reviewDeleted = !_dbContext.Reviews.Any(r => r.ReviewId == existingReviewId);
			Assert.IsTrue(reviewDeleted);
		}

		[Test]
		public async Task DeleteReviewAsync_ReturnsFalse_WhenReviewDoesNotExist()
		{
			int nonExistingReviewId = 999;

			var result = await _reviewService.DeleteReviewAsync(nonExistingReviewId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetEditInformationAsync_ReturnsEditReviewViewModel_WhenReviewExists()
		{
			int existingReviewId = 1;

			var result = await _reviewService.GetEditInformationAsync(existingReviewId);

			Assert.IsNotNull(result);
			Assert.AreEqual(existingReviewId, result.ReviewId);
		}

		[Test]
		public void GetEditInformationAsync_ThrowsArgumentException_WhenReviewDoesNotExist()
		{
			int nonExistingReviewId = 999;

			var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await _reviewService.GetEditInformationAsync(nonExistingReviewId);
			});

			Assert.AreEqual("Review not found!", ex.Message);
		}

		[Test]
		public async Task EditReviewAsync_ReturnsTrue_WhenReviewExistsAndIsEdited()
		{
			var existingReviewId = 17;
			var newComment = "New comment";
			var newStarsCount = 4;

			var review = new Review
			{
				ReviewId = existingReviewId,
				Comment = "Old comment",
				StarsCount = 3
			};
			_dbContext.Reviews.Add(review);
			await _dbContext.SaveChangesAsync();

			var editReviewViewModel = new EditReviewViewModel
			{
				ReviewId = existingReviewId,
				Comment = newComment,
				StarsCount = newStarsCount
			};

			var result = await _reviewService.EditReviewAsync(editReviewViewModel);

			Assert.IsTrue(result);

			var editedReview = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == existingReviewId);
			Assert.IsNotNull(editedReview);
			Assert.AreEqual(newComment, editedReview.Comment);
			Assert.AreEqual(newStarsCount, editedReview.StarsCount);
		}

		[Test]
		public void EditReviewAsync_ThrowsArgumentException_WhenReviewDoesNotExist()
		{
			var nonExistingReviewId = 999;

			var editReviewViewModel = new EditReviewViewModel
			{
				ReviewId = nonExistingReviewId,
			};

			var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
			{
				await _reviewService.EditReviewAsync(editReviewViewModel);
			});

			Assert.AreEqual("Review not found!", ex.Message);
		}

		[Test]
		public async Task GetUserReviewsAsync_ReturnsListOfUserReviews_WhenAdIdExists()
		{
			var existingAdId = 1;

			var reviews = new List<Review>
			{
				new Review
				{
					ReviewId = 17,
					AdId = existingAdId,
					UserId = Guid.NewGuid(),
					Comment = "First review",
					StarsCount = 5,
					User = new User { FirstName = "John", LastName = "Doe" }
				},
				new Review
				{
					ReviewId = 18,
					AdId = existingAdId,
					UserId = Guid.NewGuid(),
					Comment = "Second review",
					StarsCount = 4,
					User = new User { FirstName = "Jane", LastName = "Smith" }
				}
			};
			_dbContext.Reviews.AddRange(reviews);
			await _dbContext.SaveChangesAsync();

			var result = await _reviewService.GetUserReviewsAsync(existingAdId);

			Assert.IsNotNull(result);
			Assert.AreEqual(reviews.Count, result.Count);

			foreach (var reviewViewModel in result)
			{
				var correspondingReview = reviews.FirstOrDefault(r => r.ReviewId == reviewViewModel.ReviewId);
				Assert.IsNotNull(correspondingReview);
				Assert.AreEqual(correspondingReview.Ad.CarId, reviewViewModel.CarId);
				Assert.AreEqual(correspondingReview.UserId, reviewViewModel.UserId);
				Assert.AreEqual(correspondingReview.Comment, reviewViewModel.Comment);
				Assert.AreEqual(correspondingReview.StarsCount, reviewViewModel.StarsCount);
				Assert.AreEqual(correspondingReview.User.FirstName, reviewViewModel.FirstName);
				Assert.AreEqual(correspondingReview.User.LastName, reviewViewModel.LastName);
			}
		}

		[Test]
		public async Task GetUserReviewsAsync_ReturnsEmptyList_WhenAdIdDoesNotExist()
		{
			var nonExistingAdId = 999;

			var result = await _reviewService.GetUserReviewsAsync(nonExistingAdId);

			Assert.IsNotNull(result);
			Assert.IsEmpty(result);
		}

	}
}
