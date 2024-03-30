namespace Xcelerate.Common
{
	public class EntityValidation
	{
		public static class UserEntity
		{
			// First and last name validations
			public const int FirstNameMinLength = 4;

			public const int FirstNameMaxLength = 30;

			public const int LastNameMinLength = 4;

			public const int LastNameMaxLength = 30;

			// Email validations
			public const int EmailAddressMinValue = 15;

			public const int EmailAddressMaxValue = 30;

			public const int PasswordMinLength = 8;

			public const int PasswordMaxLength = 20;
		};


		public static class ReviewEntity
		{
			public const int StarsCountMinValue = 1;

			public const int StarsCountMaxValue = 6;
		};

		public static class ManufacturerEntity
		{
			// Manufacturer name validations
			public const int NameMinLength = 4;

			public const int NameMaxLength = 20;
		};

		public static class EngineEntity
		{
			// Model name validations
			public const int ModelNameMinLength = 4;

			public const int ModelNameMaxLength = 25;

			// HorsePower validations
			public const int HorsePowerMinValue = 10;

			public const int HorsePowerMaxValue = 4000;

			// Cylinder validations
			public const int CylinderMinValue = 2;

			public const int CylinderMaxValue = 16;

		};

		public static class CarEntity
		{
			// Brand name validations
			public const int BrandNameMinLength = 2;

			public const int BrandNameMaxLength = 20;

			// Model name validations
			public const int ModelNameMinLength = 2;

			public const int ModelNameMaxLength = 20;

			// Manufacturer validations
			public const int ManufacturerNameMinLength = 2;

			public const int ManufacturerNameMaxLength = 20;
  
			// Weight validations
			public const decimal WeightMinValue = 500.00M;

			public const decimal WeightMaxValue = 4000.00M;

			// Mileage validations
			public const int MileageMinValue = 0;

			public const int MileageMaxValue = 100000000;

			// Price validations
			public const int PriceMinValue = 250;

			public const int PriceMaxValue = 100000000;
		}

		public static class AddressEntity
		{
			// Country name validations
			public const int CountryNameMinLength = 4;

			public const int CountryNameMaxLength = 50;

			// Town name validations
			public const int TownNameMinLength = 4;

			public const int TownNameMaxLength = 50;

			// Street name validations
			public const int StreetNameMinLength = 4;

			public const int StreetNameMaxLength = 50;
		}

		public static class AdEntity
		{
			// Car description validations
			public const int CarDescriptionMinLength = 20;

			public const int CarDescriptionMaxLength = 300;

			public const string CreatedOnDateFormat = "yyyy-dd-MM";
		}
	}
}
