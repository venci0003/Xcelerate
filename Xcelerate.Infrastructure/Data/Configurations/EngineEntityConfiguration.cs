using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Enums;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class EngineEntityConfiguration : IEntityTypeConfiguration<Engine>
	{
		public void Configure(EntityTypeBuilder<Engine> builder)
		{
			builder
				.HasMany(e => e.Cars)
				.WithOne(e => e.Engine)
				.OnDelete(DeleteBehavior.NoAction);

			ICollection<Engine> enginesCollection = CreateEngines();
			builder.HasData(CreateEngines());
		}

		private ICollection<Engine> CreateEngines()
		{
			List<Engine> engines = new List<Engine>();

			Engine engineOne = new Engine()
			{
				EngineId = 1,
				Model = "V6",
				Horsepower = 301,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineOne);

			Engine engineTwo = new Engine()
			{
				EngineId = 2,
				Model = "In-Line 4-Cylinder with Turbocharger",
				Horsepower = 306,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineTwo);

			Engine engineThree = new Engine()
			{
				EngineId = 3,
				Model = "5.2-liter V-8 engine",
				Horsepower = 526,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineThree);

			Engine engineFour = new Engine()
			{
				EngineId = 4,
				Model = "1.4L Turbo Inline-4",
				Horsepower = 147,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineFour);

			Engine engineFive = new Engine()
			{
				EngineId = 5,
				Model = "Turbocharged 2.0",
				Horsepower = 255,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineFive);

			Engine engineSix = new Engine()
			{
				EngineId = 6,
				Model = "2.0",
				Horsepower = 306,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineSix);

			Engine engineSeven = new Engine()
			{
				EngineId = 7,
				Model = "5.6-liter V-8 ",
				Horsepower = 400,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineSeven);

			Engine engineEight = new Engine()
			{
				EngineId = 8,
				Model = "Turbocharged N Line",
				Horsepower = 147,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineEight);

			Engine engineNine = new Engine()
			{
				EngineId = 9,
				Model = "Twin-turbo 3.0-liter inline-six",
				Horsepower = 473,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineNine);

			Engine engineTen = new Engine()
			{
				EngineId = 10,
				Model = "2.5",
				Horsepower = 181,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineTen);

			Engine engineEleven = new Engine()
			{
				EngineId = 11,
				Model = "V8",
				Horsepower = 60,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineEleven);

			Engine engineTwelve = new Engine()
			{
				EngineId = 12,
				Model = "5.3L",
				Horsepower = 320,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineTwelve);

			Engine engineThirteen = new Engine()
			{
				EngineId = 13,
				Model = "5.4L",
				Horsepower = 260,
				CylinderCount = 8,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineThirteen);

			Engine engineFourteen = new Engine()
			{
				EngineId = 14,
				Model = "EDC 1.4",
				Horsepower = 85,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Diesel,
			};
			engines.Add(engineFourteen);

			Engine engineFifteen = new Engine()
			{
				EngineId = 15,
				Model = "S600L",
				Horsepower = 389,
				CylinderCount = 12,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineFifteen);

			Engine engineSixteen = new Engine()
			{
				EngineId = 16,
				Model = "DOHC i-VTEC 2.0",
				Horsepower = 210,
				CylinderCount = 4,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineSixteen);

			Engine engineSeventeen = new Engine()
			{
				EngineId = 17,
				Model = "3.2L DOHC",
				Horsepower = 290,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineSeventeen);

			Engine engineEighteen = new Engine()
			{
				EngineId = 18,
				Model = "B204R",
				Horsepower = 200,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineEighteen);

			Engine engineNineteen = new Engine()
			{
				EngineId = 19,
				Model = "B204L",
				Horsepower = 185,
				CylinderCount = 6,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineNineteen);

			Engine engineTwenty = new Engine()
			{
				EngineId = 20,
				Model = "2.0L",
				Horsepower = 225,
				CylinderCount = 16,
				FuelType = FuelTypeEnum.Petrol,
			};
			engines.Add(engineTwenty);

			return engines;
		}

	}
}
