using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Review;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Services
{

	public class ReviewService : IReviewService
	{
		private readonly XcelerateContext _dbContext;

		public ReviewService(XcelerateContext context)
		{
			_dbContext = context;
		}

		public async Task CreateReviewAsync(ReviewViewModel reviewModel, string userId)
		{
			try
			{
				var newReview = new Review
				{
					AdId = reviewModel.AdId,
					UserId = Guid.Parse(userId),
					Comment = reviewModel.Comment,
					StarsCount = reviewModel.StarsCount,
				};

				await _dbContext.AddAsync(newReview);
				await _dbContext.SaveChangesAsync();

			}
			catch (Exception)
			{
				throw new ArgumentException("Failed creating review!");
			}

		}

		public async Task<List<ReviewViewModel>> GetUserReviewsAsync(int adId)
		{
			List<ReviewViewModel> reviews = await _dbContext.Reviews.Where(a => a.AdId == adId).Select(review => new ReviewViewModel
			{
				CarId = review.Ad.CarId,
				FirstName = review.User.FirstName,
				LastName = review.User.LastName,
				Comment = review.Comment,
				StarsCount = review.StarsCount
			}).ToListAsync();

			return reviews;
		}
	}
}
