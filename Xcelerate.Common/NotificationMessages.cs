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
		};
	}
}
