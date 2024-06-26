﻿using Microsoft.EntityFrameworkCore;
using System.Net;
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

		public async Task CreateReviewAsync(ReviewViewModel reviewModel, string userId, int adId)
		{
			try
			{
				var newReview = new Review
				{
					AdId = adId,
					UserId = Guid.Parse(userId),
					Comment = WebUtility.HtmlEncode(reviewModel.Comment),
					StarsCount = reviewModel.StarsCount,
				};

				StatisticalData? statisticsUpdate = await _dbContext.StatisticalData.FirstOrDefaultAsync();

				statisticsUpdate.CreatedReviews += 1;

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

		public async Task<EditReviewViewModel> GetEditInformationAsync(int? reviewId)
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

			reviewToEdit.Comment = WebUtility.HtmlEncode(adViewModel.Comment);
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
