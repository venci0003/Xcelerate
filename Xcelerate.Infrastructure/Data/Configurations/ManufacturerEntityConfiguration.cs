using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasMany(m => m.Cars)
                .WithOne(c => c.Manufacturer)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Engines)
                .WithOne(c => c.Manufacturer)
                .OnDelete(DeleteBehavior.NoAction);

            ICollection<Manufacturer> manufacturersCollection = CreateManufacturers();
            builder.HasData(CreateManufacturers());
        }

        private ICollection<Manufacturer> CreateManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            Manufacturer manufacturerOne = new Manufacturer()
            {
                ManufacturerId = 1,
                Name = "Toyota"
            };

            Manufacturer manufacturerTwo = new Manufacturer()
            {
                ManufacturerId = 2,
                Name = "Ford"
            };

            Manufacturer manufacturerThree = new Manufacturer()
            {
                ManufacturerId = 3,
                Name = "Honda"
            };

            Manufacturer manufacturerFour = new Manufacturer()
            {
                ManufacturerId = 4,
                Name = "BMW"
            };

            Manufacturer manufacturerFive = new Manufacturer()
            {
                ManufacturerId = 5,
                Name = "Mercedes-Benz"
            };

            Manufacturer manufacturerSix = new Manufacturer()
            {
                ManufacturerId = 6,
                Name = "Chevrolet"
            };

            Manufacturer manufacturerSeven = new Manufacturer()
            {
                ManufacturerId = 7,
                Name = "Audi"
            };

            Manufacturer manufacturerEight = new Manufacturer()
            {
                ManufacturerId = 8,
                Name = "Nissan"
            };

            Manufacturer manufacturerNine = new Manufacturer()
            {
                ManufacturerId = 9,
                Name = "Volkswagen"
            };

            Manufacturer manufacturerTen = new Manufacturer()
            {
                ManufacturerId = 10,
                Name = "Hyundai"
            };

            manufacturers.Add(manufacturerOne);
            manufacturers.Add(manufacturerTwo);
            manufacturers.Add(manufacturerThree);
            manufacturers.Add(manufacturerFour);
            manufacturers.Add(manufacturerFive);
            manufacturers.Add(manufacturerSix);
            manufacturers.Add(manufacturerSeven);
            manufacturers.Add(manufacturerEight);
            manufacturers.Add(manufacturerNine);
            manufacturers.Add(manufacturerTen);

            return manufacturers;
        }
    }
}
