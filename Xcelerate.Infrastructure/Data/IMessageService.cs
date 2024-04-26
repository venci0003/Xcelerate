using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Infrastructure.Data.Configurations;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data
{
	public class IMessageService : IdentityDbContext<User, IdentityRole<Guid>, Guid>

	{
		private readonly bool seedDb;
		public IMessageService(DbContextOptions<IMessageService> options, bool seedDb = true)
		: base(options)
		{
			this.seedDb = seedDb;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			if (this.seedDb)
			{
				modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
				modelBuilder.ApplyConfiguration(new AdEntityConfiguration());
				modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
				modelBuilder.ApplyConfiguration(new EngineEntityConfiguration());
				modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
				modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
				modelBuilder.ApplyConfiguration(new ManufacturerEntityConfiguration());
				modelBuilder.ApplyConfiguration(new ImageEntityConfiguration());
				modelBuilder.ApplyConfiguration(new AccessoryEntityConfiguration());
				modelBuilder.ApplyConfiguration(new CarAccessoryEntityConfiguration());
				modelBuilder.ApplyConfiguration(new NewsEntityConfiguration());
				modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
				modelBuilder.Entity<StatisticalData>().HasData(
				  new StatisticalData { StatisticId = 1, SoldCars = 160, CreatedCars = 210, CreatedReviews = 88 }
			  );
			}
			else
			{
				modelBuilder.Entity<CarAccessory>().HasKey(ca => new { ca.AccessoryId, ca.CarId });
			}
			base.OnModelCreating(modelBuilder);
		}


		public DbSet<CarAccessory> CarAccessories { get; set; } = null!;
		public DbSet<Accessory> Accessories { get; set; } = null!;
		public DbSet<Image> Images { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Car> Cars { get; set; } = null!;
		public DbSet<Engine> Engines { get; set; } = null!;
		public DbSet<Address> Addresses { get; set; } = null!;
		public DbSet<Ad> Ads { get; set; } = null!;
		public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
		public DbSet<Review> Reviews { get; set; } = null!;
		public DbSet<StatisticalData> StatisticalData { get; set; } = null!;
		public DbSet<News> NewsData { get; set; } = null!;
		public DbSet<Message> Messages { get; set; } = null!;
	}
}
