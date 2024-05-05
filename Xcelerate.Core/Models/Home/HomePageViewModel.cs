namespace Xcelerate.Core.Models.Home
{
	using Xcelerate.Core.Models.Pager;
	public class HomePageViewModel
	{
		public Pager Pager { get; set; }
		public int CurrentPage { get; set; }
		public DataStatisticsViewModel DataStatistics { get; set; }
		public IEnumerable<NewsPreviewViewModel> NewsPreview { get; set; } = new List<NewsPreviewViewModel>();
		public int UnreadMessageCount { get; set; }

	}
}
