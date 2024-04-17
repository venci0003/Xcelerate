using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        [Comment("FuelType")]
        public FuelTypeEnum FuelType { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
