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
			manufacturers.Add(manufacturerOne);

			Manufacturer manufacturerTwo = new Manufacturer()
			{
				ManufacturerId = 2,
				Name = "Honda"
			};
			manufacturers.Add(manufacturerTwo);

			Manufacturer manufacturerThree = new Manufacturer()
			{
				ManufacturerId = 3,
				Name = "Ford"
			};
			manufacturers.Add(manufacturerThree);

			Manufacturer manufacturerFour = new Manufacturer()
			{
				ManufacturerId = 4,
				Name = "Volkswagen"
			};
			manufacturers.Add(manufacturerFour);

			Manufacturer manufacturerFive = new Manufacturer()
			{
				ManufacturerId = 5,
				Name = "Mercedes-Benz"
			};
			manufacturers.Add(manufacturerFive);

			Manufacturer manufacturerSix = new Manufacturer()
			{
				ManufacturerId = 6,
				Name = "Audi"
			};
			manufacturers.Add(manufacturerSix);

			Manufacturer manufacturerSeven = new Manufacturer()
			{
				ManufacturerId = 7,
				Name = "Infiniti"
			};
			manufacturers.Add(manufacturerSeven);

			Manufacturer manufacturerEight = new Manufacturer()
			{
				ManufacturerId = 8,
				Name = "Hyundai"
			};
			manufacturers.Add(manufacturerEight);

			Manufacturer manufacturerNine = new Manufacturer()
			{
				ManufacturerId = 9,
				Name = "BMW"
			};
			manufacturers.Add(manufacturerNine);

			Manufacturer manufacturerTen = new Manufacturer()
			{
				ManufacturerId = 10,
				Name = "Nissan"
			};
			manufacturers.Add(manufacturerTen);

			Manufacturer manufacturerEleven = new Manufacturer()
			{
				ManufacturerId = 11,
				Name = "Chevrolet"
			};
			manufacturers.Add(manufacturerEleven);

			Manufacturer manufacturerTwelve = new Manufacturer()
			{
				ManufacturerId = 12,
				Name = "Chevrolet"
			};
			manufacturers.Add(manufacturerTwelve);

			Manufacturer manufacturerThirteen = new Manufacturer()
			{
				ManufacturerId = 13,
				Name = "Ford"
			};
			manufacturers.Add(manufacturerThirteen);

			Manufacturer manufacturerFourteen = new Manufacturer()
			{
				ManufacturerId = 14,
				Name = "Renault"
			};
			manufacturers.Add(manufacturerFourteen);

			Manufacturer manufacturerFifteen = new Manufacturer()
			{
				ManufacturerId = 15,
				Name = "Mercedes-Benz"
			};
			manufacturers.Add(manufacturerFifteen);

			Manufacturer manufacturerSixteen = new Manufacturer()
			{
				ManufacturerId = 16,
				Name = "Acura"
			};
			manufacturers.Add(manufacturerSixteen);

			Manufacturer manufacturerSeventeen = new Manufacturer()
			{
				ManufacturerId = 17,
				Name = "Acura"
			};
			manufacturers.Add(manufacturerSeventeen);

			Manufacturer manufacturerEighteen = new Manufacturer()
			{
				ManufacturerId = 18,
				Name = "Saab"
			};
			manufacturers.Add(manufacturerEighteen);

			Manufacturer manufacturerNineteen = new Manufacturer()
			{
				ManufacturerId = 19,
				Name = "Saab"
			};
			manufacturers.Add(manufacturerNineteen);

			Manufacturer manufacturerTwenty = new Manufacturer()
			{
				ManufacturerId = 20,
				Name = "Renault"
			};
			manufacturers.Add(manufacturerTwenty);

			return manufacturers;
		}
	}
}
