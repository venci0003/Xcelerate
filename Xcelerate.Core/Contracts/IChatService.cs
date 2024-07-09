namespace Xcelerate.Core.Contracts
{
	public interface IChatService
	{
		public Task<Guid> CreateChatSession(Guid buyerId, Guid sellerId,int adId);

		public Task<bool> IsValidSellerId(string sellerId, string otherUserId);

	}
}
