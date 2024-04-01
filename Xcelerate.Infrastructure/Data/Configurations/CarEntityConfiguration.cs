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
			builder.HasOne(c => c.Ad)
	.WithOne(a => a.Car)
	.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(c => c.User)
				.WithMany(c => c.Cars)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(c => c.Images)
				.WithOne(c => c.Car)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(a => a.CarAccessories)
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
				Brand = BrandsEnum.Toyota,
				Model = "Camry TRD",
				Year = 2020,
				IsForSale = true,
				EngineId = 1,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Four,
				Colour = ColourEnum.White,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1623.5m,
				Mileage = 30000,
				Price = 25000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 1,
				AddressId = 1,
				AdId = 1,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E")
			};
			cars.Add(firstCar);

			Car secondCar = new Car()
			{
				CarId = 2,
				Brand = BrandsEnum.Honda,
				Model = "Civic Type R",
				Year = 2021,
				IsForSale = true,
				EngineId = 2,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Yellow,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1395.75m,
				Mileage = 15000,
				Price = 62000,
				BodyType = BodyTypeEnum.Hatchback,
				ManufacturerId = 2,
				AddressId = 2,
				AdId = 2,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC")
			};
			cars.Add(secondCar);

			Car thirdCar = new Car()
			{
				CarId = 3,
				Brand = BrandsEnum.Ford,
				Model = "Mustang GT350R",
				Year = 2020,
				IsForSale = true,
				EngineId = 3,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.White,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1600.25m,
				Mileage = 25000,
				Price = 30000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 3,
				AddressId = 3,
				AdId = 3,
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6")
			};
			cars.Add(thirdCar);


			Car fourthCar = new Car()
			{
				CarId = 4,
				Brand = BrandsEnum.Volkswagen,
				Model = "Golf",
				Year = 2019,
				IsForSale = true,
				EngineId = 4,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Five,
				Colour = ColourEnum.White,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1400.75m,
				Mileage = 20000,
				Price = 18000,
				BodyType = BodyTypeEnum.Hatchback,
				ManufacturerId = 4,
				AddressId = 4,
				AdId = 4,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC")
			};
			cars.Add(fourthCar);

			Car fifthCar = new Car()
			{
				CarId = 5,
				Brand = BrandsEnum.MercedesBenz,
				Model = "C-Class",
				Year = 2022,
				IsForSale = true,
				EngineId = 5,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.SlateGray,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 1800.5m,
				Mileage = 10000,
				Price = 40000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 5,
				AddressId = 5,
				AdId = 5,
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF")
			};
			cars.Add(fifthCar);

			Car sixthCar = new Car()
			{
				CarId = 6,
				Brand = BrandsEnum.Audi,
				Model = "A3",
				Year = 2022,
				IsForSale = true,
				EngineId = 6, 
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Six,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1500.25m,
				Mileage = 30000,
				Price = 28000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 6,
				AddressId = 6, 
				AdId = 6, 
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA")
			};
			cars.Add(sixthCar);

			Car seventhCar = new Car()
			{
				CarId = 7,
				Brand = BrandsEnum.Infiniti,
				Model = "QX80",
				Year = 2022,
				IsForSale = true,
				EngineId = 7,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Two,
				Colour = ColourEnum.SlateGray,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 2000.0m,
				Mileage = 25000,
				Price = 35000,
				BodyType = BodyTypeEnum.SUV,
				ManufacturerId = 7,
				AddressId = 7,
				AdId = 7,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020")
			};
			cars.Add(seventhCar);


			Car eighthCar = new Car()
			{
				CarId = 8,
				Brand = BrandsEnum.Hyundai,
				Model = "Elantra",
				Year = 2021,
				IsForSale = true,
				EngineId = 8,
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Five,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1400.5m,
				Mileage = 15000,
				Price = 23000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 8,
				AddressId = 8,
				AdId = 8,
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C")
			};
			cars.Add(eighthCar);

			Car ninthCar = new Car()
			{
				CarId = 9,
				Brand = BrandsEnum.BMW,
				Model = "3 Series",
				Year = 2022,
				IsForSale = true,
				EngineId = 9,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.One,
				Colour = ColourEnum.SlateGray,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.AllWheelDrive,
				Weight = 1700.0m,
				Mileage = 320000,
				Price = 42000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 9, 
				AddressId = 9, 
				AdId = 9, 
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0")
			};
			cars.Add(ninthCar);

			Car tenthCar = new Car()
			{
				CarId = 10,
				Brand = BrandsEnum.Nissan,
				Model = "Rogue",
				Year = 2021,
				IsForSale = true,
				EngineId = 10,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Four,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1600.75m,
				Mileage = 18000,
				Price = 28000,
				BodyType = BodyTypeEnum.SUV,
				ManufacturerId = 10,  
				AddressId = 10,  
				AdId = 10,  
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709")  
			};
			cars.Add(tenthCar);


			Car eleventhCar = new Car()
			{
				CarId = 11,
				Brand = BrandsEnum.Chevrolet,
				Model = "El Camino SS",
				Year = 1969,
				IsForSale = true,
				EngineId = 11,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Two,
				Colour = ColourEnum.Blue,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1742.85m,
				Mileage = 310000,
				Price = 308000,
				BodyType = BodyTypeEnum.SUV,
				ManufacturerId = 11,  
				AddressId = 11,  
				AdId = 11,  
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020")  
			};
			cars.Add(eleventhCar);

			Car twelfthCar = new Car()
			{
				CarId = 12,
				Brand = BrandsEnum.Chevrolet,
				Model = "Tahoe",
				Year = 2013,
				IsForSale = true,
				EngineId = 12,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Three,
				Colour = ColourEnum.White,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.FourWheelDrive,
				Weight = 2583.05m,
				Mileage = 230000,
				Price = 30000,
				BodyType = BodyTypeEnum.SUV,
				ManufacturerId = 12,  
				AddressId = 12,  
				AdId = 12,  
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C")  
			};
			cars.Add(twelfthCar);

			Car thirteenthCar = new Car()
			{
				CarId = 13,
				Brand = BrandsEnum.Ford,
				Model = " F-350 Super Duty",
				Year = 2000,
				IsForSale = true,
				EngineId = 13,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Two,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FourWheelDrive,
				Weight = 1353.05m,
				Mileage = 190000,
				Price = 42000,
				BodyType = BodyTypeEnum.SUV,
				ManufacturerId = 13,  
				AddressId = 13,  
				AdId = 13,  
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA")  
			};
			cars.Add(thirteenthCar);

			Car fourteenthCar = new Car()
			{
				CarId = 14,
				Brand = BrandsEnum.Renault,
				Model = "Clio",
				Year = 2013,
				IsForSale = true,
				EngineId = 14,  
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Five,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FourWheelDrive,
				Weight = 1240.55m,
				Mileage = 10000,
				Price = 22000,
				BodyType = BodyTypeEnum.Hatchback,
				ManufacturerId = 14,  
				AddressId = 14,  
				AdId = 14,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6")  
			};
			cars.Add(fourteenthCar);

			Car fifteenthCar = new Car()
			{
				CarId = 15,
				Brand = BrandsEnum.MercedesBenz,
				Model = "W140",
				Year = 1998,
				IsForSale = true,
				EngineId = 15,  
				Condition = ConditionEnum.BrandNew,
				EuroStandard = EuroStandardEnum.Three,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1240.55m,
				Mileage = 40186,
				Price = 280000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 15,  
				AddressId = 15,  
				AdId = 15,  
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF")  
			};
			cars.Add(fifteenthCar);

			Car sixteenthCar = new Car()
			{
				CarId = 16,
				Brand = BrandsEnum.Acura,
				Model = "RSX Type-S",
				Year = 2005,
				IsForSale = true,
				EngineId = 16,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Three,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1420.15m,
				Mileage = 100200,
				Price = 80000,
				BodyType = BodyTypeEnum.Coupe,
				ManufacturerId = 16,  
				AddressId = 16,  
				AdId = 16,  
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709")  
			};
			cars.Add(sixteenthCar);

			Car seventeenthCar = new Car()
			{
				CarId = 17,
				Brand = BrandsEnum.Acura,
				Model = "NSX",
				Year = 2005,
				IsForSale = true,
				EngineId = 16,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Four,
				Colour = ColourEnum.Blue,
				Transmission = TransmissionEnum.Automatic,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1510.25m,
				Mileage = 210000,
				Price = 230000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 17,  
				AddressId = 17,  
				AdId = 17,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6")  
			};
			cars.Add(seventeenthCar);

			Car eighteenthCar = new Car()
			{
				CarId = 18,
				Brand = BrandsEnum.Saab,
				Model = "9-3 Aero",
				Year = 2001,
				IsForSale = true,
				EngineId = 18,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Three,
				Colour = ColourEnum.SlateGray,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1710.25m,
				Mileage = 170000,
				Price = 50000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 18,  
				AddressId = 18,  
				AdId = 18,  
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC")  
			};
			cars.Add(eighteenthCar);

			Car nineteenthCar = new Car()
			{
				CarId = 19,
				Brand = BrandsEnum.Saab,
				Model = "93 SportCombi",
				Year = 2006,
				IsForSale = true,
				EngineId = 19,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Four,
				Colour = ColourEnum.White,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1810.15m,
				Mileage = 152000,
				Price = 70000,
				BodyType = BodyTypeEnum.Wagon,
				ManufacturerId = 19,  
				AddressId = 19,  
				AdId = 19,  
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0")  
			};
			cars.Add(nineteenthCar);

			Car twentiethCar = new Car()
			{
				CarId = 20,
				Brand = BrandsEnum.Renault,
				Model = "Megane II",
				Year = 2003,
				IsForSale = true,
				EngineId = 20,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Five,
				Colour = ColourEnum.Teal,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1510.15m,
				Mileage = 213000,
				Price = 40000,
				BodyType = BodyTypeEnum.Coupe,
				ManufacturerId = 20,  
				AddressId = 20,  
				AdId = 20,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6")  
			};
			cars.Add(twentiethCar);

			Car twentiethFirstCar = new Car()
			{
				CarId = 21,
				Brand = BrandsEnum.Honda,
				Model = "S2000",
				Year = 2004,
				IsForSale = true,
				EngineId = 21,  
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Four,
				Colour = ColourEnum.Red,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.RearWheelDrive,
				Weight = 1320.25m,
				Mileage = 113000,
				Price = 30000,
				BodyType = BodyTypeEnum.Coupe,
				ManufacturerId = 21, 
				AddressId = 21,
				AdId = 21, 
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC") 
			};
			cars.Add(twentiethFirstCar);

			Car twentiethSecondCar = new Car()
			{
				CarId = 22,
				Brand = BrandsEnum.Honda,
				Model = "Civic Si",
				Year = 2004,
				IsForSale = true,
				EngineId = 22,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Five,
				Colour = ColourEnum.White,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1360.25m,
				Mileage = 123000,
				Price = 15000,
				BodyType = BodyTypeEnum.Hatchback,
				ManufacturerId = 22, 
				AddressId = 22, 
				AdId = 22, 
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF") 
			};
			cars.Add(twentiethSecondCar);

			Car twentiethThirdCar = new Car()
			{
				CarId = 23,
				Brand = BrandsEnum.Honda,
				Model = "Accord",
				Year = 1993,
				IsForSale = true,
				EngineId = 23,
				Condition = ConditionEnum.Used,
				EuroStandard = EuroStandardEnum.Three,
				Colour = ColourEnum.Black,
				Transmission = TransmissionEnum.Manual,
				DriveTrain = DriveTrainEnum.FrontWheelDrive,
				Weight = 1410.35m,
				Mileage = 212000,
				Price = 180000,
				BodyType = BodyTypeEnum.Sedan,
				ManufacturerId = 23,
				AddressId = 23,
				AdId = 23,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020")
			};
			cars.Add(twentiethThirdCar);


			return cars;
		}
	}
}
