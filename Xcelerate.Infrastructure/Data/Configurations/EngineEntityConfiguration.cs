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
                ManufacturerId = 1 
            };

            Engine engineTwo = new Engine()
            {
                EngineId = 2,
                Model = "In-Line 4-Cylinder with Turbocharger",
                Horsepower = 306,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 2 
            };

            Engine engineThree = new Engine()
            {
                EngineId = 3,
                Model = "5.2-liter V-8 engine",
                Horsepower = 526,
                CylinderCount = 8,
                FuelType = FuelTypeEnum.Diesel,
                ManufacturerId = 3 
            };

            Engine engineFour = new Engine()
            {
                EngineId = 4,
                Model = "1.4L Turbo Inline-4",
                Horsepower = 147,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 4 
            };

            Engine engineFive = new Engine()
            {
                EngineId = 5,
                Model = "Turbocharged 2.0",
                Horsepower = 255,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 5 
            };

            Engine engineSix = new Engine()
            {
                EngineId = 6,
                Model = "2.0",
                Horsepower = 306,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 6 
            };

            Engine engineSeven = new Engine()
            {
                EngineId = 7,
                Model = "5.6-liter V-8 ",
                Horsepower = 400,
                CylinderCount = 8,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 7 // Assume ManufacturerId corresponds to Audi
            };

            Engine engineEight = new Engine()
            {
                EngineId = 8,
                Model = "Turbocharged N Line",
                Horsepower = 147,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 8 // Assume ManufacturerId corresponds to Nissan
            };

            Engine engineNine = new Engine()
            {
                EngineId = 9,
                Model = "Twin-turbo 3.0-liter inline-six",
                Horsepower = 473,
                CylinderCount = 6,
                FuelType = FuelTypeEnum.Diesel,
                ManufacturerId = 9 // Assume ManufacturerId corresponds to Volkswagen
            };

            Engine engineTen = new Engine()
            {
                EngineId = 10,
                Model = "2.5",
                Horsepower = 181,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Diesel,
                ManufacturerId = 10 // Assume ManufacturerId corresponds to Hyundai
            };

            engines.Add(engineOne);
            engines.Add(engineTwo);
            engines.Add(engineThree);
            engines.Add(engineFour);
            engines.Add(engineFive);
            engines.Add(engineSix);
            engines.Add(engineSeven);
            engines.Add(engineEight);
            engines.Add(engineNine);
            engines.Add(engineTen);

            return engines;
        }

    }
}
