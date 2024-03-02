using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Ad
    {
        [Key]
        [Required]
        [Comment("Id")]
        public int AdId { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        [Required]
        public string CarDescription { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
