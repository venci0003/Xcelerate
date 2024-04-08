using Microsoft.EntityFrameworkCore;
using Xcelerate.Areas.Admin.Contracts;
using Xcelerate.Areas.Admin.Models;
using Xcelerate.Core.Models.Home;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Areas.Admin.Models.NewsGenerator;

namespace Xcelerate.Areas.Admin.Services
{
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

			var news = await _dbContext.NewsData
				.Skip((homePageView.CurrentPage - 1) * pageSize)
				.Take(pageSize)
				.Select(n => new NewsPreviewViewModel
				{
					NewsId = n.NewsId,
					Title = n.Title,
					Content = n.Content
				})
				.ToListAsync();

			// Create an instance of HomePageViewModel
			var viewModel = new AdminHomeViewModel
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

		public async Task<GeneratedNewsViewModel> GenerateNewsAsync()
		{
			// Create an instance of CarNewsGenerator
			var carNewsGenerator = new CarNewsGenerator();

			// Generate car news asynchronously
			var (title, content) = await carNewsGenerator.GenerateCarNewsAsync();

			var generatedNews = new GeneratedNewsViewModel
			{
				Title = title,
				Content = content
			};

			// Return the generated news
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
