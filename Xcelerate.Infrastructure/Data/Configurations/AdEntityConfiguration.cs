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
    public class AdEntityConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasMany(r => r.Reviews)
                 .WithOne(a => a.Ad)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.User)
                 .WithMany(a => a.Ads)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Car)
                .WithOne(a => a.Ad)
                .OnDelete(DeleteBehavior.NoAction);

            ICollection<Ad> adsCollection = CreateAds();
            builder.HasData(CreateAds());
        }

        private ICollection<Ad> CreateAds()
        {
            List<Ad> ads = new List<Ad>();

            Ad adOne = new Ad()
            {
                Id = 1,
                CarId = 1, // Assuming CarId corresponds to the first car in your collection
                UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"), // Assuming UserId corresponds to the first user in your collection
                CarDescription = "The 2020 Toyota Camry TRD is a sporty, performance-oriented version of the long-standing mid-size sedan1." +
                " It’s the first Camry that could be construed as \"sporty\"1.\nPerformance The TRD’s front brake rotors are larger than those on the next-sportiest Camry, the XSE V-6 model, and are squeezed by two-piston calipers instead of single-piston units." +
                " It’s equipped with stiffer springs and larger-diameter anti-roll bars, stiffer underbody braces, and a V-brace behind the rear seats."
            };

            Ad adTwo = new Ad()
            {
                Id = 2,
                CarId = 2, // Assuming CarId corresponds to the second car in your collection
                UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"), // Assuming UserId corresponds to the second user in your collection
                CarDescription = "The 2021 Honda Civic Type R Limited Edition is a high-performance, four-door hatchback that stands out in its class1. Despite its bold and somewhat juvenile bodywork, it offers a transformative driving experience, volcanic acceleration, and is entirely practical for daily use1.\r\n\r\nThe car is powered by a 306-hp turbocharged four-cylinder engine and a six-speed manual transmission, making it one of the quickest sport compacts1. Honda has managed to virtually eliminate the dreaded torque steer that plagues powerful front-drive cars, providing talkative steering, tremendous cornering grip, and a ride that’s surprisingly smooth"
            };

            Ad adThree = new Ad()
            {
                Id = 3,
                CarId = 3, // Assuming CarId corresponds to the third car in your collection
                UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"), // Assuming UserId corresponds to the third user in your collection
                CarDescription = "The 2020 Ford Mustang Shelby GT350R is a powerful, high-strung muscle car designed to rock race tracks while still being at home on the street." +
                " Its special 5.2-liter V-8 engine, code-named Voodoo, makes 526 horsepower and revs to a dizzying 8250 rpm1." +
                " The GT350R has been designed to handle cornering at race-track speeds without being too harsh on the street. It’s equipped with a tautly tuned suspension and robust brakes."
            };

            Ad adFour = new Ad()
            {
                Id = 4,
                CarId = 4, // Assuming CarId corresponds to the fourth car in your collection
                UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"), // Assuming UserId corresponds to the fourth user in your collection
                CarDescription = "Luxurious BMW 5 Series with advanced features. Well-maintained."
            };

            Ad adFive = new Ad()
            {
                Id = 5,
                CarId = 5, // Assuming CarId corresponds to the fifth car in your collection
                UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"), // Assuming UserId corresponds to the fifth user in your collection
                CarDescription = "Mercedes-Benz C-Class with AMG package. Stunning design and performance."
            };

            Ad adSix = new Ad()
            {
                Id = 6,
                CarId = 6, // Assuming CarId corresponds to the sixth car in your collection
                UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"), // Assuming UserId corresponds to the sixth user in your collection
                CarDescription = "Chevrolet Camaro with V8 engine. Impressive power and handling."
            };

            Ad adSeven = new Ad()
            {
                Id = 7,
                CarId = 7, // Assuming CarId corresponds to the seventh car in your collection
                UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"), // Assuming UserId corresponds to the seventh user in your collection
                CarDescription = "Audi A4 with advanced technology. Smooth and comfortable driving experience."
            };

            Ad adEight = new Ad()
            {
                Id = 8,
                CarId = 8, // Assuming CarId corresponds to the eighth car in your collection
                UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"), // Assuming UserId corresponds to the eighth user in your collection
                CarDescription = "Nissan GT-R with impressive acceleration. Well-maintained and garage-kept."
            };

            Ad adNine = new Ad()
            {
                Id = 9,
                CarId = 9, // Assuming CarId corresponds to the ninth car in your collection
                UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"), // Assuming UserId corresponds to the ninth user in your collection
                CarDescription = "Volkswagen Golf TDI. Fuel-efficient diesel engine, great for long drives."
            };

            Ad adTen = new Ad()
            {
                Id = 10,
                CarId = 10, // Assuming CarId corresponds to the tenth car in your collection
                UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"), // Assuming UserId corresponds to the tenth user in your collection
                CarDescription = "Hyundai Sonata with modern features. Comfortable and reliable sedan."
            };

            ads.Add(adOne);
            ads.Add(adTwo);
            ads.Add(adThree);
            ads.Add(adFour);
            ads.Add(adFive);
            ads.Add(adSix);
            ads.Add(adSeven);
            ads.Add(adEight);
            ads.Add(adNine);
            ads.Add(adTen);

            return ads;
        }
    }
}
