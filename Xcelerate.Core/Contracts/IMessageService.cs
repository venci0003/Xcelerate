using Xcelerate.Core.Models.Account.UserProfile;

namespace Xcelerate.Core.Contracts
{
	public interface IMessageService
	{
		public Task<List<MessageViewModel>> GetMessagesAsync(string userId);
	}
}
