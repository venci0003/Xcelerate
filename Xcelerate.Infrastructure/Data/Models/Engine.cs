using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Enums;

namespace Xcelerate.Infrastructure.Data.Models
{
    public class Engine
    {
        [Key]
        [Comment("EngineId")]
        public int EngineId { get; set; }

        [Required]
        [Comment("Model")]
        public string Model { get; set; } = null!;

        [Required]
        [Comment("Horsepower")]
        public int Horsepower { get; set; }

        [Required]
        [Comment("CylinderCount")]
        public int CylinderCount { get; set; }

        [Comment("FuelType")]
        public FuelTypeEnum FuelType { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
