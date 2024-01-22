using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xcelerate.Infrastructure.Data.Models
{
    public class Image
	{
		[Key]
		public int ImageId { get; set; }

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Car))]
		public int CarId { get; set; }
        public Car Car { get; set; } = null!;
	}
}
