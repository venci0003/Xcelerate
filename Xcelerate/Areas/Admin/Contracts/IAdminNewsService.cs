using Xcelerate.Areas.Admin.Models;

namespace Xcelerate.Areas.Admin.Contracts
{
	public interface IAdminNewsService
	{
		public Task<int> GetNewsCountAsync();
		public Task<AdminHomeViewModel> GetHomePageDataAsync(AdminHomeViewModel adminHomeViewModel);
		public Task<GeneratedNewsViewModel> GenerateNewsAsync();
		public Task ApproveNewsAsync(GeneratedNewsViewModel generatedNewsView);
	}
}
