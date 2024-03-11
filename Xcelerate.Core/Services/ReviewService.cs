using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
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

        public async Task CreateReviewAsync(ReviewViewModel reviewModel, string userId, int adId)
        {
            try
            {
                var newReview = new Review
                {
                    AdId = adId,
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

        public async Task<EditReviewViewModel> GetEditInformationAsync(int? reviewId, int carId)
        {
            var review = await _dbContext.Reviews
                .FirstOrDefaultAsync(c => c.ReviewId == reviewId);

            if (review == null)
            {
                throw new ArgumentException("Review not found!");
            }

            EditReviewViewModel reviewViewModel = new EditReviewViewModel
            {
                AdId = review.AdId,
                CarId = carId,
                ReviewId = review.ReviewId,
                Comment = review.Comment,
                StarsCount = review.StarsCount
            };

            return reviewViewModel;
        }
        public async Task<bool> EditReviewAsync(EditReviewViewModel adViewModel)
        {
            var reviewToEdit = await _dbContext.Reviews
                    .FirstOrDefaultAsync(c => c.ReviewId == adViewModel.ReviewId);

            if (reviewToEdit == null)
            {
                throw new ArgumentException("Review not found!");
            }

            // Update the properties of the existing car entity based on the ViewModel
            reviewToEdit.Comment = adViewModel.Comment;
            reviewToEdit.StarsCount = adViewModel.StarsCount;

            await _dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<List<UsersReviewsViewModel>> GetUserReviewsAsync(int adId)
        {
            List<UsersReviewsViewModel> reviews = await _dbContext.Reviews.Where(a => a.AdId == adId).Select(review => new UsersReviewsViewModel
            {
                CarId = review.Ad.CarId,
                UserId = review.UserId,
                ReviewId = review.ReviewId,
                FirstName = review.User.FirstName,
                LastName = review.User.LastName,
                Comment = review.Comment,
                StarsCount = review.StarsCount
            }).ToListAsync();

            return reviews;
        }
    }
}
