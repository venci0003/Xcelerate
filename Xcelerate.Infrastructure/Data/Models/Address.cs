using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Address
    {
        [Key]
        [Comment("AddressId")]
        public int AddressId { get; set; }

        [Required]
        [Comment("CountryName")]
        public string CountryName { get; set; } = null!;

        [Required]
        [Comment("TownName")]
        public string TownName { get; set; } = null!;

        [Required]
        [Comment("StreetName")]
        public string StreetName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
