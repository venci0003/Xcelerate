using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class CarAccessoryEntityConfiguration : IEntityTypeConfiguration<CarAccessory>
	{
		public void Configure(EntityTypeBuilder<CarAccessory> builder)
		{
			builder.HasKey(ca => new { ca.AccessoryId, ca.CarId });

			builder.HasOne(c => c.Car).WithMany(ca => ca.CarAccessories).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(a => a.Accessory).WithMany(ca => ca.CarAccessories).OnDelete(DeleteBehavior.NoAction);

			ICollection<CarAccessory> accessoriesCollection = CreateCarAccessories();
			builder.HasData(CreateCarAccessories());
		}

		private ICollection<CarAccessory> CreateCarAccessories()
		{
			List<CarAccessory> carAccessories = new List<CarAccessory>();

			var firstcarAccessories = new List<int> { 8, 14, 3, 19, 10, 2, 7, 16, 5, 11, 20, 4, 18, 13, 9, 6, 1, 12, 17, 15 };
			carAccessories.AddRange(firstcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 1 }));

			var secondcarAccessories = new List<int> { 25, 7, 16, 4, 10, 19, 12, 3, 18, 6, 15, 22, 1, 8, 13, 5, 11, 9, 14, 17 };
			carAccessories.AddRange(secondcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 2 }));

			var thirdcarAccessories = new List<int> {20, 9, 14, 7, 18, 5, 11, 15, 8, 3, 16, 12, 2, 10, 6, 1, 13, 19, 4, 17 };
			carAccessories.AddRange(thirdcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 3 }));

			var fourthcarAccessories = new List<int> { 25, 6, 14, 33, 9, 41, 18, 3, 11, 36, 28, 7, 22, 15, 30, 8, 13, 45, 2, 39 };
			carAccessories.AddRange(fourthcarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 4 }));

			var fifthCarAccessories = new List<int> { 2, 16, 35, 27, 10, 19, 8, 22, 30, 14, 45, 36, 1, 12, 6, 18, 13, 31, 40, 9 };
			carAccessories.AddRange(fifthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 5 }));

			var sixthCarAccessories = new List<int> { 33, 17, 5, 26, 8, 42, 20, 11, 35, 14, 1, 19, 10, 27, 7, 13, 39, 16, 31, 22 };
			carAccessories.AddRange(sixthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 6 }));

			var seventhCarAccessories = new List<int> { 23, 12, 8, 29, 41, 15, 37, 7, 20, 33, 10, 5, 18, 26, 14, 35, 3, 45, 21, 1 };
			carAccessories.AddRange(seventhCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 7 }));

			var eighthCarAccessories = new List<int> { 5, 19, 12, 30, 8, 27, 16, 10, 22, 33, 14, 40, 7, 26, 1, 35, 18, 45, 3, 9 };
			carAccessories.AddRange(eighthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 8 }));

			var ninthCarAccessories = new List<int> { 42, 15, 8, 22, 37, 13, 28, 5, 18, 30, 11, 3, 21, 10, 35, 19, 26, 1, 7, 45 };
			carAccessories.AddRange(ninthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 9 }));

			var tenthCarAccessories = new List<int> { 8, 19, 35, 7, 45, 26, 18, 10, 33, 12, 5, 22, 15, 1, 40, 14, 27, 9, 3, 16 };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 10 }));

			return carAccessories;
		}
	}
}
