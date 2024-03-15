using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Core.Models.Pager
{
	public class Pager
	{
		public Pager(int totalItems, int currentPage)
		{
			Configure(totalItems, currentPage);
		}

		private void Configure(int totalItems, int currentPage)
		{
			int totalPages = (int)Math.Ceiling((decimal)totalItems / DefaultPageSize);
			int startPage = Math.Max(1, currentPage - 3);
			int endPage = Math.Min(startPage + 4, totalPages);

			if (currentPage > endPage && endPage != 0)
			{
				currentPage = endPage;
				startPage = Math.Max(1, currentPage - 3);
				endPage = Math.Min(startPage + 3, totalPages);
			}

			TotalPages = totalPages;
			CurrentPage = currentPage;
			PageSize = DefaultPageSize;
			StartPage = startPage;
			EndPage = endPage;
			TotalItems = totalItems;
		}

		public int TotalItems { get; private set; }

		public int CurrentPage { get; private set; }

		public int PageSize { get; private set; }

		public int TotalPages { get; private set; }

		public int StartPage { get; private set; }

		public int EndPage { get; private set; }
	}
}
