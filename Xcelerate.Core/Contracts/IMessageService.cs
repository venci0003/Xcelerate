using Xcelerate.Core.Models.Account.UserProfile;

namespace Xcelerate.Core.Contracts
{
	public interface IMessageService
	{
		public Task<List<MessageViewModel>> GetMessagesAsync(string userId);
		public Task MarkMessagesAsViewedAsync(string userId);
		public Task<int> GetUnreadMessageCountAsync(string userId);

		public Task<List<ChatMessageViewModel>> GetChatMessagesAsync(string userId);

		public Task DeleteAllMessages(Guid userId);

	}
}
