using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Xcelerate.Infrastructure.Data.Enums;
using static Xcelerate.Common.EntityValidation;

namespace Xcelerate.Core.Models.Ad
{
	public class AdPreviewViewModel
	{
		[Required]
		public int CarId { get; set; }

		public int AdId { get; set; }

		[Required]
		public BrandsEnum Brand { get; set; }

		[Required(ErrorMessage = "Model name is required.")]
		[StringLength(CarEntity.ModelNameMaxLength, ErrorMessage = "Model name must be between {2} and {1} characters.", MinimumLength = CarEntity.ModelNameMinLength)]
		public string Model { get; set; } = null!;

		[Required]
		public int Year { get; set; }

		[Required(ErrorMessage = "Engine name is required.")]
		[StringLength(EngineEntity.ModelNameMaxLength, ErrorMessage = "Engine name must be between {2} and {1} characters.", MinimumLength = EngineEntity.ModelNameMinLength)]
		public string Engine { get; set; } = null!;

		[Range(EngineEntity.HorsePowerMinValue, EngineEntity.HorsePowerMaxValue, ErrorMessage = "Horsepower must be between {1} and {2}.")]
		public int HorsePower { get; set; }

		public string CreatedOn { get; set; } = null!;

		public bool IsForSale { get; set; }

		[Required]
		public ConditionEnum Condition { get; set; }

		[Required]
		public EuroStandardEnum EuroStandard { get; set; }

		[Required]
		public FuelTypeEnum FuelType { get; set; }


		[DataType(DataType.Currency)]
		[Required(ErrorMessage = "Price value is required.")]
		[Range(CarEntity.PriceMinValue, CarEntity.PriceMaxValue, ErrorMessage = "Price must be between {1}$ and {2}$.")]
		public int Price { get; set; }

		[Required]
		[Comment("FirstName")]
		public string FirstName { get; set; } = null!;

		[Required]
		[Comment("LastName")]
		public string LastName { get; set; } = null!;

		[Required]
		public List<string> ImageUrls { get; set; } = new List<string>();

		public int UnreadMessageCount { get; set; }

	}
}
