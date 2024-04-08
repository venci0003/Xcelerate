using Xcelerate.Areas.Admin.Models;

namespace Xcelerate.Areas.Admin.Contracts
{
    public interface IAdminReviewService
    {
        public Task<List<AdminReviewViewModel>> GetUserReviewsForCheckAsync();

        public Task<bool> DeleteReviewAsync(int? reviewId);
    }
}
