﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Xcelerate.Infrastructure.Data.Enums;
using static Xcelerate.Common.EntityValidation;

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

		[Required(ErrorMessage = "Model name is required.")]
		[StringLength(CarEntity.ModelNameMaxLength, ErrorMessage = "Model name must be between {2} and {1} characters.", MinimumLength = CarEntity.ModelNameMinLength)]
		public string Model { get; set; } = null!;

		public int Year { get; set; }

		[Required(ErrorMessage = "Engine name is required.")]
		[StringLength(EngineEntity.ModelNameMaxLength, ErrorMessage = "Engine name must be between {2} and {1} characters.", MinimumLength = EngineEntity.ModelNameMinLength)]
		public string Engine { get; set; } = null!;

		[Range(EngineEntity.HorsePowerMinValue, EngineEntity.HorsePowerMaxValue, ErrorMessage = "Horsepower must be between {1} and {2}.")]
		public int HorsePower { get; set; }

		public ConditionEnum Condition { get; set; }

		public EuroStandardEnum EuroStandard { get; set; }

		public FuelTypeEnum FuelType { get; set; }

		public ColourEnum Colour { get; set; }

		public TransmissionEnum Transmission { get; set; }

		public DriveTrainEnum DriveTrain { get; set; }

		[Range((double)CarEntity.WeightMinValue, (double)CarEntity.WeightMaxValue, ErrorMessage = "Weight must be between {1} and {2}.")]
		public decimal Weight { get; set; }

		[Required(ErrorMessage = "Mileage value is required.")]
		[Range(CarEntity.MileageMinValue, CarEntity.MileageMaxValue, ErrorMessage = "Mileage must be between {1}KM and {2}KM.")]
		public int Mileage { get; set; }

		[Required(ErrorMessage = "Price value is required.")]
		[Range(CarEntity.PriceMinValue, CarEntity.PriceMaxValue, ErrorMessage = "Price must be between {1}$ and {2}$.")]
		public int Price { get; set; }

		public BodyTypeEnum BodyType { get; set; }

		[Required(ErrorMessage = "Manufacturer name is required.")]
		[StringLength(CarEntity.ManufacturerNameMaxLength, ErrorMessage = "Manufacturer name must be between {2} and {1} characters.", MinimumLength = CarEntity.ManufacturerNameMinLength)]
		public string Manufacturer { get; set; } = null!;

		[Required(ErrorMessage = "Description is required.")]
		[StringLength(AdEntity.CarDescriptionMaxLength, ErrorMessage = "Description must be between {2} and {1} characters.", MinimumLength = AdEntity.CarDescriptionMinLength)]
		public string CarDescription { get; set; }

		public int UnreadMessageCount { get; set; }
	}
}
