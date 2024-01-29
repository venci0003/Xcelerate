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
	public class AccessoryEntityConfiguration : IEntityTypeConfiguration<Accessory>
	{
		public void Configure(EntityTypeBuilder<Accessory> builder)
		{
			builder
				.HasMany(a => a.CarAccessories)
				.WithOne(ca => ca.Accessory)
				.OnDelete(DeleteBehavior.NoAction);

			ICollection<Accessory> accessoriesCollection = CreateAccesories();
			builder.HasData(CreateAccesories());
		}

		private ICollection<Accessory> CreateAccesories()
		{
			List<Accessory> accessories = new List<Accessory>();

			Accessory firstAccessory = new Accessory
			{
				AccessoryId = 1,
				Name = "GpsTrackingSystem"
			};
			accessories.Add(firstAccessory);

			Accessory secondAccessory = new Accessory
			{
				AccessoryId = 2,
				Name = "AutomaticStabilityControl"
			};
			accessories.Add(secondAccessory);

			Accessory thirdAccessory = new Accessory
			{
				AccessoryId = 3,
				Name = "AdaptiveHeadlights"
			};
			accessories.Add(thirdAccessory);

			Accessory fourthAccessory = new Accessory
			{
				AccessoryId = 4,
				Name = "Abs"
			};
			accessories.Add(fourthAccessory);

			Accessory fifthAccessory = new Accessory
			{
				AccessoryId = 5,
				Name = "RearAirbags"
			};
			accessories.Add(fifthAccessory);

			Accessory sixthAccessory = new Accessory
			{
				AccessoryId = 6,
				Name = "FrontAirbags"
			};
			accessories.Add(sixthAccessory);

			Accessory seventhAccessory = new Accessory
			{
				AccessoryId = 7,
				Name = "SideAirbags"
			};
			accessories.Add(seventhAccessory);

			Accessory eighthAccessory = new Accessory
			{
				AccessoryId = 8,
				Name = "Ebd"
			};
			accessories.Add(eighthAccessory);

			Accessory ninthAccessory = new Accessory
			{
				AccessoryId = 9,
				Name = "Esp"
			};
			accessories.Add(ninthAccessory);

			Accessory tenthAccessory = new Accessory
			{
				AccessoryId = 10,
				Name = "Tpms"
			};
			accessories.Add(tenthAccessory);

			Accessory eleventhAccessory = new Accessory
			{
				AccessoryId = 11,
				Name = "Parktronic"
			};
			accessories.Add(eleventhAccessory);

			Accessory twelfthAccessory = new Accessory
			{
				AccessoryId = 12,
				Name = "Isofix"
			};
			accessories.Add(twelfthAccessory);

			Accessory thirteenthAccessory = new Accessory
			{
				AccessoryId = 13,
				Name = "DynamicStabilityControl"
			};
			accessories.Add(thirteenthAccessory);

			Accessory fourteenthAccessory = new Accessory
			{
				AccessoryId = 14,
				Name = "Tcs"
			};
			accessories.Add(fourteenthAccessory);

			Accessory fifteenthAccessory = new Accessory
			{
				AccessoryId = 15,
				Name = "DistanceControlSystem"
			};
			accessories.Add(fifteenthAccessory);

			Accessory sixteenthAccessory = new Accessory
			{
				AccessoryId = 16,
				Name = "DescentControlSystem"
			};
			accessories.Add(sixteenthAccessory);

			Accessory seventeenthAccessory = new Accessory
			{
				AccessoryId = 17,
				Name = "Bas"
			};
			accessories.Add(seventeenthAccessory);

			Accessory eighteenthAccessory = new Accessory
			{
				AccessoryId = 18,
				Name = "AutoStartStopFunction"
			};
			accessories.Add(eighteenthAccessory);

			Accessory nineteenthAccessory = new Accessory
			{
				AccessoryId = 19,
				Name = "BluetoothHandsfreeSystem"
			};
			accessories.Add(nineteenthAccessory);

			Accessory twentiethAccessory = new Accessory
			{
				AccessoryId = 20,
				Name = "DvdTv"
			};
			accessories.Add(twentiethAccessory);

			Accessory twentyFirstAccessory = new Accessory
			{
				AccessoryId = 21,
				Name = "SteptronicTiptronic"
			};
			accessories.Add(twentyFirstAccessory);

			Accessory twentySecondAccessory = new Accessory
			{
				AccessoryId = 22,
				Name = "UsbAudioVideoInAuxOutputs"
			};
			accessories.Add(twentySecondAccessory);

			Accessory twentyThirdAccessory = new Accessory
			{
				AccessoryId = 23,
				Name = "AdaptiveAirSuspension"
			};
			accessories.Add(twentyThirdAccessory);

			Accessory twentyFourthAccessory = new Accessory
			{
				AccessoryId = 24,
				Name = "KeylessIgnition"
			};
			accessories.Add(twentyFourthAccessory);

			Accessory twentyFifthAccessory = new Accessory
			{
				AccessoryId = 25,
				Name = "DifferentialLock"
			};
			accessories.Add(twentyFifthAccessory);

			Accessory twentySixthAccessory = new Accessory
			{
				AccessoryId = 26,
				Name = "OnBoardComputer"
			};
			accessories.Add(twentySixthAccessory);

			Accessory twentySeventhAccessory = new Accessory
			{
				AccessoryId = 27,
				Name = "LightSensor"
			};
			accessories.Add(twentySeventhAccessory);

			Accessory twentyEighthAccessory = new Accessory
			{
				AccessoryId = 28,
				Name = "ElectricMirrors"
			};
			accessories.Add(twentyEighthAccessory);

			Accessory twentyNinthAccessory = new Accessory
			{
				AccessoryId = 29,
				Name = "ElectricGlass"
			};
			accessories.Add(twentyNinthAccessory);

			Accessory thirtiethAccessory = new Accessory
			{
				AccessoryId = 30,
				Name = "ElectricSuspensionAdjustment"
			};
			accessories.Add(thirtiethAccessory);

			Accessory thirtyFirstAccessory = new Accessory
			{
				AccessoryId = 31,
				Name = "ElectricSeatAdjustment"
			};
			accessories.Add(thirtyFirstAccessory);

			Accessory thirtySecondAccessory = new Accessory
			{
				AccessoryId = 32,
				Name = "ElectricPowerSteering"
			};
			accessories.Add(thirtySecondAccessory);

			Accessory thirtyThirdAccessory = new Accessory
			{
				AccessoryId = 33,
				Name = "AirConditioner"
			};
			accessories.Add(thirtyThirdAccessory);

			Accessory thirtyFourthAccessory = new Accessory
			{
				AccessoryId = 34,
				Name = "Climatronic"
			};
			accessories.Add(thirtyFourthAccessory);

			Accessory thirtyFifthAccessory = new Accessory
			{
				AccessoryId = 35,
				Name = "MultifunctionSteeringWheel"
			};
			accessories.Add(thirtyFifthAccessory);

			Accessory thirtySixthAccessory = new Accessory
			{
				AccessoryId = 36,
				Name = "NavigationSystem"
			};
			accessories.Add(thirtySixthAccessory);

			Accessory thirtySeventhAccessory = new Accessory
			{
				AccessoryId = 37,
				Name = "SteeringWheelHeating"
			};
			accessories.Add(thirtySeventhAccessory);

			Accessory thirtyEighthAccessory = new Accessory
			{
				AccessoryId = 38,
				Name = "WindshieldHeating"
			};
			accessories.Add(thirtyEighthAccessory);

			Accessory thirtyNinthAccessory = new Accessory
			{
				AccessoryId = 39,
				Name = "SeatHeating"
			};
			accessories.Add(thirtyNinthAccessory);

			Accessory fortiethAccessory = new Accessory
			{
				AccessoryId = 40,
				Name = "SteeringWheelAdjustment"
			};
			accessories.Add(fortiethAccessory);

			Accessory fortyFirstAccessory = new Accessory
			{
				AccessoryId = 41,
				Name = "RainSensor"
			};
			accessories.Add(fortyFirstAccessory);

			Accessory fortySecondAccessory = new Accessory
			{
				AccessoryId = 42,
				Name = "PowerSteering"
			};
			accessories.Add(fortySecondAccessory);

			Accessory fortyThirdAccessory = new Accessory
			{
				AccessoryId = 43,
				Name = "HeadlampWashSystem"
			};
			accessories.Add(fortyThirdAccessory);

			Accessory fortyFourthAccessory = new Accessory
			{
				AccessoryId = 44,
				Name = "CruiseControlSystem"
			};
			accessories.Add(fortyFourthAccessory);

			Accessory fortyFifthAccessory = new Accessory
			{
				AccessoryId = 45,
				Name = "StereoSystem"
			};
			accessories.Add(fortyFifthAccessory);

			Accessory fortySixthAccessory = new Accessory
			{
				AccessoryId = 46,
				Name = "CoolingGlovebox"
			};
			accessories.Add(fortySixthAccessory);
			
			return accessories;
		}
	}
}
