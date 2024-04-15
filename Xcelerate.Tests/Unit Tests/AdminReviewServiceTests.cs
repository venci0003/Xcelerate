namespace Xcelerate.Tests.Unit_Tests
{
	using Microsoft.EntityFrameworkCore;
	using Xcelerate.Areas.Admin.Contracts;
	using Xcelerate.Areas.Admin.Models;
	using Xcelerate.Areas.Admin.Services;
	using Xcelerate.Infrastructure.Data;
	using Xcelerate.Infrastructure.Data.Models;
	using static Tests.DatabaseSeeder;
	public class AdminReviewServiceTests
	{
		private DbContextOptions<XcelerateContext> dbOptions;
		private XcelerateContext _dbContext;
		private IAdminReviewService _adminReviewService;


		[SetUp]
		public void SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<XcelerateContext>()
				.UseInMemoryDatabase("XcelerateInMemory" + Guid.NewGuid().ToString())
				.Options;
			this._dbContext = new XcelerateContext(this.dbOptions, false);
			this._dbContext.Database.EnsureCreated();
			SeedDatabase(this._dbContext);

			this._adminReviewService = new AdminReviewService(this._dbContext);
		}

		[Test]
		public async Task GetUserReviewsForCheckAsync_ReturnsFilteredReviews()
		{
			await CreateReviews();

			var result = await _adminReviewService.GetUserReviewsForCheckAsync();

			Assert.IsNotNull(result);

			Assert.IsTrue(result.Any(r => ContainsBadWords(r.Comment)));

		}

		[Test]
		public async Task DeleteReviewAsync_DeletesReviewIfExists()
		{
			var reviewToDeleteId = 1;

			var result = await _adminReviewService.DeleteReviewAsync(reviewToDeleteId);

			Assert.IsTrue(result);
			var deletedReview = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == reviewToDeleteId);
			Assert.IsNull(deletedReview);
		}

		[Test]
		public async Task DeleteReviewAsync_ReturnsFalseWhenReviewDoesNotExist()
		{
			var reviewId = 100;
			var expected = false;

			var result = await _adminReviewService.DeleteReviewAsync(reviewId);

			Assert.AreEqual(expected, result);
		}

		private async Task CreateReviews()
		{
			var reviews = new List<Review>
			{
				new Review {
					ReviewId = 10,
					Comment = "This is a review with badword1",
					UserId = Guid.Parse("595CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
					StarsCount = 3
				},
				new Review {
					ReviewId = 20,
					Comment = "This is a review without bad words",
					UserId = Guid.Parse("3CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
					StarsCount = 5
				}
			};

			await _dbContext.Reviews.AddRangeAsync(reviews);
			await _dbContext.SaveChangesAsync();
		}


		private bool ContainsBadWords(string comment)
		{
			List<string> badWords = new List<string> {
			"badword1", "badword2", "darn", "shoot", "heck", "gosh", "golly", "fudge", "dang", "jeez", "crud", "fiddlesticks" };

			return badWords.Any(badWord => comment.ToLower().Contains(badWord));
		}
	}
}
