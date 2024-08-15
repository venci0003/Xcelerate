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

		public async Task<List<ChatMessageViewModel>> GetChatMessagesAsync(string userId)
		{
			var userIdGuid = Guid.Parse(userId);

			var chatMessagesFromDb = await _dbContext.ChatMessages
				.Include(m => m.Sender)
				.Include(m => m.Session)
					.ThenInclude(s => s.Ad)
					.ThenInclude(a => a.Car)
				.Where(m => m.Session.BuyerId == userIdGuid || m.Session.SellerId == userIdGuid)
				.OrderByDescending(m => m.SentAt)
				.ToListAsync();

			var latestMessages = chatMessagesFromDb
				.Where(m => m.SenderId != userIdGuid)
				.GroupBy(m => m.SessionId)
				.Select(g => g.OrderByDescending(m => m.SentAt).First())
				.OrderByDescending(m => m.SentAt)
				.ToList();

			var chatMessages = latestMessages.Select(chatMessage => new ChatMessageViewModel
			{
				Title = $"{chatMessage.Session.Ad.Car.Brand} {chatMessage.Session.Ad.Car.Model}",
				Content = $"{chatMessage.Sender.FirstName} {chatMessage.Sender.LastName}. Click <a href='/StartChat?otherUserId={chatMessage.Sender.Id}&adId={chatMessage.Session.Ad.AdId}&carId={chatMessage.Session.Ad.CarId}'>here</a> to join the chat.",
				CreatedTime = chatMessage.SentAt.ToString("g"),
				SenderName = $"{chatMessage.Sender.FirstName} {chatMessage.Sender.LastName}"
			}).ToList();

			return chatMessages;
		}

		public async Task<List<MessageViewModel>> GetMessagesAsync(string userId)
		{
			var messagesFromDb = await _dbContext.Messages
					.AsNoTracking()
					.Where(m => m.UserId == Guid.Parse(userId))
					.OrderByDescending(m => m.MessageId)
					.ToListAsync();

			var messages = messagesFromDb
				.Select(m => new MessageViewModel()
				{
					Title = m.Title,
					Content = m.Content,
					CreatedTime = GetFormattedTimestamp(m.CreatedTime),
					TitleColor = GetTitleColor(m.Title),
					IsMessageViewed = m.IsMessageViewed

				}).ToList();

			return messages;
		}

		public async Task MarkMessagesAsViewedAsync(string userId)
		{
			var messagesToUpdate = await _dbContext.Messages
				.Where(m => m.UserId == Guid.Parse(userId) && !m.IsMessageViewed)
				.ToListAsync();

			foreach (var message in messagesToUpdate)
			{
				message.IsMessageViewed = true;
				_dbContext.Messages.Update(message);
			}

			await _dbContext.SaveChangesAsync();
		}

		public async Task<int> GetUnreadMessageCountAsync(string userId)
		{
			return await _dbContext.Messages
				.CountAsync(m => m.UserId == Guid.Parse(userId) && !m.IsMessageViewed);
		}

		public async Task DeleteAllMessages(Guid userId)
		{
			var allUserMessages = _dbContext.Messages.Where(u => u.UserId == userId);

			if (allUserMessages.Any())
			{
				_dbContext.Messages.RemoveRange(allUserMessages);
				await _dbContext.SaveChangesAsync();
			}
		}

		private string GetFormattedTimestamp(DateTime createdTime)
		{
			DateTime localTime = createdTime.ToLocalTime();

			TimeSpan timeSinceCreation = DateTime.UtcNow - createdTime;

			if (timeSinceCreation.TotalMinutes < 1)
			{
				return "just now";
			}
			else if (timeSinceCreation.TotalMinutes < 60)
			{
				return $"{(int)timeSinceCreation.TotalMinutes} minute{(timeSinceCreation.TotalMinutes > 1 ? "s" : "")} ago";
			}
			else if (timeSinceCreation.TotalHours < 24)
			{
				return $"{(int)timeSinceCreation.TotalHours} hour{(timeSinceCreation.TotalHours > 1 ? "s" : "")} {(int)timeSinceCreation.TotalMinutes % 60} minute{(timeSinceCreation.TotalMinutes % 60 > 1 ? "s" : "")} ago";
			}
			else
			{
				return localTime.ToString("MM dd HH:mm");
			}
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
			else if (title.Equals(NotificationMessages.UserMessages.SuccesfulSoldTitle, StringComparison.OrdinalIgnoreCase))
			{
				return "rgba(162, 235, 186, 1.0)";
			}
			else if (title.Equals(NotificationMessages.UserMessages.SuccesfulBoughtTitle, StringComparison.OrdinalIgnoreCase))
			{
				return "rgba(162, 235, 186, 1.0)";
			}
			else if (title.Equals(NotificationMessages.UserMessages.NewMessageTitle, StringComparison.OrdinalIgnoreCase))
			{
				return "rgba(120, 230, 150, 1.0)";
			}
			else
			{
				return "black";
			}
		}
	}
}
