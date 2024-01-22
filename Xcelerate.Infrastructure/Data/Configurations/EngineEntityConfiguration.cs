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
                Model = "V6 Turbo",
                Horsepower = 300,
                CylinderCount = 6,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 1 // Assume ManufacturerId corresponds to Toyota
            };

            Engine engineTwo = new Engine()
            {
                EngineId = 2,
                Model = "V8 EcoBoost",
                Horsepower = 400,
                CylinderCount = 8,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 2 // Assume ManufacturerId corresponds to Ford
            };

            Engine engineThree = new Engine()
            {
                EngineId = 3,
                Model = "K20C1",
                Horsepower = 320,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 3 // Assume ManufacturerId corresponds to Honda
            };

            Engine engineFour = new Engine()
            {
                EngineId = 4,
                Model = "TwinPower Turbo",
                Horsepower = 350,
                CylinderCount = 6,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 4 // Assume ManufacturerId corresponds to BMW
            };

            Engine engineFive = new Engine()
            {
                EngineId = 5,
                Model = "AMG V8 Biturbo",
                Horsepower = 500,
                CylinderCount = 8,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 5 // Assume ManufacturerId corresponds to Mercedes-Benz
            };

            Engine engineSix = new Engine()
            {
                EngineId = 6,
                Model = "V8 LS3",
                Horsepower = 450,
                CylinderCount = 8,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 6 // Assume ManufacturerId corresponds to Chevrolet
            };

            Engine engineSeven = new Engine()
            {
                EngineId = 7,
                Model = "2.0 TFSI",
                Horsepower = 250,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 7 // Assume ManufacturerId corresponds to Audi
            };

            Engine engineEight = new Engine()
            {
                EngineId = 8,
                Model = "VR38DETT",
                Horsepower = 600,
                CylinderCount = 6,
                FuelType = FuelTypeEnum.Petrol,
                ManufacturerId = 8 // Assume ManufacturerId corresponds to Nissan
            };

            Engine engineNine = new Engine()
            {
                EngineId = 9,
                Model = "2.0 TDI",
                Horsepower = 190,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Diesel,
                ManufacturerId = 9 // Assume ManufacturerId corresponds to Volkswagen
            };

            Engine engineTen = new Engine()
            {
                EngineId = 10,
                Model = "Gamma 1.6L",
                Horsepower = 130,
                CylinderCount = 4,
                FuelType = FuelTypeEnum.Petrol,
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
