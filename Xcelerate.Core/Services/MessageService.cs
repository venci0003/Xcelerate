using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Account.UserProfile;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Services
{
	using IMessageService = Contracts.IMessageService;
	public class MessageService : IMessageService
	{
		private readonly Infrastructure.Data.IMessageService _dbContext;

		public MessageService(Infrastructure.Data.IMessageService context)
		{
			_dbContext = context;
		}
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
