using System.ComponentModel.DataAnnotations.Schema;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class CarAccessory
	{
		[ForeignKey(nameof(Accessory))]
		public int AccessoryId { get; set; }
		public Accessory Accessory { get; set; } = null!;

		[ForeignKey(nameof(Car))]
		public int CarId { get; set; }
		public Car Car { get; set; } = null!;

	}
}
