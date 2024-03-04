using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Xcelerate.Core.Models.Review;
using Xcelerate.Infrastructure.Data.Enums;

namespace Xcelerate.Core.Models.Ad
{
	public class AdInformationViewModel
	{
		public Guid UserId { get; set; }

		[Required]
		[Comment("FirstName")]
		public string FirstName { get; set; } = null!;

		[Required]
		[Comment("LastName")]
		public string LastName { get; set; } = null!;
		public int CarId { get; set; }
		public List<string> ImageUrls { get; set; } = new List<string>();

		public List<IFormFile> UploadedImages { get; set; } = new List<IFormFile>();

		public List<AccessoryViewModel> Accessories { get; set; } = new List<AccessoryViewModel>();

		public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();

		public List<int> SelectedCheckBoxId { get; set; } = new List<int>();

		public AddressViewModel Address { get; set; } = new AddressViewModel();

		public string Brand { get; set; } = null!;

		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public bool IsForSale { get; set; }

		public string Model { get; set; } = null!;

		public int Year { get; set; }

		public string Engine { get; set; } = null!;

		public int HorsePower { get; set; }

		public ConditionEnum Condition { get; set; }

		public EuroStandardEnum EuroStandard { get; set; }

		public FuelTypeEnum FuelType { get; set; }

		public ColourEnum Colour { get; set; }

		public TransmitionEnum Transmition { get; set; }

		public DriveTrainEnum DriveTrain { get; set; }

		public decimal Weight { get; set; }

		public int Mileage { get; set; }

		public decimal Price { get; set; }

		public BodyTypeEnum BodyType { get; set; }

		public string Manufacturer { get; set; } = null!;

		public string CarDescription { get; set; } = null!;

	}
}
