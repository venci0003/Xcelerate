namespace Xcelerate.Core.Models.Account.UserProfile
{
	public class MessageViewModel
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string TitleColor { get; set; }

		public string CreatedTime { get; set; }

        public bool IsMessageViewed { get; set; }
	}
}
