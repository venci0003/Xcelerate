namespace Xcelerate.Areas.Admin.Contracts
{
	using Models;
	public interface IAdminReviewService
	{
		public Task<List<AdminReviewViewModel>> GetUserReviewsForCheckAsync();

		public Task<bool> DeleteReviewAsync(int? reviewId);
	}
}
