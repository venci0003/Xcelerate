using Xcelerate.Core.Models.Home;

namespace Xcelerate.Core.Contracts
{
	public interface IHomeService
	{
		public Task<int> GetNewsCountAsync();
		public Task<HomePageViewModel> GetHomePageDataAsync(HomePageViewModel homePageView);
	}
}
