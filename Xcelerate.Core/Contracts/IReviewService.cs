﻿using Xcelerate.Core.Models.Review;

namespace Xcelerate.Core.Contracts
{
	public interface IReviewService
	{
		public Task<List<UsersReviewsViewModel>> GetUserReviewsAsync(int adId);

		public Task CreateReviewAsync(ReviewViewModel reviewModel, string userId, int adId);

		public Task<bool> DeleteReviewAsync(int? reviewId);

		public Task<EditReviewViewModel> GetEditInformationAsync(int? reviewId);

		public Task<bool> EditReviewAsync(EditReviewViewModel reviewViewModel);
	}
}
