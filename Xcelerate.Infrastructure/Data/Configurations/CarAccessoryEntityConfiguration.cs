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

			var thirdcarAccessories = new List<int> { 20, 9, 14, 7, 18, 5, 11, 15, 8, 3, 16, 12, 2, 10, 6, 1, 13, 19, 4, 17 };
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

			var eleventhCarAccessories = new List<int> { 3, 4, 5, 6, 7, 19 };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 11 }));

			var twelfthCarAccessories = new List<int> { 3, 4, 5, 6, 7, 19, 13, 14, 20, 40, 41, 42, 43, 10, 33 };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 12 }));

			var thirteenthCarAccessories = new List<int> { 1, 3, 2, 4, 5, 6, 7, 8, 9, 13, 12, 11 };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 13 }));

			var fourteenthCarAccessories = new List<int> { 7, 8, 2, 3, 1, 4, 5, 9, 20, 11, 16, 18, 40, 32, 37 };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 14 }));

			var fifteenthCarAccessories = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 15, 20, 23, 34, 45, 44, 41, 32, 10, };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 15 }));

			var sixteenthCarAccessories = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 14, 15, 16, 17, 19, 30, 42, 37, 44 };
			carAccessories.AddRange(tenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 16 }));

			var seventeenthCarAccessories = new List<int> { 21, 22, 23, 25, 26, 27, 28, 29, 31, 33, 35, 36, 38, 40, 43 };
			carAccessories.AddRange(seventeenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 17 }));

			var eighteenthCarAccessories = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 45, 32, 22, 21, 20, 36, 11, 12, 13, 14 };
			carAccessories.AddRange(eighteenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 18 }));

			var nineteenthCarAccessories = new List<int> { 1, 3, 5, 7, 10, 13, 15, 17, 19, 30, 42, 37, 44, 45 };
			carAccessories.AddRange(nineteenthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 19 }));

			var twentiethCarAccessories = new List<int> { 6, 9, 12, 14, 18, 22, 24, 26, 31, 33, 35, 38, 40, 43 };
			carAccessories.AddRange(twentiethCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 20 }));

			var twentyFirstCarAccessories = new List<int> { 1, 3, 5, 7, 10, 13, 15, 17, 19, 30, 42, 37, 44, 45 };
			carAccessories.AddRange(twentyFirstCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 21 }));

			var twentySecondCarAccessories = new List<int> { 2, 4, 6, 8, 11, 14, 16, 18, 20, 22, 24, 26, 28, 32 };
			carAccessories.AddRange(twentySecondCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 22 }));

			var twentyThirdCarAccessories = new List<int> { 1, 5, 9, 13, 17, 21, 25, 29, 33, 37, 41, 45 };
			carAccessories.AddRange(twentyThirdCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 23 }));

			//var twentyFourthCarAccessories = new List<int> { 2, 6, 10, 14, 18, 22, 26, 30, 34, 38, 42, 44 };
			//carAccessories.AddRange(twentyFourthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 24 }));

			//var twentyFifthCarAccessories = new List<int> { 3, 7, 11, 15, 19, 23, 27, 31, 35, 39, 43, 45 };
			//carAccessories.AddRange(twentyFifthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 25 }));

			//var twentySixthCarAccessories = new List<int> { 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 42, 44 };
			//carAccessories.AddRange(twentySixthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 26 }));

			//var twentySeventhCarAccessories = new List<int> { 1, 5, 9, 13, 17, 21, 25, 29, 33, 37, 41, 45 };
			//carAccessories.AddRange(twentySeventhCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 27 }));

			//var twentyEighthCarAccessories = new List<int> { 2, 6, 10, 14, 18, 22, 26, 30, 34, 38, 42, 44 };
			//carAccessories.AddRange(twentyEighthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 28 }));

			//var twentyNinthCarAccessories = new List<int> { 3, 7, 11, 15, 19, 23, 27, 31, 35, 39, 43, 45 };
			//carAccessories.AddRange(twentyNinthCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 29 }));

			//var thirtiethCarAccessories = new List<int> { 1, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 45 };
			//carAccessories.AddRange(thirtiethCarAccessories.Select(accessoryId => new CarAccessory { AccessoryId = accessoryId, CarId = 30 }));


			return carAccessories;
		}
	}
}
