using Xcelerate.Core.Models.Home;

namespace Xcelerate.Core.Contracts
{
	public interface IHomeService
	{
		public Task<DataStatisticsViewModel> GetDataStatisticsAsync(DataStatisticsViewModel dataStatisticsViewModel);
	}
}
