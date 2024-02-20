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


            Address secondAddress = new Address()
            {
                AddressId = 2,
                CountryName = "Italy",
                TownName = "Rome",
                StreetName = "Via del Corso",
            };

            Address thirdAddress = new Address()
            {
                AddressId = 3,
                CountryName = "France",
                TownName = "Paris",
                StreetName = "Champs-Élysées",
            };

            Address fourthAddress = new Address()
            {
                AddressId = 4,
                CountryName = "USA",
                TownName = "New York",
                StreetName = "Broadway",
            };

            Address fifthAddress = new Address()
            {
                AddressId = 5,
                CountryName = "Japan",
                TownName = "Tokyo",
                StreetName = "Shibuya Crossing",
            };

            Address sixthAddress = new Address()
            {
                AddressId = 6,
                CountryName = "Australia",
                TownName = "Sydney",
                StreetName = "George Street",
            };

            Address seventhAddress = new Address()
            {
                AddressId = 7,
                CountryName = "Canada",
                TownName = "Toronto",
                StreetName = "Yonge Street",
            };

            Address eighthAddress = new Address()
            {
                AddressId = 8,
                CountryName = "Germany",
                TownName = "Berlin",
                StreetName = "Unter den Linden",
            };

            Address ninthAddress = new Address()
            {
                AddressId = 9,
                CountryName = "Spain",
                TownName = "Barcelona",
                StreetName = "La Rambla",
            };

            Address tenthAddress = new Address()
            {
                AddressId = 10,
                CountryName = "United Kingdom",
                TownName = "London",
                StreetName = "Oxford Street",
            };

            addresses.Add(firstAddress);
            addresses.Add(secondAddress);
            addresses.Add(thirdAddress);
            addresses.Add(fourthAddress);
            addresses.Add(fifthAddress);
            addresses.Add(sixthAddress);
            addresses.Add(seventhAddress);
            addresses.Add(eighthAddress);
            addresses.Add(ninthAddress);
            addresses.Add(tenthAddress);

            return addresses;
        }
    }
}
