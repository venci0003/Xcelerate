namespace Xcelerate.Areas.Admin.Services
{
	using Microsoft.EntityFrameworkCore;
	using Contracts;
	using Models;
	using Core.Models.Home;
	using Infrastructure.Data;
	using Infrastructure.Data.Models;
	using static Models.NewsGenerator;
	public class AdminNewsService : IAdminNewsService
	{
		private readonly XcelerateContext _dbContext;

		public AdminNewsService(XcelerateContext context)
		{
			_dbContext = context;
		}
		public async Task<AdminHomeViewModel> GetHomePageDataAsync(AdminHomeViewModel homePageView)
		{
			int pageSize = 3;

			List<NewsPreviewViewModel> news = await _dbContext.NewsData
			   .OrderByDescending(n => n.NewsId)
			   .Skip((homePageView.CurrentPage - 1) * pageSize)
			   .Take(pageSize)
			   .Select(n => new NewsPreviewViewModel
			   {
				   NewsId = n.NewsId,
				   Title = n.Title,
				   Content = n.Content
			   })
			   .ToListAsync();

			AdminHomeViewModel viewModel = new AdminHomeViewModel
			{
				NewsPreview = news,
			};

			return viewModel;
		}

		public Task<int> GetNewsCountAsync()
		{
			IQueryable<News> news = _dbContext.NewsData.AsQueryable();

			return news.CountAsync();
		}

		public GeneratedNewsViewModel GenerateNews()
		{
			CarNewsGenerator carNewsGenerator = new CarNewsGenerator();

			(string title, string content) = carNewsGenerator.GenerateCarNewsAsync();

			GeneratedNewsViewModel generatedNews = new GeneratedNewsViewModel
			{
				Title = title,
				Content = content
			};

			return generatedNews;
		}

		public async Task ApproveNewsAsync(GeneratedNewsViewModel generatedNewsView)
		{
			News approvedNews = new News
			{
				Title = generatedNewsView.Title,
				Content = generatedNewsView.Content
			};

			await _dbContext.NewsData.AddAsync(approvedNews);
			await _dbContext.SaveChangesAsync();
		}
	}
}
