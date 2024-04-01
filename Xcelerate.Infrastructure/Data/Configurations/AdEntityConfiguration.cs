using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
				CarId = 1, 
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				CarDescription = "The 2020 Toyota Camry TRD is a sporty, performance-oriented version of the long-standing mid-size sedan1." +
				" It’s the first Camry that could be construed as \"sporty\".\nPerformance The TRD’s front brake rotors are larger than those on the next-sportiest Camry, the XSE V-6 model, and are squeezed by two-piston calipers instead of single-piston units." +
				" It’s equipped with stiffer springs and larger-diameter anti-roll bars, stiffer underbody braces, and a V-brace behind the rear seats.",
				CreatedOn = "2024-10-02"
			};
			ads.Add(adOne);

			Ad adTwo = new Ad()
			{
				AdId = 2,
				CarId = 2,  
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				CarDescription = "The 2021 Honda Civic Type R Limited Edition is a high-performance, four-door hatchback that stands out in its class." +
				" Despite its bold and somewhat juvenile bodywork, it offers a transformative driving experience, volcanic acceleration, and is entirely practical for daily use.\r\n\r\nThe car is powered by a 306-hp turbocharged four-cylinder engine and a six-speed manual transmission, making it one of the quickest sport compacts. Honda has managed to virtually eliminate the dreaded torque steer that plagues powerful front-drive cars, providing talkative steering, tremendous cornering grip, and a ride that’s surprisingly smooth",
				CreatedOn = "2018-10-02"
			};
			ads.Add(adTwo);

			Ad adThree = new Ad()
			{
				AdId = 3,
				CarId = 3,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				CarDescription = "The 2020 Ford Mustang Shelby GT350R is a powerful, high-strung muscle car designed to rock race tracks while still being at home on the street." +
				" Its special 5.2-liter V-8 engine, code-named Voodoo, makes 526 horsepower and revs to a dizzying 8250 rpm." +
				" The GT350R has been designed to handle cornering at race-track speeds without being too harsh on the street. It’s equipped with a tautly tuned suspension and robust brakes.",
				CreatedOn = "2024-15-07"
			};
			ads.Add(adThree);

			Ad adFour = new Ad()
			{
				AdId = 4,
				CarId = 4,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				CarDescription = "The 2020 Volkswagen Golf TSI is a compact hatchback that offers a blend of performance, comfort, and practicality. It’s powered by a 1.4L Turbo Inline-4 Gas engine that produces 147 horsepower at 5000 rpm and 184 lb-ft of torque at 1400 rpm" +
				". The Golf is fun to drive with well-calibrated transmissions and confident in corners." +
				" It’s not as fast as its sportier GTI counterpart, but it’s still enjoyable to drive.",
				CreatedOn = "2024-22-04"
			};
			ads.Add(adFour);

			Ad adFive = new Ad()
			{
				AdId = 5,
				CarId = 5,
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),
				CarDescription = "The 2022 Mercedes-Benz C-Class is a luxury sedan that has been fully redesigned for the year." +
				" It’s a far cry from where the model started out almost 30 years ago. With smaller and more affordable vehicles supporting it, the C-Class is more of a middleweight luxury sedan than an entry-level taste of the brand.",
				CreatedOn = "2024-08-09"
			};
			ads.Add(adFive);


			Ad adSix = new Ad()
			{
				AdId = 6,
				CarId = 6,
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				CarDescription = "The 2022 Audi S3 is a compact luxury sedan that has been fully redesigned for the year." +
				" It finds an admirable middle ground between the more conventional A3 and higher-performing RS 3, both in terms of price and personality." +
				"\r\n\r\nWith 306 horsepower and all-wheel drive as standard, the S3 is a big step up from the 201-hp A3 and a sensible alternative to the RS 3’s monster 401 hp." +
				" Despite being Audi’s entry-level vehicles, the A3 and S3 deliver a healthy dose of modern luxury and tech features.",
				CreatedOn = "2024-27-06"
			};
			ads.Add(adSix);

			Ad adSeven = new Ad()
			{
				AdId = 7,
				CarId = 7,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				CarDescription = "The 2022 Infiniti QX80 is a large, three-row, luxury SUV." +
				" It has an attractive and upscale look, a sturdily built interior, and a smooth ride." +
				" Here are some key features and specifications:\r\n\r\nEngine: It is powered by a 400-hp 5.6-liter V-8 engine, paired with a seven-speed automatic transmission" +
				".\r\nPerformance: The QX80’s engine provides smooth power delivery and snappy throttle response." +
				" It can go from zero to 60 mph in 5.9 seconds.\r\nFuel Efficiency: It has a fuel efficiency of 14/20 MPG city/highway.",
				CreatedOn = "2024-14-12"
			};
			ads.Add(adSeven);

			Ad adEight = new Ad()
			{
				AdId = 8,
				CarId = 8,
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"),
				CarDescription = "The 2021 Hyundai Elantra is a compact sedan that has been redesigned with modern exterior and interior styling, and more advanced technology features" +
				". Here are some key features and specifications:\r\n\r\nEngine: The standard non-hybrid powertrain is a 147-hp four-cylinder engine" +
				". There’s also a 201-hp turbocharged N Line model and an available hybrid powertrain." +
				"\r\nPerformance: The Elantra offers good ride quality and enough pep for normal city and highway driving." +
				" The performance-oriented N Line model provides perkier acceleration and adept handling." +
				"\r\nFuel Efficiency: The Elantra Hybrid earned an EPA rating as high as 56 mpg highway.",
				CreatedOn = "2024-18-05"
			};
			ads.Add(adEight);

			Ad adNine = new Ad()
			{
				AdId = 9,
				CarId = 9,
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),
				CarDescription = "The 2022 BMW M3 is a high-performance sedan that offers thrilling powertrains and a satisfying manual gearbox" +
				". Here are some key features and specifications:\r\n\r\nEngine: The M3 features a twin-turbo 3.0-liter inline-six engine" +
				". The standard version delivers 473 horsepower and 406 pound-feet of torque." +
				"\r\nPerformance: The M3 is known for its thrilling powertrains and drivability." +
				" The standard M3 is rear-wheel drive and comes with a manual gearbox." +
				" The Competition model has an enhanced engine with 503 horsepower and a track-tuned chassis.",
				CreatedOn = "2024-09-01"
			};
			ads.Add(adNine);

			Ad adTen = new Ad()
			{
				AdId = 10,
				CarId = 10,  
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),  
				CarDescription = "The 2021 Nissan Rogue is a compact SUV that has been redesigned with modern exterior and interior styling, and more advanced technology features." +
				" Here are some key features and specifications:\r\n\r\nEngine: The 2021 model is powered by a 2.5-liter four-cylinder engine." +
				" It has received a slight power bump to 181 horsepower.\r\nPerformance: The Rogue offers good ride quality and enough pep for normal city and highway driving." +
				" It has improved in both acceleration and handling." +
				"\r\nFuel Efficiency: The EPA estimates that front-wheel drive Rogues should deliver up to 27 mpg city and 35 mpg highway.",
				CreatedOn = "2024-25-02"
			};
			ads.Add(adTen);

			Ad adEleven = new Ad()
			{
				AdId = 11,
				CarId = 11,  
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),  
				CarDescription = "\r\nThe 1969 El Camino SS stands as a pinnacle of American muscle car heritage. With its commanding V8 engine, striking design, and dual-purpose utility, it embodies the essence of power and versatility." +
				" A timeless icon revered by enthusiasts, it continues to captivate with its enduring charisma and formidable performance.",
				CreatedOn = "2023-15-03"
			};
			ads.Add(adEleven);

			Ad adTwelve = new Ad()
			{
				AdId = 12,
				CarId = 12,  
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"),  
				CarDescription = "The 2013 Chevrolet Tahoe is a formidable full-size SUV, boasting a robust 5.3-liter V8 engine that delivers ample power and towing capability." +
				" With spacious seating for up to nine passengers, versatile cargo space, and advanced safety features, it combines comfort, utility, and performance for an exhilarating driving experience on and off the road.",
				CreatedOn = "2022-13-09"
			};
			ads.Add(adTwelve);

			Ad adThirteen = new Ad()
			{
				AdId = 13,
				CarId = 13,  
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),  
				CarDescription = "The 2000 Ford F-350 Super Duty epitomizes rugged reliability and unmatched towing prowess." +
				" With a range of potent engine options, robust construction, and expansive payload capacity, it's a workhorse designed to tackle the toughest jobs." +
				" Its durable build and versatile design make it a cornerstone of Ford's truck lineup.",
				CreatedOn = "2020-03-10"
			};
			ads.Add(adThirteen);

			Ad adFourteen = new Ad()
			{
				AdId = 14,
				CarId = 14,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),  
				CarDescription = "The 2013 Renault Clio embodies sleek style and urban practicality." +
				" Renowned for its fuel efficiency and nimble handling, it's perfect for city driving." +
				" With a modern interior, advanced features, and a range of efficient engines, the Clio offers a comfortable and enjoyable ride for drivers seeking both style and substance.",
				CreatedOn = "2019-07-12"
			};
			ads.Add(adFourteen);

			Ad adFifteen = new Ad()
			{
				AdId = 15,
				CarId = 15,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),  
				CarDescription = "\r\nThe model series 140 S-Class, introduced in 1991, achieved remarkable success on various fronts. Initial critiques in Germany regarding its external dimensions have since faded, especially as modern vehicles have grown in size and weight." +
				" Interestingly, Mercedes-Benz customers in the USA and Asia embraced the S-Class enthusiastically." +
				" This model captivated with its innovative design, advanced features, and unmatched spaciousness and comfort, demonstrating the evolving preferences and global acceptance of luxury vehicles over the past three decades.",
				CreatedOn = "2019-03-02"
			};
			ads.Add(adFifteen);

			Ad adSixteen = new Ad()
			{
				AdId = 16,
				CarId = 16,  
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),  
				CarDescription = "The 2005 Acura Type-S saw modifications to its 2.0-liter i-VTEC engine, boosting power to 210 hp at 7800 rpm and torque to 143 lb-ft at 7000 rpm." +
				" It exclusively features a close-ratio 6-speed manual transmission, with lowered final gear ratio for quicker acceleration and improved shift feel.",
				CreatedOn = "2013-04-10"
			};
			ads.Add(adSixteen);

			Ad adSeventeen = new Ad()
			{
				AdId = 17,
				CarId = 17,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),  
				CarDescription = "\r\nThe Acura NSX epitomizes precision-crafted performance, combining world-class styling with exceptional drivability and refinement." +
				" Offering two distinct powertrains, including a lightweight, all-aluminum V6 engine coupled with a 6-speed manual transmission, it delivers exhilarating performance." +
				" With advanced features like Variable Valve Timing and Lift Electronic Control (VTEC™) and a sophisticated chassis, the NSX sets the benchmark for Acura's high-performance lineup.",
				CreatedOn = "2021-05-11"
			};
			ads.Add(adSeventeen);

			Ad adEighteen = new Ad()
			{
				AdId = 18,
				CarId = 18,  
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),  
				CarDescription = "Experience the thrill of the Saab 9-3 Aero, where performance meets innovation. With turbocharged power under the hood and dynamic handling at your fingertips, every drive becomes an exhilarating adventure." +
				" Safety is paramount with standard side impact airbags, while innovations like the 'Night Panel' ensure a focused driving experience." +
				" Discover the ultimate blend of style and performance today.",
				CreatedOn = "2023-10-09"
			};
			ads.Add(adEighteen);

			Ad adNineteen = new Ad()
			{
				AdId = 19,
				CarId = 19,  
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),  
				CarDescription = "Unleash the spirit of adventure with the Saab 9-3 SportCombi." +
				" Designed for those who crave versatility and style, this compact executive car embodies Scandinavian elegance." +
				" From its agile performance to its cutting-edge safety features, the 93 SportCombi is ready to elevate your driving experience. Explore the road with confidence and flair.",
				CreatedOn = "2018-10-09"
			};
			ads.Add(adNineteen);

			Ad adTwenty = new Ad()
			{
				AdId = 20,
				CarId = 20,  
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),  
				CarDescription = "Revolutionize your drive with the Mégane II – a true embodiment of Renault's bold new style. Winner of European Car Of The Year 2003, this car sets the standard for safety and innovation." +
				" With its sleek design and cutting-edge technologies like the Renault Card keyless ignition system, every journey becomes an adventure." +
				" Explore the road with confidence and style.",
				CreatedOn = "2020-10-09"
			};
			ads.Add(adTwenty);

			Ad adTwentyOne = new Ad()
			{
				AdId = 21,
				CarId = 21,  
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),  
				CarDescription = "Experience the thrill of open-top driving with the iconic Honda S2000." +
				" Crafted with precision engineering and a lightweight frame, this roadster delivers exhilarating performance on every curve." +
				" With its powerful engine, sleek design, and advanced features like electronically-assisted steering and Vehicle Stability Assist, the S2000 offers an unmatched driving experience." +
				" Discover the joy of the road like never before.",
				CreatedOn = "2022-11-10"
			};
			ads.Add(adTwentyOne);

			Ad adTwentyTwo = new Ad()
			{
				AdId = 22,
				CarId = 22,  
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),  
				CarDescription = "Elevate your drive with the Honda Civic 7th gen! With its sleek design, spacious interiors, and advanced engine options, this car redefines compact style." +
				" Experience the thrill of the road like never before. Get behind the wheel and discover the perfect blend of innovation and practicality today!",
				CreatedOn = "2023-25-02"
			};
			ads.Add(adTwentyTwo);

			Ad adTwentyThree = new Ad()
			{
				AdId = 23,
				CarId = 23,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				CarDescription = "Get ready to turn heads in the fifth-gen European Honda Accord." +
				" Designed for comfort and performance, this sedan is a joy to drive." +
				" With its sleek exterior and advanced features, it's perfect for your daily commute or weekend adventures." +
				" Experience the ultimate blend of style and reliability with the Honda Accord.",
				CreatedOn = "2024-30-05"
			};
			ads.Add(adTwentyThree);

			return ads;
		}
	}
}
