namespace Xcelerate.Areas.Admin.Services
{
	using Microsoft.EntityFrameworkCore;
	using Contracts;
	using Models;
	using Infrastructure.Data;
	using Infrastructure.Data.Models;
	public class AdminReviewService : IAdminReviewService
	{
		private readonly XcelerateContext _dbContext;

		public AdminReviewService(XcelerateContext context)
		{
			_dbContext = context;
		}
		public async Task<List<AdminReviewViewModel>> GetUserReviewsForCheckAsync()
		{
			List<string> badWords = new List<string> {
				"badword1", "badword2", "darn", "shoot", "heck", "gosh", "golly", "fudge", "dang", "jeez", "crud", "fiddlesticks" };


			List<Review> allReviews = await _dbContext.Reviews
				.Include(review => review.User)
				.ToListAsync();

			List<AdminReviewViewModel> filteredReviews = allReviews
				.Where(review => badWords.Any(badWord => review.Comment.ToLower().Contains(badWord)))
				.Select(review => new AdminReviewViewModel
				{
					UserId = review.UserId,
					ReviewId = review.ReviewId,
					FirstName = review.User.FirstName,
					LastName = review.User.LastName,
					Comment = review.Comment,
					StarsCount = review.StarsCount
				})
				.ToList();


			return filteredReviews;
		}

		public async Task<bool> DeleteReviewAsync(int? reviewId)
		{
			var reviewToDelete = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == reviewId);

			if (reviewToDelete != null)
			{
				_dbContext.Reviews.Remove(reviewToDelete);
				await _dbContext.SaveChangesAsync();
				return true;
			}

			return false;
		}
	}
}
