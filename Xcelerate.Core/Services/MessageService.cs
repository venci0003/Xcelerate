namespace Xcelerate.Core.Services
{
	using Microsoft.EntityFrameworkCore;
	using Contracts;
	using Models.Account.UserProfile;
	using Xcelerate.Infrastructure.Data;

	public class MessageService : IMessageService
	{
		private readonly XcelerateContext _dbContext;

		public MessageService(XcelerateContext context)
		{
			_dbContext = context;
		}//i
		public async Task<List<MessageViewModel>> GetMessagesAsync(string userId)
		{
			List<MessageViewModel> messages = await _dbContext.Messages
				.AsNoTracking()
				.Where(m => m.UserId == Guid.Parse(userId))
				.Select(m => new MessageViewModel()
				{
					Title = m.Title,
					Content = m.Content,
				}).ToListAsync();

			return messages;
		}
	}
}
