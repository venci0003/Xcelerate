using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Accessory
	{
		[Key]
		public int AccessoryId { get; set; }

		public string Name { get; set; } = null!;

		public ICollection<CarAccessory> CarAccessories { get; set; } = new List<CarAccessory>();
	}
}
