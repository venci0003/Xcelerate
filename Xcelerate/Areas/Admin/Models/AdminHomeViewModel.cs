﻿namespace Xcelerate.Areas.Admin.Models
{
	using Core.Models.Home;
	using Core.Models.Pager;
	public class AdminHomeViewModel
	{
		public int AdId { get; set; }
		public int CarId { get; set; }
		public List<AdminReviewViewModel> Reviews { get; set; } = new List<AdminReviewViewModel>();

		public Pager Pager { get; set; }
		public int CurrentPage { get; set; }
		public IEnumerable<NewsPreviewViewModel> NewsPreview { get; set; } = new List<NewsPreviewViewModel>();
	}
}
