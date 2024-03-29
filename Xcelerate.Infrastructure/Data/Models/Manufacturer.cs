using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Manufacturer
    {
        [Key]
        [Comment("ManufacturerId")]
        public int ManufacturerId { get; set; }
        [Required]
        [Comment("Name")]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
