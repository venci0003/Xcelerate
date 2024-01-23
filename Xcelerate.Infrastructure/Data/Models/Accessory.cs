using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Accessory
	{
		[Key]
		public int AccessoryId { get; set; }

        [Required]
		[ForeignKey(nameof(Car))]
		public int CarId { get; set; }
		public Car Car { get; set; } = null!;

		// Safety
		public bool GpsTrackingSystem { get; set; }
		public bool AutomaticStabilityControl { get; set; }
		public bool AdaptiveHeadlights { get; set; }
		public bool Abs { get; set; }
		public bool RearAirbags { get; set; }
		public bool FrontAirbags { get; set; }
		public bool SideAirbags { get; set; }
		public bool Ebd { get; set; }
		public bool Esp { get; set; }
		public bool Tpms { get; set; }
		public bool Parktronic { get; set; }
		public bool Isofix { get; set; }
		public bool DynamicStabilityControl { get; set; }
		public bool Tcs { get; set; }
		public bool DistanceControlSystem { get; set; }
		public bool DescentControlSystem { get; set; }
		public bool Bas { get; set; }

		// Comfort
		public bool AutoStartStopFunction { get; set; }
		public bool BluetoothHandsfreeSystem { get; set; }
		public bool DvdTv { get; set; }
		public bool SteptronicTiptronic { get; set; }
		public bool UsbAudioVideoInAuxOutputs { get; set; }
		public bool AdaptiveAirSuspension { get; set; }
		public bool KeylessIgnition { get; set; }
		public bool DifferentialLock { get; set; }
		public bool OnBoardComputer { get; set; }
		public bool LightSensor { get; set; }
		public bool ElectricMirrors { get; set; }
		public bool ElectricGlass { get; set; }
		public bool ElectricSuspensionAdjustment { get; set; }
		public bool ElectricSeatAdjustment { get; set; }
		public bool ElectricPowerSteering { get; set; }
		public bool AirConditioner { get; set; }
		public bool Climatronic { get; set; }
		public bool MultifunctionSteeringWheel { get; set; }
		public bool NavigationSystem { get; set; }
		public bool SteeringWheelHeating { get; set; }
		public bool WindshieldHeating { get; set; }
		public bool SeatHeating { get; set; }
		public bool SteeringWheelAdjustment { get; set; }
		public bool RainSensor { get; set; }
		public bool PowerSteering { get; set; }
		public bool HeadlampWashSystem { get; set; }
		public bool CruiseControlSystem { get; set; }
		public bool StereoSystem { get; set; }
		public bool CoolingGlovebox { get; set; }
	}
}
