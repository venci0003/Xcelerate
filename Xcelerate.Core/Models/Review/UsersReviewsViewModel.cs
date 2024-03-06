namespace Xcelerate.Core.Models.Review
{
	public class UsersReviewsViewModel : ReviewViewModel
	{
		public int CarId { get; set; }
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;
	}
}
