using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Home;
using Xcelerate.Infrastructure.Data;

namespace Xcelerate.Core.Services
{
	public class HomeService : IHomeService
	{
		private readonly XcelerateContext _dbContext;

		public HomeService(XcelerateContext context)
		{
			_dbContext = context;
		}
		public async Task<DataStatisticsViewModel> GetDataStatisticsAsync(DataStatisticsViewModel dataStatisticsViewModel)
		{
			var statistics = await _dbContext.StatisticalData.Select(s => new DataStatisticsViewModel
			{
				SoldCars = s.SoldCars,
				CreatedCars = s.CreatedCars,
				CreatedReviews = s.CreatedReviews
			}).FirstOrDefaultAsync();

			return statistics;
		}
	}
}
