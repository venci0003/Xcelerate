namespace Xcelerate.Common
{
	public class ApplicationConstants
	{
		//Default page size for car pages.
		public const int DefaultPageSizeForAds = 6;

		//Default page size for news pages.
		public const int DefaultPageSizeForNews = 3;


		//Admin naming constants.
		public const string AdminRoleName = "Administrator";

		public const string AdminAreaName = "Admin";


		//For admin news in admin index page.
		public const string AdminNewsCacheKey = "AdminNewsCacheKey";

		public const int AdminNewsExpirationFromMinutes = 10;

		public const string AdminReviewsCacheKey = "AdminReviewsCacheKey";

		public const int AdminReviewsExpirationFromMinutes = 10;

		//For car ad information in information page.
		public const string CarAdInformationCacheKey = "CarAdInformationCacheKey";

		public const int CarAdInformationExpirationToMinutes = 3;

		//For car accessories in information page.
		public const string CarAccessoriesCacheKey = "CarAccessoriesCacheKey";

		public const int CarAccessoriesExpirationToMinutes = 3;

		//For car reviews in information page.
		public const string CarReviewsCacheKey = "CarReviewsCacheKey";

		public const int CarReviewsExpirationToMinutes = 15;
	}
}
