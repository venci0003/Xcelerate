using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Review
    {
        [Key]
        [Comment("ReviewId")]
        public int ReviewId { get; set; }

        [Required]
        [Comment("ReviewsCount")]
        public int ReviewsCount { get; set; }

        [Comment("Comment")]
        public string? Comment { get; set; }

        [Required]
        [Comment("StarsCount")]
        public int StarsCount { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
