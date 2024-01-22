using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ICollection<Engine> Engines { get; set; } = new List<Engine>();

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
