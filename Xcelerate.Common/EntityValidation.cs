using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //// Age validations
            //public const int AgeMinValue = 16;

            //public const int AgeMaxValue = 99;
        };


        public static class ReviewEntity
        {
            // Stars validations
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
            public const int HorsePowerMinValue = 0;

            public const int HorsePowerMaxValue = 2000;

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

            // Year validations

            public const int YearMinValue = 1990;

            public const int YearMaxValue = 2024;

            // Weight validations
            public const decimal WeightMinValue = 600.00M;

            public const decimal WeightMaxValue = 3000.00M;

            // Mileage validations
            public const int MileageMinValue = 0;

            public const int MileageMaxValue = int.MaxValue;

            // Price validations
            public const decimal PriceMinValue = 0.00M;

            public const decimal PriceMaxValue = 100000000.00M;
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
        }
    }
}
