namespace Xcelerate.Core.Services
{
	using Microsoft.EntityFrameworkCore;
	using Contracts;
	using Models.Account.UserProfile;
	using Xcelerate.Infrastructure.Data;
	using Xcelerate.Common;

	public class MessageService : IMessageService
	{
		private readonly XcelerateContext _dbContext;

		public MessageService(XcelerateContext context)
		{
			_dbContext = context;
		}
		public async Task<List<MessageViewModel>> GetMessagesAsync(string userId)
		{
			List<MessageViewModel> messages = await _dbContext.Messages
				.AsNoTracking()
				.Where(m => m.UserId == Guid.Parse(userId))
				.OrderByDescending(m => m.MessageId)
				.Select(m => new MessageViewModel()
				{
					Title = m.Title,
					Content = m.Content,
					TitleColor = GetTitleColor(m.Title)
				}).ToListAsync();

			return messages;
		}

		private static string GetTitleColor(string title)
		{
			if (title.Equals(NotificationMessages.UserMessages.SuccesfulEditTitle, StringComparison.OrdinalIgnoreCase))
			{
				return "#cdcdef";
			}
			else if (title.Equals(NotificationMessages.UserMessages.SuccesfulCreateTitle, StringComparison.OrdinalIgnoreCase))
			{
				return "rgba(162, 235, 186, 1.0)";
			}
			else if (title.Equals(NotificationMessages.UserMessages.SuccesfulDeleteTitle, StringComparison.OrdinalIgnoreCase))
			{
				return "#eb4141";
			}
			else
			{
				return "black";
			}
		}
	}
}
