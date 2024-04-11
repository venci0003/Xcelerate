namespace Xcelerate.Areas.Admin.Models
{
	using System.ComponentModel.DataAnnotations;
	public class AdminReviewViewModel
	{
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public Guid UserId { get; set; }

		public string? Comment { get; set; }

		[Required]
		public int StarsCount { get; set; }

		public int ReviewId { get; set; }
	}
}
