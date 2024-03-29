﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Infrastructure.Data.Configurations;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data
{
	public class XcelerateContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>

	{
		public XcelerateContext() { }

		public XcelerateContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
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
			modelBuilder.Entity<StatisticalData>().HasData(
			  new StatisticalData { StatisticId = 1, SoldCars = 160, CreatedCars = 210, CreatedReviews = 88 }
		  );
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
	}
}
