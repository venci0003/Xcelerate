namespace Xcelerate.Common
{
	public class ApplicationConstants
	{
		//Default page size for car pages.
		public const int DefaultPageSizeForAds = 6;

		//Default page size for news pages.
		public const int DefaultPageSizeForNews = 3;

		//User naming constants
		public const string UserRoleName = "User";

		//Admin naming constants.
		public const string AdminRoleName = "Administrator";

		public const string AdminAreaName = "Admin";


		//For admin news in admin index page.
		public const string AdminNewsCacheKey = "AdminNewsCacheKey";

		public const int AdminNewsExpirationFromMinutes = 10;

		public const string AdminReviewsCacheKey = "AdminReviewsCacheKey";

		public const int AdminReviewsExpirationFromMinutes = 2;

		//For car ad information in information page.
		public const string CarAdInformationCacheKey = "CarAdInformationCacheKey";

		public const int CarAdInformationExpirationToMinutes = 3;

		//For car accessories in information page.
		public const string CarAccessoriesCacheKey = "CarAccessoriesCacheKey";

		public const int CarAccessoriesExpirationToMinutes = 3;

		//For car reviews in information page.
		public const string CarReviewsCacheKey = "CarReviewsCacheKey";

		public const int CarReviewsExpirationToMinutes = 2;

		public const string UserCarsInformationCacheKey = "UserCarsInformationCacheKey";

		public const int UserCarsInformationExpirationToMinutes = 3;

		public const string UserCarsAccessoriesCacheKey = "UserCarsAccessoriesCacheKey";

		public const int UserCarsAccessoriesExpirationToMinutes = 3;
	}
}
