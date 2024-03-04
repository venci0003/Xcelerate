using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class User : IdentityUser<Guid>
    {

        [Required]
        [Comment("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Comment("LastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("Age")]
        public int Age { get; set; }

		public ICollection<Ad> Ads { get; set; } = new List<Ad>();

		public ICollection<Review> Reviews { get; set; } = new List<Review>();

		public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
