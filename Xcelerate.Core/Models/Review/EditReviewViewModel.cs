using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Core.Models.Review
{
	public class EditReviewViewModel 
	{
		public string? Comment { get; set; }

		[Required]
		public int StarsCount { get; set; }

		public int ReviewId { get; set; }

        public int AdId { get; set; }

		public int CarId { get; set; }
	}
}
