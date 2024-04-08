using Xcelerate.Core.Models.Review;

namespace Xcelerate.Areas.Admin.Models
{
	public class AdminHomeViewModel
	{
		public int AdId { get; set; }
		public int CarId { get; set; }
		public List<AdminReviewViewModel> Reviews { get; set; } = new List<AdminReviewViewModel>();
	}
}
