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

        public ICollection<Car> Cars { get; set; }
    }
}
