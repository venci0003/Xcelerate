namespace Xcelerate.Common
{
	public class NotificationMessages
	{
		public static class UserMessages
		{
			//Create messages
			public const string SuccesfulCreateTitle = "Succesfully added new ad!";

			public const string SuccesfulCreateContent = "Car added: {0} - {1} {2}";

			//Edit messages
			public const string SuccesfulEditTitle = "Succesfully edited car ad!";

			public const string SuccesfulEditContent = "Car edited: {0} - {1} {2}";

			//Delete messages
			public const string SuccesfulDeleteTitle = "Succesfully deleted car ad!";

			public const string SuccesfulDeleteContent = "Car deleted: {0} - {1} {2}";

			//Sold messages
			public const string SuccesfulSoldTitle = "Car Sold Successfully!";

			public const string SuccesfulSoldContent = "Car sold: {0} - {1} {2} to {3} {4} for {5}$";

			//Bought messages
			public const string SuccesfulBoughtTitle = "Congratulations on Your New Car Purchase!";

			public const string SuccesfulBoughtContent = "Car bought: {0} - {1} {2} from {3} {4} for {5}$";

			public const string NewMessageTitle = "New Message";
		};

		public static class AlertMessages
		{
			//Create alert message constants
			public const string AdCreatedSuccesfullyTempData = "AdCreatedSuccesfully";

			public const string AdCreatedSuccesfullyMessage = "You have succesfully created an ad!";

			//Delete alert message constants
			public const string AdDeletedSuccesfullyTempData = "DeleteMessage";

			public const string AdDeletedSuccesfullyMessage = "Ad deleted successfully.";

			//Delete all messages alert message constants
			public const string DeleteAllUserMessagesSuccesfullyTempData = "DeleteAllMessages";

			public const string DeleteAllUserMessagesSuccesfullyMessage = "All messages deleted successfully.";

			//Ad compare alert message constants
			public const string AdCompareErrorTempData = "CompareError";

			public const string AdCompareErrorMessage = "Cannot compare the same car.";

			//Approve news alert message constants
			public const string NewsApproveErrorTempData = "ErrorMessage";

			public const string NewsApproveErrorMessage = "Title or content is missing.";


			//Delete admin reviews alert message constants
			public const string DeleteAdminReviewTempData = "DeleteMessageForAdmin";

			public const string DeleteAdminReviewMessage = "Review deleted successfully.";
		}

		public static class TitleColors
		{
			public const string EditTitleColor = "cdcdef";

			public const string CreateTitleColor = "rgba(162, 235, 186, 1.0)";

			public const string DeleteTitleColor = "#eb4141";

			public const string SoldTitleColor = "rgba(162, 235, 186, 1.0)";

			public const string BoughtTitleColor = "rgba(162, 235, 186, 1.0)";

			public const string NewMessageTitleColor = "rgba(120, 230, 150, 1.0)";

			public const string DefaultTitleColor = "black";
		}
	}
}
