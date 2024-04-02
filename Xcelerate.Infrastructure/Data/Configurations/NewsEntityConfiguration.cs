using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class NewsEntityConfiguration : IEntityTypeConfiguration<News>
	{
		public void Configure(EntityTypeBuilder<News> builder)
		{
			ICollection<News> newsCollection = CreateNews();
			builder.HasData(CreateNews());
		}

		private ICollection<News> CreateNews()
		{
			List<News> news = new List<News>();

			News newsOne = new News()
			{
				NewsId = 1,
				Title = "Driving Forward: Accelerating into the Future of Mobility",
				Content = "Explore the dynamic landscape of mobility solutions, from ride-sharing advancements to urban transport innovations." +
				" Delve into the latest trends shaping the way we move and discover how technology is reshaping the concept of transportation as we know it."
			};
			news.Add(newsOne);

			News newsTwo = new News()
			{
				NewsId = 2,
				Title = "Revolutionizing the Road: The Rise of Electric Vehicles",
				Content = "Discover the electrifying revolution sweeping through the automotive world as electric vehicles take center stage." +
				" From Tesla's latest models to emerging EV startups, uncover the driving force behind the shift towards sustainable transportation."
			};
			news.Add(newsTwo);

			News newsThree = new News()
			{
				NewsId = 3,
				Title = "Beyond the Horizon: Exploring the Future of Autonomous Cars",
				Content = "Step into the world of autonomous driving and discover the transformative potential of self-driving technology." +
				" From AI-powered navigation systems to advanced sensor technology, explore the journey towards a safer and more efficient driving experience."
			};
			news.Add(newsThree);

			News newsFour = new News()
			{
				NewsId = 4,
				Title = "Designing Tomorrow: The Art and Science of Automotive Styling",
				Content = "Delve into the captivating world of automotive design and uncover the fusion of artistry and engineering shaping the cars of tomorrow." +
				" From iconic classics to futuristic concepts, explore the evolution of automotive styling through the ages.\r\n"
			};
			news.Add(newsFour);

			News newsFive = new News()
			{
				NewsId = 5,
				Title = "Under the Hood: The Latest in Automotive Engineering",
				Content = "Journey into the heart of automotive innovation and uncover the groundbreaking engineering behind today's most advanced vehicles." +
				" From hybrid powertrains to next-generation materials, explore the technologies driving the future of automotive performance."
			};
			news.Add(newsFive);

			News newsSix = new News()
			{
				NewsId = 6,
				Title = "Green Revolution: Navigating the Shift Towards Sustainable Transportation",
				Content = "Join the movement towards a greener future as the automotive industry embraces sustainability." +
				" From eco-friendly manufacturing practices to zero-emission vehicle initiatives, discover the initiatives driving the transition to a more environmentally conscious transportation ecosystem."
			};
			news.Add(newsSix);

			News newsSeven = new News()
			{
				NewsId = 7,
				Title = "The Road Ahead: Navigating the Challenges of Tomorrow's Mobility",
				Content = "Explore the opportunities and obstacles on the horizon as the automotive industry navigates a rapidly evolving landscape." +
				" From regulatory hurdles to shifting consumer preferences, delve into the complexities shaping the future of mobility."
			};
			news.Add(newsSeven);

			News newsEight = new News()
			{
				NewsId = 8,
				Title = "Unleashing Potential: The Power of Connected Cars",
				Content = "Experience the revolution of connectivity as cars become smarter, more intuitive, and seamlessly integrated into our digital lives." +
				" Explore the latest advancements in vehicle-to-infrastructure technology and discover how connectivity is redefining the driving experience."
			};
			news.Add(newsEight);

			News newsNine = new News()
			{
				NewsId = 9,
				Title = "Innovation Drive: Pioneering Breakthroughs in Automotive Technology",
				Content = "Dive into the forefront of technological innovation as automotive engineers push the boundaries of what's possible." +
				" From augmented reality dashboards to blockchain-enabled supply chains, explore the groundbreaking advancements shaping the future of transportation."
			};
			news.Add(newsNine);

			News newsTen = new News()
			{
				NewsId = 10,
				Title = "Redefining Luxury: The Evolution of High-End Automobiles",
				Content = "Experience the epitome of automotive luxury as leading brands redefine what it means to drive in style." +
				" From opulent interiors to bespoke customization options, discover the latest trends in high-end automotive craftsmanship."
			};
			news.Add(newsTen);

			News newsEleven = new News()
			{
				NewsId = 11,
				Title = "Safety First: Advancing the Standards of Automotive Security",
				Content = "Prioritize safety on the road with a closer look at the latest advancements in automotive security technology." +
				" From advanced driver assistance systems to cutting-edge collision avoidance features, explore the innovations keeping drivers and passengers safe."
			};
			news.Add(newsEleven);

			News newsTwelve = new News()
			{
				NewsId = 12,
				Title = "The Power Play: Exploring the Rise of Electric Performance Vehicles",
				Content = "Witness the intersection of performance and sustainability as electric vehicles redefine the meaning of speed and power." +
				" From lightning-fast acceleration to precision handling, uncover the thrilling capabilities of the latest electric performance models."
			};
			news.Add(newsTwelve);

			News newsThirteen = new News()
			{
				NewsId = 13,
				Title = "Urban Mobility: Navigating the Future of City Transportation",
				Content = "Address the unique challenges of urban transportation with innovative solutions designed for the cityscape. From compact electric scooters to autonomous shuttle services, discover how urban mobility initiatives are reshaping the way we navigate our cities.\r\n"
			};
			news.Add(newsThirteen);

			News newsFourteen = new News()
			{
				NewsId = 14,
				Title = "Test14",
				Content = "Test14"
			};
			news.Add(newsFourteen);

			News newsFifteen = new News()
			{
				NewsId = 15,
				Title = "Behind the Scenes: The Manufacturing Revolution in Automotive Production",
				Content = "Peek behind the curtain of automotive manufacturing and witness the transformative changes revolutionizing production processes." +
				" From 3D printing to AI-driven automation, explore the technologies driving efficiency and sustainability in car factories."
			};
			news.Add(newsFifteen);

			News newsSixteen = new News()
			{
				NewsId = 16,
				Title = "The Race for Autonomy: Competing Visions in Self-Driving Technology",
				Content = "Embark on a journey through the competitive landscape of autonomous driving as industry giants and startups vie for leadership." +
				" From Tesla's Full Self-Driving Beta to Waymo's robotaxis, explore the diverse approaches shaping the future of self-driving technology."
			};
			news.Add(newsSixteen);

			News newsSeventeen = new News()
			{
				NewsId = 17,
				Title = "Charging Ahead: Overcoming Challenges in the Electric Vehicle Infrastructure",
				Content = "Address the critical infrastructure needs of the growing electric vehicle market and explore solutions to charging accessibility and range anxiety." +
				" From fast-charging networks to battery swapping stations, uncover the innovations driving the EV charging revolution.\r\n"
			};
			news.Add(newsSeventeen);

			News newsEighteen = new News()
			{
				NewsId = 18,
				Title = "Sustainable Innovation: Eco-Friendly Materials in Automotive Design",
				Content = "Explore the shift towards sustainable materials in automotive design and discover how eco-friendly alternatives are reshaping the industry." +
				" From recycled plastics to plant-based composites, delve into the cutting-edge materials driving sustainability in car manufacturing."
			};
			news.Add(newsEighteen);

			News newsNineteen = new News()
			{
				NewsId = 19,
				Title = "The Evolution of Mobility: Bridging the Gap Between Tradition and Innovation",
				Content = "Trace the evolution of transportation from horse-drawn carriages to the electric, connected vehicles of today." +
				" Explore how traditional automotive principles merge with modern innovation to shape the future of mobility for generations to come."
			};
			news.Add(newsNineteen);

			News newsTwenty = new News()
			{
				NewsId = 20,
				Title = "Driving Diversity: Empowering Women in the Automotive Industry",
				Content = "Spotlight the contributions of women in the traditionally male-dominated automotive sector and explore initiatives aimed at promoting diversity and inclusion." +
				" From female engineers to women in leadership roles, celebrate the trailblazers shaping the future of the industry.\r\n"
			};
			news.Add(newsTwenty);

			News newsTwentyOne = new News()
			{
				NewsId = 21,
				Title = "Car Manufacturers Launch \"Selfie Mode\" for Cars",
				Content = "In a bid to appeal to the younger generation, car manufacturers unveil \"selfie mode\" for cars." +
				" Now your car can take better selfies than you, complete with flattering angles and Instagram filters."
			};
			news.Add(newsTwentyOne);

			News newsTwentyTwo = new News()
			{
				NewsId = 22,
				Title = "Study Reveals: Car Horns to be Replaced by Laughter",
				Content = "A groundbreaking study suggests that car horns will soon be replaced by laughter." +
				" Imagine traffic jams turning into laugh fests, with drivers honking out giggles instead of frustrations." +
				" Get ready for a happier commute!"
			};
			news.Add(newsTwentyTwo);

			News newsTwentyThree = new News()
			{
				NewsId = 23,
				Title = "Breakthrough: Cars Now Run on Coffee",
				Content = "In a remarkable breakthrough, scientists have developed a new engine that runs entirely on coffee." +
				" Now, not only can you get your caffeine fix, but you can also fuel your car with it!" +
				" Say goodbye to gas stations and hello to coffee shops on every corner."
			};
			news.Add(newsTwentyThree);

			News newsTwentyFour = new News()
			{
				NewsId = 24,
				Title = "Traffic Jam Transformed into World's Longest Dance Party",
				Content = "What started as a typical traffic jam turned into an unexpected celebration as drivers stepped out of their cars and broke into dance." +
				" The impromptu party lasted for hours, with motorists grooving to the beat of their favorite tunes, turning frustration into fun."
			};
			news.Add(newsTwentyFour);

			News newsTwentyFive = new News()
			{
				NewsId = 25,
				Title = "City Introduces 'Honk-Free' Day",
				Content = "In an effort to reduce noise pollution and promote tranquility, the city council has declared a 'honk-free' day." +
				" Drivers are encouraged to use alternative means of communication, such as waving or smiling, instead of honking."
			};
			news.Add(newsTwentyFive);

			News newsTwentySix = new News()
			{
				NewsId = 26,
				Title = "Cat Drives Owner's Car to Pet Store",
				Content = "In a purr-fectly surprising turn of events, a clever cat managed to start its owner's car and drive to the pet store." +
				" Witnesses were amazed as the feline calmly navigated traffic and even signaled for turns. Looks like cats aren't just experts at napping—they're mastering driving too!"
			};
			news.Add(newsTwentySix);

			News newsTwentySeven = new News()
			{
				NewsId = 27,
				Title = "New Study Reveals: Dogs Can Drive Cars!",
				Content = "In a groundbreaking study, researchers have discovered that dogs can be trained to operate vehicles. Doggie drivers? It's not just a dream anymore!"
			};
			news.Add(newsTwentySeven);

			News newsTwentyEight = new News()
			{
				NewsId = 28,
				Title = "Giant Rubber Duck Causes Traffic Chaos",
				Content = "A larger-than-life rubber duck sculpture broke free from its moorings and waddled down the streets, causing hilarious chaos and bringing traffic to a standstill."
			};
			news.Add(newsTwentyEight);

			News newsTwentyNine = new News()
			{
				NewsId = 29,
				Title = "Local Grandma Wins Street Racing Competition",
				Content = "In an unexpected turn of events, a local grandmother shocked everyone by winning a street racing competition." +
				" Her secret? She's been playing video games for decades!"
			};
			news.Add(newsTwentyNine);

			News newsThirty = new News()
			{
				NewsId = 30,
				Title = "World's First Flying Car Takes Off",
				Content = "The world's first flying car successfully completed its maiden flight, soaring through the skies and marking a new era in transportation." +
				" The future is here!"
			};
			news.Add(newsThirty);

			News newsThirtyOne = new News()
			{
				NewsId = 31,
				Title = "Scientists Discover Cars Can Communicate with Each Other",
				Content = "In a fascinating discovery, scientists have found that cars possess a hidden language, allowing them to communicate with each other on the road." +
				" Are they plotting traffic jams or just chatting about the weather?"
			};
			news.Add(newsThirtyOne);

			return news;
		}

	}
}
