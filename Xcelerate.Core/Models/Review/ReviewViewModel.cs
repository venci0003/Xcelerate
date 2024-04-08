using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Core.Models.Review
{
	public class ReviewViewModel
	{
		public Guid UserId { get; set; }

		public string? Comment { get; set; }

		[Required]
		public int StarsCount { get; set; }

		public int ReviewId { get; set; }

	}
}
