using System.ComponentModel.DataAnnotations;
using static Xcelerate.Common.EntityValidation.AddressEntity;

namespace Xcelerate.Core.Models.Ad
{
	public class AddressViewModel
	{
		[Required(ErrorMessage = "Country name is required.")]
		[StringLength(CountryNameMaxLength, ErrorMessage = "Country name must be between {2} and {1} characters.", MinimumLength = CountryNameMinLength)]
		public string CountryName { get; set; } = null!;

		[Required(ErrorMessage = "Town name is required.")]
		[StringLength(TownNameMaxLength, ErrorMessage = "Town name must be between {2} and {1} characters.", MinimumLength = TownNameMinLength)]
		public string TownName { get; set; } = null!;

		[Required(ErrorMessage = "Street name is required.")]
		[StringLength(StreetNameMaxLength, ErrorMessage = "Street name must be between {2} and {1} characters.", MinimumLength = StreetNameMinLength)]
		public string StreetName { get; set; } = null!;
	}
}
