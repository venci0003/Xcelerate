using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Xcelerate.Infrastructure.Data.Enums;

namespace Xcelerate.Core.Models.Ad
{
	public class AdCreateViewModel
	{
		public List<string> ImageUrls { get; set; } = new List<string>();

		public List<IFormFile> UploadedImages { get; set; } = new List<IFormFile>();

		public List<AccessoryViewModel> Accessories { get; set; } = new List<AccessoryViewModel>();

		public List<int> SelectedCheckBoxId { get; set; } = new List<int>();

		public AddressViewModel Address { get; set; } = new AddressViewModel();

		public BrandsEnum Brand { get; set; }

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

		public TransmissionEnum Transmission { get; set; }

		public DriveTrainEnum DriveTrain { get; set; }

		public decimal Weight { get; set; }

		public int Mileage { get; set; }

		public int Price { get; set; }

		public BodyTypeEnum BodyType { get; set; }

		public string Manufacturer { get; set; } = null!;

		public string CarDescription { get; set; }
	}
}
