using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .OnDelete(DeleteBehavior.NoAction);

            ICollection<Review> reviewsCollection = CreateReviews();
            builder.HasData(CreateReviews());
        }


        private ICollection<Review> CreateReviews()
        {
            List<Review> reviews = new List<Review>();

            Review firstCarFirstReview = new Review()
            {
                ReviewId = 1,
                Comment = "Love the sporty feel of my Toyota Camry TRD!" +
                " The handling is superb, and the interior is stylish." +
                " The TRD enhancements really add a punch." +
                " A great choice for those seeking a blend of performance and comfort.",
                StarsCount = 5,
                UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"), 
                AdId = 1   
            };
            reviews.Add(firstCarFirstReview);

            Review firstCarSecondReview = new Review()
            {
                ReviewId = 2,
                Comment = "Impressed with the Toyota Camry TRD's acceleration and overall performance." +
                " The exterior design is eye-catching, and the cabin is spacious and comfortable." +
                " However, fuel efficiency could be better for a sedan in this segment.",
                StarsCount = 5,		
                UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"), // Assuming you have a user with Id 2
                AdId = 1  
            };
            reviews.Add(firstCarSecondReview);

            Review firstCarThirdReview = new Review()
            {
                ReviewId = 3,
                Comment = "The Toyota Camry TRD disappointed me with its lackluster fuel economy." +
                " Despite its sporty appearance, the ride quality feels a bit stiff, especially on rough roads." +
                " It's a decent option if you prioritize performance over fuel efficiency.",
                StarsCount = 2,
                UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"), // Assuming you have a user with Id 3
                AdId = 1   
            };
            reviews.Add(firstCarThirdReview);

            Review firstCarFourthReview = new Review()
            {
                ReviewId = 4,
                Comment = "Absolutely thrilled with my Toyota Camry TRD!" +
                " The sleek design turns heads wherever I go, and the handling is smooth and responsive. Interior features are top-notch, making every drive enjoyable." +
                " Highly recommend this car!",
                StarsCount = 5,
                UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"), 
                AdId = 1   
            };
            reviews.Add(firstCarFourthReview);

            Review firstCarFifthReview = new Review()
            {
                ReviewId = 5,
                Comment = "My experience with the Toyota Camry TRD has been mixed." +
                " While the performance is commendable and the cabin is comfortable, I've encountered issues with the infotainment system, which can be frustrating to use at times.",
                StarsCount = 3,
                UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),
                AdId = 1 
            };
            reviews.Add(firstCarFifthReview);

            Review secondCarFirstReview = new Review()
            {
                ReviewId = 6,
                Comment = "The Honda Civic Type R is an absolute blast to drive!" +
                " Its turbocharged engine delivers exhilarating performance, and the sharp handling makes every corner a joy." +
                " The aggressive styling sets it apart from the crowd. Highly recommended!",
                StarsCount = 5,
                UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
                AdId = 2 
            };
            reviews.Add(secondCarFirstReview);

            Review secondCarSecondReview = new Review()
            {
                ReviewId = 7,
                Comment = "The Honda Civic Type R offers impressive performance and handling, but the stiff ride quality may not be suitable for everyone." +
                " The cabin is spacious and well-equipped, though some may find the design too flashy for their taste.",
                StarsCount = 3,
                UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
                AdId = 2 
            };
			reviews.Add(secondCarSecondReview);

			Review secondCarThirdReview = new Review()
            {
                ReviewId = 8,
                Comment = "Disappointed with the Honda Civic Type R's fuel efficiency, as it falls short compared to other models in its class." +
                " While the performance is thrilling, the ride can feel harsh on rough roads. Not the most practical choice for daily commuting",
                StarsCount = 2,
                UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"), // Assuming you have a user with Id 8
                AdId = 2
            };
            reviews.Add(secondCarThirdReview);

            Review secondCarFourthReview = new Review()
            {
                ReviewId = 9,
                Comment = "Absolutely loving my Honda Civic Type R! " +
                "The aggressive styling turns heads wherever I go, and the performance is simply outstanding." +
                " The interior is comfortable and packed with features. A dream car for enthusiasts!",
                StarsCount = 5,
                UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),
                AdId = 2 
            };
            reviews.Add(secondCarFourthReview);

            Review secondCarFifthReview = new Review()
            {
                ReviewId = 10,
                Comment = "The Honda Civic Type R is a mixed bag for me. While I appreciate its performance and handling, the loud exhaust can become tiresome on long drives." +
                " Additionally, the infotainment system feels outdated compared to rivals in its segment.",
                StarsCount = 4,
                UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"), 
                AdId = 2 
            };
            reviews.Add(secondCarFifthReview);

			Review thirdCarFirstReview = new Review()
			{
				ReviewId = 11,
				Comment = "The Ford Mustang GT350R is a true performance machine!" +
                " Its V8 engine roars with power, and the precise handling makes every drive exhilarating." +
                " The aggressive styling and track-focused features set it apart." +
                " A must-have for any enthusiast!",
				StarsCount = 5,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				AdId = 3   
			};
			reviews.Add(thirdCarFirstReview);

			Review thirdCarSecondReview = new Review()
			{
				ReviewId = 12,
				Comment = "The Ford Mustang GT350R offers thrilling performance and a track-ready setup, but its stiff suspension may not suit everyone's tastes for daily driving." +
                " The cabin is sporty and well-appointed, though some may find it lacking in refinement.",
				StarsCount = 3,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"), 
				AdId = 3    
			};
			reviews.Add(thirdCarSecondReview);

			Review thirdCarThirdReview = new Review()
			{
				ReviewId = 13,
				Comment = "Disappointed with the Ford Mustang GT350R's fuel economy, which falls short of expectations for a modern sports car." +
                " While the performance is thrilling, the stiff ride and loud exhaust may be too much for some buyers. Not ideal for daily commuting.",
				StarsCount = 1,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"), 
				AdId = 3
			};
			reviews.Add(thirdCarThirdReview);

			Review thirdCarFourthReview = new Review()
			{
				ReviewId = 14,
				Comment = "Absolutely blown away by the Ford Mustang GT350R!" +
                " The aggressive styling, track-tuned performance, and spine-tingling exhaust note make every drive an adrenaline rush." +
                " The handling is razor-sharp, and the interior is race-inspired." +
                " A true driver's car!",
				StarsCount = 5,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				AdId = 3
			};
			reviews.Add(thirdCarFourthReview);

			Review thirdCarFifthReview = new Review()
			{
				ReviewId = 15,
				Comment = "The Ford Mustang GT350R offers thrilling performance, but its harsh ride and loud exhaust can become fatiguing on long drives." +
                " Additionally, the lack of advanced technology features may disappoint buyers seeking modern conveniences in a sports car.",
				StarsCount = 4,
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"),
				AdId = 3
			};
			reviews.Add(thirdCarFifthReview);

			Review fourthCarFirstReview = new Review()
			{
				ReviewId = 16,
				Comment = "The Golf is a versatile and practical hatchback." +
                " Its fuel-efficient engine delivers impressive performance, and the handling is nimble around city streets." +
                " The interior is well-built and spacious, making it a great choice for daily commuting or weekend getaways.",
				StarsCount = 5,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 4
			};
			reviews.Add(fourthCarFirstReview);

			Review fourthCarSecondReview = new Review()
			{
				ReviewId = 17,
				Comment = "The Volkswagen Golf offers a balanced mix of performance and comfort." +
                " While it may not be as powerful as some rivals, its refined ride quality and upscale interior make it a compelling choice for those prioritizing comfort and practicality over outright performance.",
				StarsCount = 4,
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				AdId = 4
			};
			reviews.Add(fourthCarSecondReview);

			Review fourthCarThirdReview = new Review()
			{
				ReviewId = 18,
				Comment = "The Volkswagen's performance may feel underwhelming to enthusiasts seeking more power and excitement." +
                " Additionally, some competitors offer more advanced tech features. However, its fuel efficiency and comfortable ride make it a sensible option for daily driving.",
				StarsCount = 3,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				AdId = 4
			};
			reviews.Add(fourthCarThirdReview);

			Review fourthCarFourthReview = new Review()
			{
				ReviewId = 19,
				Comment = "Absolutely loving this car! It strikes the perfect balance between fun-to-drive dynamics and everyday usability." +
                " The interior is modern and well-equipped, and the compact size makes it easy to navigate through city traffic." +
                " Highly recommended!",
				StarsCount = 5,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				AdId = 4
			};
			reviews.Add(fourthCarFourthReview);

			Review fourthCarFifthReview = new Review()
			{
				ReviewId = 20,
				Comment = "While the Volkswagen Golf offers a comfortable ride and solid build quality, it lacks the engaging driving experience of some rivals." +
                " The interior design feels a bit dated, and the infotainment system could be more user-friendly." +
                " Overall, a decent choice in the hatchback segment.",
				StarsCount = 2,
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),
				AdId = 4
			};
			reviews.Add(fourthCarFifthReview);

			Review fifthCarFirstReview = new Review()
			{
				ReviewId = 21,
				Comment = "The Mercedes-Benz C-Class exudes luxury and sophistication." +
                " Its refined interior, comfortable ride, and advanced technology features elevate the driving experience." +
                " The powerful engine options deliver smooth performance, making every journey a pleasure." +
                " A class-leading choice in its segment.",
				StarsCount = 5,
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),
				AdId = 5
			};
			reviews.Add(fifthCarFirstReview);

			Review fifthCarSecondReview = new Review()
			{
				ReviewId = 22,
				Comment = "The Mercedes-Benz C-Class offers a perfect blend of luxury and performance." +
                " Its elegant exterior design is matched by a plush interior with high-quality materials." +
                " The ride is smooth and composed, though some may find the handling less engaging compared to sportier rivals.",
				StarsCount = 5,
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				AdId = 5
			};
			reviews.Add(fifthCarSecondReview);

			Review fifthCarThirdReview = new Review()
			{
				ReviewId = 23,
				Comment = "While the Mercedes-Benz C-Class impresses with its luxurious interior and smooth ride, it falls short in terms of reliability compared to some competitors." +
                " Additionally, the infotainment system can be complicated to use, detracting from the overall driving experience.",
				StarsCount = 3,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				AdId = 5
			};
			reviews.Add(fifthCarThirdReview);

			Review fifthCarFourthReview = new Review()
			{
				ReviewId = 24,
				Comment = "Absolutely thrilled with my car! The attention to detail in its design, the refined interior, and the smooth, powerful performance make it a standout choice in the luxury sedan segment." +
                " Driving this car is truly a pleasure!",
				StarsCount = 5,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				AdId = 5
			};
			reviews.Add(fifthCarFourthReview);

			Review fifthCarFifthReview = new Review()
			{
				ReviewId = 25,
				Comment = "The Mercedes-Benz C-Class offers a luxurious driving experience, but it comes at a steep price." +
                " Some may find the base engine underpowered compared to rivals, and the optional features can quickly inflate the cost." +
                " Overall, a premium choice for those willing to pay the premium price.",
				StarsCount = 4,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 5
			};
			reviews.Add(fifthCarFifthReview);

			Review sixthCarFirstReview = new Review()
			{
				ReviewId = 26,
				Comment = "The Audi A3 is a fantastic blend of luxury and performance." +
				" Its sleek design, upscale interior, and smooth ride make it a standout in its class." +
				" The available tech features add convenience and sophistication to the driving experience." +
				" Highly recommended!",
				StarsCount = 5,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				AdId = 6
			};
			reviews.Add(sixthCarFirstReview);

			Review sixthCarSecondReview = new Review()
			{
				ReviewId = 27,
				Comment = "The Audi A3 offers a refined driving experience with a comfortable ride and luxurious interior." +
				" However, some may find the backseat space lacking, and the base engine could use more power." +
				" Overall, a solid choice for those seeking a compact luxury sedan.",
				StarsCount = 4,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 6
			};
			reviews.Add(sixthCarSecondReview);

			Review sixthCarThirdReview = new Review()
			{
				ReviewId = 28,
				Comment = "While the Audi A3 impresses with its stylish design and upscale interior, it falls short in terms of performance compared to some rivals." +
				" The base engine lacks punch, and the handling may not be as engaging as sportier competitors in its segment.",
				StarsCount = 3,
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				AdId = 6
			};
			reviews.Add(sixthCarThirdReview);

			Review sixthCarFourthReview = new Review()
			{
				ReviewId = 29,
				Comment = "Absolutely love my Audi A3!" +
				" The sleek exterior, premium interior, and responsive handling make every drive a joy." +
				" The turbocharged engine provides plenty of power, and the advanced tech features add convenience and sophistication." +
				" Couldn't be happier with my choice!",
				StarsCount = 5,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				AdId = 6
			};
			reviews.Add(sixthCarFourthReview);

			Review sixthCarFifthReview = new Review()
			{
				ReviewId = 30,
				Comment = "The Audi A3 offers a luxurious interior and comfortable ride, but it comes at a premium price compared to some competitors." +
				" Additionally, the backseat space is cramped, and the infotainment system can be complicated to use while driving." +
				" Overall, a decent option in the luxury compact sedan segment.",
				StarsCount = 3,
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),
				AdId = 6
			};
			reviews.Add(sixthCarFifthReview);

			Review seventhCarFirstReview = new Review()
			{
				ReviewId = 31,
				Comment = "The Infiniti QX80 is the epitome of luxury and power." +
				" Its spacious and opulent interior, combined with a commanding presence on the road, makes it a standout in its class." +
				" The smooth ride and powerful engine ensure a premium driving experience.",
				StarsCount = 5,
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				AdId = 7
			};
			reviews.Add(seventhCarFirstReview);

			Review seventhCarSecondReview = new Review()
			{
				ReviewId = 32,
				Comment = "The Infiniti QX80 offers a luxurious and comfortable ride with its spacious cabin and upscale materials." +
				" However, its handling can feel cumbersome, especially in tight spaces." +
				" The fuel economy could also be better for a vehicle of its size.",
				StarsCount = 4,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				AdId = 7
			};
			reviews.Add(seventhCarSecondReview);

			Review seventhCarThirdReview = new Review()
			{
				ReviewId = 33,
				Comment = "While the Infiniti QX80 impresses with its luxurious interior and powerful engine, its fuel economy leaves much to be desired." +
				" The handling feels bulky, and the dated infotainment system lacks the modern features found in competitors.",
				StarsCount = 2,
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"),
				AdId = 7
			};
			reviews.Add(seventhCarThirdReview);

			Review seventhCarFourthReview = new Review()
			{
				ReviewId = 34,
				Comment = "Absolutely in love with my Infiniti QX80! The plush interior, smooth ride, and abundance of high-tech features make every journey a pleasure." +
				" The powerful engine effortlessly cruises on the highway, and the spacious cabin ensures comfort for all passengers.",
				StarsCount = 5,
				UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),
				AdId = 7
			};
			reviews.Add(seventhCarFourthReview);

			Review seventhCarFifthReview = new Review()
			{
				ReviewId = 35,
				Comment = "The Infiniti QX80 offers a luxurious driving experience with its upscale interior and powerful engine." +
				" However, its large size can make it challenging to maneuver in tight spaces, and the fuel economy is below average for its class." +
				" Consider other options if efficiency is a priority.",
				StarsCount = 2,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				AdId = 7
			};
			reviews.Add(seventhCarFifthReview);

			Review eighthCarFirstReview = new Review()
			{
				ReviewId = 36,
				Comment = "The Hyundai Elantra is a fantastic value for its class." +
				" Its sleek design, comfortable ride, and generous standard features make it a top choice for budget-conscious buyers." +
				" The fuel efficiency is impressive, making it practical for daily commuting.",
				StarsCount = 4,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 8
			};
			reviews.Add(eighthCarFirstReview);

			Review eighthCarSecondReview = new Review()
			{
				ReviewId = 37,
				Comment = "The Hyundai Elantra offers a comfortable ride and a spacious cabin with plenty of tech features, making it a practical choice for everyday driving." +
				" However, the handling could be more engaging, and some competitors offer more powerful engine options.",
				StarsCount = 4,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				AdId = 8
			};
			reviews.Add(eighthCarSecondReview);

			Review eighthCarThirdReview = new Review()
			{
				ReviewId = 38,
				Comment = "While the Hyundai Elantra boasts a sleek design and comfortable ride, it falls short in terms of performance compared to rivals." +
				" The base engine lacks power, and the handling may not be as sharp as some competitors in its segment.",
				StarsCount = 3,
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),
				AdId = 8
			};
			reviews.Add(eighthCarThirdReview);

			Review eighthCarFourthReview = new Review()
			{
				ReviewId = 39,
				Comment = "Absolutely delighted with my Hyundai Elantra!" +
				" It exceeds expectations with its stylish design, comfortable interior, and smooth ride." +
				" The fuel efficiency is a major plus, saving me money at the pump without sacrificing performance." +
				" Highly recommend!",
				StarsCount = 5,
				UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				AdId = 8
			};
			reviews.Add(eighthCarFourthReview);

			Review eighthCarFifthReview = new Review()
			{
				ReviewId = 40,
				Comment = "The Hyundai Elantra offers decent value for its price, but it lacks the refinement and performance of some competitors." +
				" The interior materials feel cheap, and the ride can be noisy on rough roads." +
				" Consider other options if you prioritize comfort and luxury.",
				StarsCount = 1,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				AdId = 8
			};
			reviews.Add(eighthCarFifthReview);

			Review ninethCarFirstReview = new Review()
			{
				ReviewId = 41,
				Comment = "The BMW 3 Series disappointed me with its lackluster reliability." +
				" I've had numerous issues with the engine and electronics, leading to costly repairs. Additionally, the interior feels cramped, and the ride quality is rough on uneven roads." +
				" Not worth the premium price tag.",
				StarsCount = 1,
				UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"),
				AdId = 9
			};
			reviews.Add(ninethCarFirstReview);

			Review ninethCarSecondReview = new Review()
			{
				ReviewId = 42,
				Comment = "My experience with the BMW 3 Series has been marred by constant trips to the dealership for repairs." +
				" The build quality is subpar, with various components failing prematurely." +
				" The infotainment system is overly complicated and prone to glitches." +
				" A frustrating ownership experience overall.",
				StarsCount = 1,
				UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				AdId = 9
			};
			reviews.Add(ninethCarSecondReview);

			Review ninethCarThirdReview = new Review()
			{
				ReviewId = 43,
				Comment = "The BMW 3 Series fell short of my expectations in terms of performance." +
				" The handling, while decent, lacks the precision and agility I anticipated from a sport sedan." +
				" The engine feels underpowered, especially compared to rivals in its class." +
				" Disappointed with the overall driving dynamics.",
				StarsCount = 2,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 9
			};
			reviews.Add(ninethCarThirdReview);

			Review ninethCarFourthReview = new Review()
			{
				ReviewId = 44,
				Comment = "I regret purchasing the BMW 3 Series due to its exorbitant maintenance costs." +
				" Routine service visits are unnecessarily expensive, and parts are priced at a premium." +
				" The resale value is also disappointing, making ownership costs higher than anticipated." +
				" Not a wise investment in the long run.",
				StarsCount = 1,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				AdId = 9
			};
			reviews.Add(ninethCarFourthReview);

			Review ninethCarFifthReview = new Review()
			{
				ReviewId = 45,
				Comment = "The BMW 3 Series failed to impress me with its outdated design and lack of modern features." +
				" The interior feels dated compared to competitors, and the infotainment system is clunky and unintuitive." +
				" The ride quality is harsh, especially on rough roads. Expected more from a luxury sedan.",
				StarsCount = 4,
				UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),
				AdId = 9
			};
			reviews.Add(ninethCarFifthReview);

			Review tenthCarFirstReview = new Review()
			{
				ReviewId = 46,
				Comment = "Absolutely loving my Nissan Rogue!" +
				" It's the perfect blend of practicality and comfort." +
				" Whether it's grocery runs or road trips, this SUV handles it all with ease." +
				" Plus, the fuel efficiency is a pleasant surprise." +
				" Highly recommend to anyone in need of a reliable and versatile vehicle.",
				StarsCount = 5,
				UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				AdId = 10
			};
			reviews.Add(tenthCarFirstReview);

			Review tenthCarSecondReview = new Review()
			{
				ReviewId = 47,
				Comment = "The Nissan Rogue has been a game-changer for my family." +
				" With its spacious interior and smooth ride, our road trips have become much more enjoyable." +
				" The safety features give us peace of mind, and the stylish design doesn't hurt either." +
				" Couldn't be happier with our choice!",
				StarsCount = 5,
				UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				AdId = 10
			};
			reviews.Add(tenthCarSecondReview);

			Review tenthCarThirdReview = new Review()
			{
				ReviewId = 48,
				Comment = "My Nissan Rogue has exceeded all my expectations." +
				" From its sleek exterior to its comfortable interior, it's a joy to drive every day." +
				" The fuel economy is impressive, and the tech features keep me connected on the go." +
				" Overall, a solid investment that I'm glad I made.",
				StarsCount = 4,
				UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				AdId = 10
			};
			reviews.Add(tenthCarThirdReview);

			Review tenthCarFourthReview = new Review()
			{
				ReviewId = 49,
				Comment = "The Nissan Rogue has been the perfect companion for my adventurous lifestyle." +
				" Its ample cargo space easily accommodates all my gear, and the intelligent AWD system gives me confidence in any terrain." +
				" Plus, the fuel efficiency means I can explore without breaking the bank." +
				" Highly recommend to fellow outdoor enthusiasts!",
				StarsCount = 4,
				UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				AdId = 10
			};
			reviews.Add(tenthCarFourthReview);

			Review tenthCarFifthReview = new Review()
			{
				ReviewId = 50,
				Comment = "Overall, my experience with the Nissan Rogue has been average." +
				" While it fulfills its purpose as a family-friendly SUV with ample space and decent fuel economy, I find the ride quality to be somewhat lacking, especially on rough roads." +
				" Additionally, some of the interior materials feel a bit cheap for its price range.",
				StarsCount = 3,
				UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				AdId = 10
			};
			reviews.Add(tenthCarFifthReview);

			return reviews;
		}
    }
}
