using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class StatisticalData
	{
		[Key]
		public int StatisticId { get; set; }
		public int SoldCars { get; set; }
		public int CreatedCars { get; set; }
		public int CreatedReviews { get; set; }
	}
}
