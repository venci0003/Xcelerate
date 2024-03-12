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
                AdId = 1,
                CarId = 1, // Assuming CarId corresponds to the first car in your collection
                UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"), // Assuming UserId corresponds to the first user in your collection
                CarDescription = "The 2020 Toyota Camry TRD is a sporty, performance-oriented version of the long-standing mid-size sedan1." +
                " It’s the first Camry that could be construed as \"sporty\".\nPerformance The TRD’s front brake rotors are larger than those on the next-sportiest Camry, the XSE V-6 model, and are squeezed by two-piston calipers instead of single-piston units." +
                " It’s equipped with stiffer springs and larger-diameter anti-roll bars, stiffer underbody braces, and a V-brace behind the rear seats.",
                CreatedOn = "2024-10-02"
            };

            Ad adTwo = new Ad()
            {
				AdId = 2,
                CarId = 2, // Assuming CarId corresponds to the second car in your collection
                UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"), // Assuming UserId corresponds to the second user in your collection
                CarDescription = "The 2021 Honda Civic Type R Limited Edition is a high-performance, four-door hatchback that stands out in its class." +
                " Despite its bold and somewhat juvenile bodywork, it offers a transformative driving experience, volcanic acceleration, and is entirely practical for daily use.\r\n\r\nThe car is powered by a 306-hp turbocharged four-cylinder engine and a six-speed manual transmission, making it one of the quickest sport compacts. Honda has managed to virtually eliminate the dreaded torque steer that plagues powerful front-drive cars, providing talkative steering, tremendous cornering grip, and a ride that’s surprisingly smooth",
                CreatedOn = "2018-10-02"
            };

            Ad adThree = new Ad()
            {
				AdId = 3,
                CarId = 3, // Assuming CarId corresponds to the third car in your collection
                UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"), // Assuming UserId corresponds to the third user in your collection
                CarDescription = "The 2020 Ford Mustang Shelby GT350R is a powerful, high-strung muscle car designed to rock race tracks while still being at home on the street." +
                " Its special 5.2-liter V-8 engine, code-named Voodoo, makes 526 horsepower and revs to a dizzying 8250 rpm." +
                " The GT350R has been designed to handle cornering at race-track speeds without being too harsh on the street. It’s equipped with a tautly tuned suspension and robust brakes.",
                CreatedOn = "2024-15-07"
            };

            Ad adFour = new Ad()
            {
				AdId = 4,
                CarId = 4, // Assuming CarId corresponds to the fourth car in your collection
                UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"), // Assuming UserId corresponds to the fourth user in your collection
                CarDescription = "The 2020 Volkswagen Golf TSI is a compact hatchback that offers a blend of performance, comfort, and practicality. It’s powered by a 1.4L Turbo Inline-4 Gas engine that produces 147 horsepower at 5000 rpm and 184 lb-ft of torque at 1400 rpm" +
                ". The Golf is fun to drive with well-calibrated transmissions and confident in corners." +
                " It’s not as fast as its sportier GTI counterpart, but it’s still enjoyable to drive.",
                CreatedOn = "2024-22-04"
            };

            Ad adFive = new Ad()
            {
				AdId = 5,
                CarId = 5, // Assuming CarId corresponds to the fifth car in your collection
                UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"), // Assuming UserId corresponds to the fifth user in your collection
                CarDescription = "The 2022 Mercedes-Benz C-Class is a luxury sedan that has been fully redesigned for the year." +
                " It’s a far cry from where the model started out almost 30 years ago. With smaller and more affordable vehicles supporting it, the C-Class is more of a middleweight luxury sedan than an entry-level taste of the brand.",
                CreatedOn = "2024-08-09"
            };

            Ad adSix = new Ad()
            {
				AdId = 6,
                CarId = 6, // Assuming CarId corresponds to the sixth car in your collection
                UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"), // Assuming UserId corresponds to the sixth user in your collection
                CarDescription = "The 2022 Audi S3 is a compact luxury sedan that has been fully redesigned for the year." +
                " It finds an admirable middle ground between the more conventional A3 and higher-performing RS 3, both in terms of price and personality." +
                "\r\n\r\nWith 306 horsepower and all-wheel drive as standard, the S3 is a big step up from the 201-hp A3 and a sensible alternative to the RS 3’s monster 401 hp." +
                " Despite being Audi’s entry-level vehicles, the A3 and S3 deliver a healthy dose of modern luxury and tech features.",
                CreatedOn = "2024-27-06"
            };

            Ad adSeven = new Ad()
            {
				AdId = 7,
                CarId = 7, // Assuming CarId corresponds to the seventh car in your collection
                UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"), // Assuming UserId corresponds to the seventh user in your collection
                CarDescription = "The 2022 Infiniti QX80 is a large, three-row, luxury SUV." +
                " It has an attractive and upscale look, a sturdily built interior, and a smooth ride." +
                " Here are some key features and specifications:\r\n\r\nEngine: It is powered by a 400-hp 5.6-liter V-8 engine, paired with a seven-speed automatic transmission" +
                ".\r\nPerformance: The QX80’s engine provides smooth power delivery and snappy throttle response." +
                " It can go from zero to 60 mph in 5.9 seconds.\r\nFuel Efficiency: It has a fuel efficiency of 14/20 MPG city/highway.",
                CreatedOn = "2024-14-12"
            };

            Ad adEight = new Ad()
            {
				AdId = 8,
                CarId = 8, // Assuming CarId corresponds to the eighth car in your collection
                UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"), // Assuming UserId corresponds to the eighth user in your collection
                CarDescription = "The 2021 Hyundai Elantra is a compact sedan that has been redesigned with modern exterior and interior styling, and more advanced technology features" +
                ". Here are some key features and specifications:\r\n\r\nEngine: The standard non-hybrid powertrain is a 147-hp four-cylinder engine" +
                ". There’s also a 201-hp turbocharged N Line model and an available hybrid powertrain." +
                "\r\nPerformance: The Elantra offers good ride quality and enough pep for normal city and highway driving." +
                " The performance-oriented N Line model provides perkier acceleration and adept handling." +
                "\r\nFuel Efficiency: The Elantra Hybrid earned an EPA rating as high as 56 mpg highway.",
                CreatedOn = "2024-18-05"
            };

            Ad adNine = new Ad()
            {
				AdId = 9,
                CarId = 9, // Assuming CarId corresponds to the ninth car in your collection
                UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"), // Assuming UserId corresponds to the ninth user in your collection
                CarDescription = "The 2022 BMW M3 is a high-performance sedan that offers thrilling powertrains and a satisfying manual gearbox" +
                ". Here are some key features and specifications:\r\n\r\nEngine: The M3 features a twin-turbo 3.0-liter inline-six engine" +
                ". The standard version delivers 473 horsepower and 406 pound-feet of torque." +
                "\r\nPerformance: The M3 is known for its thrilling powertrains and drivability." +
                " The standard M3 is rear-wheel drive and comes with a manual gearbox." +
                " The Competition model has an enhanced engine with 503 horsepower and a track-tuned chassis.",
                CreatedOn = "2024-09-01"
            };

            Ad adTen = new Ad()
            {
				AdId = 10,
                CarId = 10, // Assuming CarId corresponds to the tenth car in your collection
                UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"), // Assuming UserId corresponds to the tenth user in your collection
                CarDescription = "The 2021 Nissan Rogue is a compact SUV that has been redesigned with modern exterior and interior styling, and more advanced technology features." +
                " Here are some key features and specifications:\r\n\r\nEngine: The 2021 model is powered by a 2.5-liter four-cylinder engine." +
                " It has received a slight power bump to 181 horsepower.\r\nPerformance: The Rogue offers good ride quality and enough pep for normal city and highway driving." +
                " It has improved in both acceleration and handling." +
                "\r\nFuel Efficiency: The EPA estimates that front-wheel drive Rogues should deliver up to 27 mpg city and 35 mpg highway.",
                CreatedOn = "2024-25-02"
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
