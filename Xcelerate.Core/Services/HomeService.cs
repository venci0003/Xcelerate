using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Home;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

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
			DataStatisticsViewModel? statistics = await _dbContext.StatisticalData.Select(s => new DataStatisticsViewModel
			{
				SoldCars = s.SoldCars,
				CreatedCars = s.CreatedCars,
				CreatedReviews = s.CreatedReviews
			}).FirstOrDefaultAsync();

			return statistics;
		}

		public async Task<IEnumerable<NewsPreviewViewModel>> GetNewsAsync(NewsPreviewViewModel newsPreviewViewModel)
		{
			List<NewsPreviewViewModel> news = await _dbContext.NewsData.AsNoTracking().Select(n => new NewsPreviewViewModel
			{
				Title = newsPreviewViewModel.Title,
				Content = newsPreviewViewModel.Content,
			}).ToListAsync();

			return news;
		}

		public async Task<HomePageViewModel> GetHomePageDataAsync(HomePageViewModel homePageView)
		{
			// Get data statistics
			var statistics = await _dbContext.StatisticalData
				.Select(s => new DataStatisticsViewModel
				{
					SoldCars = s.SoldCars,
					CreatedCars = s.CreatedCars,
					CreatedReviews = s.CreatedReviews
				})
				.FirstOrDefaultAsync();

			int pageSize = 3; // Number of news items per page

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
			var viewModel = new HomePageViewModel
			{
				DataStatistics = statistics,
				NewsPreview = news,
			};

			return viewModel;
		}

		public Task<int> GetNewsCountAsync()
		{
			IQueryable<News> news = _dbContext.NewsData.AsQueryable();

			return news.CountAsync();
		}
	}
}
