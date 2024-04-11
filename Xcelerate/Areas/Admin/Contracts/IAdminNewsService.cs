namespace Xcelerate.Areas.Admin.Contracts
{
	using Models;
	public interface IAdminNewsService
	{
		public Task<int> GetNewsCountAsync();
		public Task<AdminHomeViewModel> GetHomePageDataAsync(AdminHomeViewModel adminHomeViewModel);
		public GeneratedNewsViewModel GenerateNews();
		public Task ApproveNewsAsync(GeneratedNewsViewModel generatedNewsView);
	}
}
