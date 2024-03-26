using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.HasMany(c => c.Cars)
				.WithOne(a => a.Address)
				.OnDelete(DeleteBehavior.Cascade);

			ICollection<Address> addressCollection = CreateAddress();
			builder.HasData(addressCollection);
		}

		private ICollection<Address> CreateAddress()
		{
			List<Address> addresses = new List<Address>();

			Address firstAddress = new Address()
			{
				AddressId = 1,
				CountryName = "Bulgaria",
				TownName = "Pernik",
				StreetName = "Ivan Vazov",
			};
			addresses.Add(firstAddress);


			Address secondAddress = new Address()
			{
				AddressId = 2,
				CountryName = "Italy",
				TownName = "Rome",
				StreetName = "Via del Corso",
			};
			addresses.Add(secondAddress);

			Address thirdAddress = new Address()
			{
				AddressId = 3,
				CountryName = "France",
				TownName = "Paris",
				StreetName = "Champs-Élysées",
			};
			addresses.Add(thirdAddress);

			Address fourthAddress = new Address()
			{
				AddressId = 4,
				CountryName = "USA",
				TownName = "New York",
				StreetName = "Broadway",
			};
			addresses.Add(fourthAddress);

			Address fifthAddress = new Address()
			{
				AddressId = 5,
				CountryName = "Japan",
				TownName = "Tokyo",
				StreetName = "Shibuya Crossing",
			};
			addresses.Add(fifthAddress);

			Address sixthAddress = new Address()
			{
				AddressId = 6,
				CountryName = "Australia",
				TownName = "Sydney",
				StreetName = "George Street",
			};
			addresses.Add(sixthAddress);

			Address seventhAddress = new Address()
			{
				AddressId = 7,
				CountryName = "Canada",
				TownName = "Toronto",
				StreetName = "Yonge Street",
			};
			addresses.Add(seventhAddress);

			Address eighthAddress = new Address()
			{
				AddressId = 8,
				CountryName = "Germany",
				TownName = "Berlin",
				StreetName = "Unter den Linden",
			};
			addresses.Add(eighthAddress);

			Address ninthAddress = new Address()
			{
				AddressId = 9,
				CountryName = "Spain",
				TownName = "Barcelona",
				StreetName = "La Rambla",
			};
			addresses.Add(ninthAddress);

			Address tenthAddress = new Address()
			{
				AddressId = 10,
				CountryName = "United Kingdom",
				TownName = "London",
				StreetName = "Oxford Street",
			};
			addresses.Add(tenthAddress);

			Address eleventhAddress = new Address()
			{
				AddressId = 11,
				CountryName = "United States",
				TownName = "New York City",
				StreetName = "Broadway",
			};
			addresses.Add(eleventhAddress);

			Address twelfthAddress = new Address()
			{
				AddressId = 12,
				CountryName = "Canada",
				TownName = "Toronto",
				StreetName = "Yonge Street",
			};
			addresses.Add(twelfthAddress);

			Address thirteenthAddress = new Address()
			{
				AddressId = 13,
				CountryName = "Australia",
				TownName = "Sydney",
				StreetName = "George Street",
			};
			addresses.Add(thirteenthAddress);

			Address fourteenthAddress = new Address()
			{
				AddressId = 14,
				CountryName = "Germany",
				TownName = "Berlin",
				StreetName = "Kurfürstendamm",
			};
			addresses.Add(fourteenthAddress);

			Address fifteenthAddress = new Address()
			{
				AddressId = 15,
				CountryName = "Italy",
				TownName = "Rome",
				StreetName = "Via del Corso",
			};
			addresses.Add(fifteenthAddress);

			Address sixteenthAddress = new Address()
			{
				AddressId = 16,
				CountryName = "Spain",
				TownName = "Barcelona",
				StreetName = "Passeig de Gràcia",
			};
			addresses.Add(sixteenthAddress);

			Address seventeenthAddress = new Address()
			{
				AddressId = 17,
				CountryName = "France",
				TownName = "Paris",
				StreetName = "Champs-Élysées",
			};
			addresses.Add(seventeenthAddress);

			Address eighteenthAddress = new Address()
			{
				AddressId = 18,
				CountryName = "Australia",
				TownName = "Sydney",
				StreetName = "George Street",
			};
			addresses.Add(eighteenthAddress);

			Address nineteenthAddress = new Address()
			{
				AddressId = 19,
				CountryName = "Canada",
				TownName = "Toronto",
				StreetName = "Yonge Street",
			};
			addresses.Add(nineteenthAddress);

			Address twentiethAddress = new Address()
			{
				AddressId = 20,
				CountryName = "Italy",
				TownName = "Rome",
				StreetName = "Via Veneto",
			};
			addresses.Add(twentiethAddress);

			Address twentyFirstAddress = new Address()
			{
				AddressId = 21,
				CountryName = "United States",
				TownName = "New York City",
				StreetName = "Broadway",
			};
			addresses.Add(twentyFirstAddress);

			Address twentySecondAddress = new Address()
			{
				AddressId = 22,
				CountryName = "Germany",
				TownName = "Berlin",
				StreetName = "Kurfürstendamm",
			};
			addresses.Add(twentySecondAddress);

			Address twentyThirdAddress = new Address()
			{
				AddressId = 23,
				CountryName = "Japan",
				TownName = "Tokyo",
				StreetName = "Shibuya Crossing",
			};
			addresses.Add(twentyThirdAddress);

			Address twentyFourthAddress = new Address()
			{
				AddressId = 24,
				CountryName = "Brazil",
				TownName = "Rio de Janeiro",
				StreetName = "Avenida Atlântica",
			};
			addresses.Add(twentyFourthAddress);

			Address twentyFifthAddress = new Address()
			{
				AddressId = 25,
				CountryName = "South Africa",
				TownName = "Cape Town",
				StreetName = "Long Street",
			};
			addresses.Add(twentyFifthAddress);

			Address twentySixthAddress = new Address()
			{
				AddressId = 26,
				CountryName = "Canada",
				TownName = "Vancouver",
				StreetName = "Granville Street",
			};
			addresses.Add(twentySixthAddress);

			Address twentySeventhAddress = new Address()
			{
				AddressId = 27,
				CountryName = "Spain",
				TownName = "Madrid",
				StreetName = "Gran Vía",
			};
			addresses.Add(twentySeventhAddress);

			Address twentyEighthAddress = new Address()
			{
				AddressId = 28,
				CountryName = "United Kingdom",
				TownName = "London",
				StreetName = "Oxford Street",
			};
			addresses.Add(twentyEighthAddress);

			Address twentyNinthAddress = new Address()
			{
				AddressId = 29,
				CountryName = "Italy",
				TownName = "Venice",
				StreetName = "Grand Canal",
			};
			addresses.Add(twentyNinthAddress);

			Address thirtiethAddress = new Address()
			{
				AddressId = 30,
				CountryName = "Australia",
				TownName = "Melbourne",
				StreetName = "Collins Street",
			};
			addresses.Add(thirtiethAddress);
			return addresses;
		}
	}
}
