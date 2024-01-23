using Xcelerate.Infrastructure.Data.Enums;

namespace Xcelerate.Core.Models.Ad
{
    public class AdInformationViewModel
    {
        public List<string> ImageUrls { get; set; } = null!;

        public List<AccessoryViewModel> Accessories { get; set; } = null!;

		public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public string Engine { get; set; } = null!; 

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

        public string Description { get; set; }

        // You can include necessary properties from the Address entity

        // You can include necessary properties from the Ad entity

        // You can include necessary properties from the User entity
    }
}
