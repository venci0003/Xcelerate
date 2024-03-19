﻿using Microsoft.AspNetCore.Http;
using Xcelerate.Core.Models.Review;
using Xcelerate.Infrastructure.Data.Enums;

namespace Xcelerate.Core.Models.Ad
{
	using Xcelerate.Core.Models.Pager;
	public class AdInformationViewModel
	{
		public Guid UserId { get; set; }
		public int AdId { get; set; }
		public int CarId { get; set; }
		public List<string> ImageUrls { get; set; } = new List<string>();
		public List<IFormFile> UploadedImages { get; set; } = new List<IFormFile>();
		public List<AccessoryViewModel> Accessories { get; set; } = new List<AccessoryViewModel>();
		public List<UsersReviewsViewModel> Reviews { get; set; } = new List<UsersReviewsViewModel>();
		public List<int> SelectedCheckBoxId { get; set; } = new List<int>();
		public AddressViewModel Address { get; set; } = new AddressViewModel();
		public IEnumerable<AdPreviewViewModel> Ads { get; set; } = new List<AdPreviewViewModel>();
		public string Brand { get; set; }
		public string CreatedOn { get; set; }
		public bool IsForSale { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string Engine { get; set; }
		public int HorsePower { get; set; }
		public ConditionEnum? Condition { get; set; }
		public EuroStandardEnum? EuroStandard { get; set; }
		public FuelTypeEnum? FuelType { get; set; }
		public ColourEnum? Colour { get; set; }
		public TransmissionEnum? Transmition { get; set; }
		public DriveTrainEnum? DriveTrain { get; set; }
		public decimal Weight { get; set; }
		public int Mileage { get; set; }
		public decimal Price { get; set; }
		public BodyTypeEnum? BodyType { get; set; }
		public string Manufacturer { get; set; }
		public string CarDescription { get; set; }
		public Pager Pager { get; set; }
		public int CurrentPage { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}
