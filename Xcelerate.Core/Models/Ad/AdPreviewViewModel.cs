using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Xcelerate.Infrastructure.Data.Enums;

namespace Xcelerate.Core.Models.Ad
{
	public class AdPreviewViewModel
	{
		[Required]
		public int CarId { get; set; }

		public int AdId { get; set; }


		[Required]
		public string Brand { get; set; } = null!;

		[Required]
		public string Model { get; set; } = null!;

		[Required]
		public int Year { get; set; }

		[Required]
		public string Engine { get; set; } = null!;

		public int HorsePower { get; set; }

		public string CreatedOn { get; set; } = null!;

		public bool IsForSale { get; set; }

		[Required]
		public ConditionEnum Condition { get; set; }

		[Required]
		public EuroStandardEnum EuroStandard { get; set; }

		[Required]
		public FuelTypeEnum FuelType { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required]
		[Comment("FirstName")]
		public string FirstName { get; set; } = null!;

		[Required]
		[Comment("LastName")]
		public string LastName { get; set; } = null!;

		[Required]
		public List<string> ImageUrls { get; set; } = new List<string>();

	}
}
