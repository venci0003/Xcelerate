using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Core.Models.Review
{
	public class ReviewViewModel
	{
		public Guid UserId { get; set; }

		public int AdId { get; set; }

		public int CarId { get; set; }
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public int ReviewId { get; set; }

		public string? Comment { get; set; }

		[Required]
		public int StarsCount { get; set; }


	}
}
