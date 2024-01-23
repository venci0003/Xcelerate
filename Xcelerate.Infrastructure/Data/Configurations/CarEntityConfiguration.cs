using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Enums;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.User)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(c => c.Images)
				.WithOne(c => c.Car)
				.OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(a => a.Accessories)
                .WithOne(c => c.Car)
                .OnDelete(DeleteBehavior.NoAction);

			builder.Property(c => c.Price)
            .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Weight)
            .HasColumnType("decimal(18,2)");

            ICollection<Car> carsCollection = CreateCars();
            builder.HasData(CreateCars());
        }

        private ICollection<Car> CreateCars()
        {
            List<Car> cars = new List<Car>();

            Car firstCar = new Car()
            {
                CarId = 1,
				Brand = "Toyota",
                Model = "Camry TRD",
                Year = 2020,
                EngineId = 1, // Assuming you have an Engine with EngineId = 1
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroFour,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.White,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.FrontWheelDrive,
                Weight = 1623.5m,
                Mileage = 30000,
                Price = 25000.50m,
                BodyType = BodyTypeEnum.Sedan,
                ManufacturerId = 1, // Assuming you have a Manufacturer with ManufacturerId = 1
                AddressId = 1, // Assuming you have an Address with AddressId = 1
                AdId = 1, // Assuming you have an Ad with AdId = 1
                UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E") // Assuming you have a User with UserId = 1
			};

            Car secondCar = new Car()
            {
                CarId = 2,
                Brand = "Honda",
                Model = "Civic Type R Limited Edition",
                Year = 2021,
                EngineId = 2, // Assuming you have an Engine with EngineId = 2
                Condition = ConditionEnum.BrandNew,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.Yellow,
                Transmition = TransmitionEnum.Manual,
                DriveTrain = DriveTrainEnum.FrontWheelDrive,
                Weight = 1395.75m,
                Mileage = 15000,
                Price = 62000.75m,
                BodyType = BodyTypeEnum.Hatchback,
                ManufacturerId = 2, // Assuming you have a Manufacturer with ManufacturerId = 2
                AddressId = 2, // Assuming you have an Address with AddressId = 2
                AdId = 2, // Assuming you have an Ad with AdId = 2
                UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC") // Assuming you have a User with UserId = 2
			};

            Car thirdCar = new Car()
            {
                CarId = 3,
                Brand = "Ford",
                Model = "Mustang Shelby GT350R",
                Year = 2020,
                EngineId = 3, // Assuming you have an Engine with EngineId = 3
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.White,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.RearWheelDrive,
                Weight = 1600.25m,
                Mileage = 25000,
                Price = 30000.25m,
                BodyType = BodyTypeEnum.Sedan,
                ManufacturerId = 3, // Assuming you have a Manufacturer with ManufacturerId = 3
                AddressId = 3, // Assuming you have an Address with AddressId = 3
                AdId = 3, // Assuming you have an Ad with AdId = 3
                UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6") // Assuming you have a User with UserId = 3
			};

            Car fourthCar = new Car()
            {
                CarId = 4,
                Brand = "Volkswagen",
                Model = "Golf",
                Year = 2019,
                EngineId = 4, // Assuming you have an Engine with EngineId = 4
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroFive,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.White,
                Transmition = TransmitionEnum.Manual,
                DriveTrain = DriveTrainEnum.FrontWheelDrive,
                Weight = 1400.75m,
                Mileage = 20000,
                Price = 18000.75m,
                BodyType = BodyTypeEnum.Hatchback,
                ManufacturerId = 4, // Assuming you have a Manufacturer with ManufacturerId = 4
                AddressId = 4, // Assuming you have an Address with AddressId = 4
                AdId = 4, // Assuming you have an Ad with AdId = 4
                UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC") // Assuming you have a User with UserId = 4
			};

            // Add six more cars as needed

            Car fifthCar = new Car()
            {
                CarId = 5,
                Brand = "Mercedes-Benz",
                Model = "C-Class",
                Year = 2022,
                EngineId = 5, // Assuming you have an Engine with EngineId = 5
                Condition = ConditionEnum.BrandNew,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.White,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.AllWheelDrive,
                Weight = 1800.5m,
                Mileage = 10000,
                Price = 40000.5m,
                BodyType = BodyTypeEnum.Sedan,
                ManufacturerId = 5, // Assuming you have a Manufacturer with ManufacturerId = 5
                AddressId = 5, // Assuming you have an Address with AddressId = 5
                AdId = 5, // Assuming you have an Ad with AdId = 5
                UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF") // Assuming you have a User with UserId = 5
			};

            Car sixthCar = new Car()
            {
                CarId = 6,
                Brand = "Audi",
                Model = "A3",
                Year = 2022,
                EngineId = 6, // Assuming you have an Engine with EngineId = 6
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Diesel,
                Colour = ColourEnum.Red,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.FrontWheelDrive,
                Weight = 1500.25m,
                Mileage = 30000,
                Price = 28000.25m,
                BodyType = BodyTypeEnum.Sedan,
                ManufacturerId = 6, // Assuming you have a Manufacturer with ManufacturerId = 6
                AddressId = 6, // Assuming you have an Address with AddressId = 6
                AdId = 6, // Assuming you have an Ad with AdId = 6
                UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA") // Assuming you have a User with UserId = 6
			};

            Car seventhCar = new Car()
            {
                CarId = 7,
                Brand = "Infiniti",
                Model = "QX80",
                Year = 2022,
                EngineId = 7, // Assuming you have an Engine with EngineId = 7
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.Brown,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.AllWheelDrive,
                Weight = 2000.0m,
                Mileage = 25000,
                Price = 35000.0m,
                BodyType = BodyTypeEnum.SUV,
                ManufacturerId = 7, // Assuming you have a Manufacturer with ManufacturerId = 7
                AddressId = 7, // Assuming you have an Address with AddressId = 7
                AdId = 7, // Assuming you have an Ad with AdId = 7
                UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020") // Assuming you have a User with UserId = 7
			};

            Car eighthCar = new Car()
            {
                CarId = 8,
                Brand = "Hyundai",
                Model = "Elantra",
                Year = 2021,
                EngineId = 8, // Assuming you have an Engine with EngineId = 8
                Condition = ConditionEnum.BrandNew,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Petrol,
                Colour = ColourEnum.White,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.FrontWheelDrive,
                Weight = 1400.5m,
                Mileage = 15000,
                Price = 23000.5m,
                BodyType = BodyTypeEnum.Sedan,
                ManufacturerId = 8, // Assuming you have a Manufacturer with ManufacturerId = 8
                AddressId = 8, // Assuming you have an Address with AddressId = 8
                AdId = 8, // Assuming you have an Ad with AdId = 8
                UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C") // Assuming you have a User with UserId = 8
			};

            Car ninthCar = new Car()
            {
                CarId = 9,
                Brand = "BMW",
                Model = "3 Series",
                Year = 2022,
                EngineId = 9, // Assuming you have an Engine with EngineId = 9
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroThree,
                FuelType = FuelTypeEnum.Diesel,
                Colour = ColourEnum.SlateGray,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.AllWheelDrive,
                Weight = 1700.0m,
                Mileage = 320000,
                Price = 42000.0m,
                BodyType = BodyTypeEnum.Sedan,
                ManufacturerId = 9, // Assuming you have a Manufacturer with ManufacturerId = 9
                AddressId = 9, // Assuming you have an Address with AddressId = 9
                AdId = 9, // Assuming you have an Ad with AdId = 9
                UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0") // Assuming you have a User with UserId = 9
			};

            Car tenthCar = new Car()
            {
                CarId = 10,
                Brand = "Nissan",
                Model = "Rogue",
                Year = 2021,
                EngineId = 10, // Assuming you have an Engine with EngineId = 10
                Condition = ConditionEnum.Used,
                EuroStandard = EuroStandardEnum.EuroSix,
                FuelType = FuelTypeEnum.Diesel,
                Colour = ColourEnum.Red,
                Transmition = TransmitionEnum.Automatic,
                DriveTrain = DriveTrainEnum.FrontWheelDrive,
                Weight = 1600.75m,
                Mileage = 18000,
                Price = 28000.75m,
                BodyType = BodyTypeEnum.SUV,
                ManufacturerId = 10, // Assuming you have a Manufacturer with ManufacturerId = 10
                AddressId = 10, // Assuming you have an Address with AddressId = 10
                AdId = 10, // Assuming you have an Ad with AdId = 10
                UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709") // Assuming you have a User with UserId = 10
			};

            // Add more cars as needed

            cars.Add(firstCar);
            cars.Add(secondCar);
            cars.Add(thirdCar);
            cars.Add(fourthCar);
            cars.Add(fifthCar);
            cars.Add(sixthCar);
            cars.Add(seventhCar);
            cars.Add(eighthCar);
            cars.Add(ninthCar);
            cars.Add(tenthCar);

            return cars;
        }
    }
}
