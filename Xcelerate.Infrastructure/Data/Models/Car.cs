namespace Xcelerate.Infrastructure.Data.Models
{
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Xcelerate.Infrastructure.Data.Enums;
	public class Car
	{
		[Key]
		[Comment("CarId")]
		public int CarId { get; set; }

		public ICollection<CarAccessory> CarAccessories { get; set; } = new List<CarAccessory>();

		[Required]
		[Comment("Images")]
		public ICollection<Image> Images { get; set; } = new List<Image>();


		[Required]
		[Comment("Brand")]
		public string Brand { get; set; } = null!;

		[Required]
		[Comment("Model")]
		public string Model { get; set; } = null!;

		[Required]
		[Comment("Year")]
		public int Year { get; set; }

		[Required]
		[ForeignKey(nameof(Engine))]
		public int EngineId { get; set; }

		[Required]
		[Comment("Engine")]
		public Engine Engine { get; set; } = null!;

		[Required]
		[Comment("Condition")]
		public ConditionEnum Condition { get; set; }

		[Required]
		[Comment("EuroStandard")]
		public EuroStandardEnum EuroStandard { get; set; }

		[Required]
		[Comment("FuelType")]
		public FuelTypeEnum FuelType { get; set; }

		[Required]
		[Comment("Colour")]
		public ColourEnum Colour { get; set; }

		[Required]
		[Comment("Transmition")]
		public TransmissionEnum Transmission { get; set; }

		[Required]
		[Comment("DriveTrain")]
		public DriveTrainEnum DriveTrain { get; set; }

		[Required]
		[Comment("Weight")]
		public decimal Weight { get; set; }

		[Required]
		[Comment("Mileage")]
		public int Mileage { get; set; }

		[Required]
		[Comment("Price")]
		public decimal Price { get; set; }

		[Required]
		[Comment("BodyType")]
		public BodyTypeEnum BodyType { get; set; }

		[Required]
		[ForeignKey(nameof(Manufacturer))]
		public int ManufacturerId { get; set; }
		public Manufacturer Manufacturer { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Address))]
		public int AddressId { get; set; }
		public Address Address { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Ad))]
		public int AdId { get; set; }
		public Ad Ad { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
		public bool IsForSale { get; set; }
	}
}
