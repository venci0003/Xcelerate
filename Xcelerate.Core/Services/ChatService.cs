using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Contracts;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Services
{
	public class ChatService : IChatService
	{
		private readonly XcelerateContext _dbContext;

		public ChatService(XcelerateContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> IsValidSellerId(string currentUserId, string otherUserId)
		{
			return await _dbContext.ChatSessions.AnyAsync(cs => cs.SellerId.ToString() == currentUserId && cs.BuyerId.ToString() == otherUserId);
		}



		public async Task<Guid> CreateChatSession(Guid currentUserId, Guid otherUserId, int adId)
		{
			var existingSession = await _dbContext.ChatSessions
				.FirstOrDefaultAsync(cs => cs.AdId == adId &&
										   ((cs.BuyerId == currentUserId && cs.SellerId == otherUserId) ||
											(cs.BuyerId == otherUserId && cs.SellerId == currentUserId)));

			if (existingSession != null)
			{
				return existingSession.ChatSessionId;
			}
			else
			{
				var ad = await _dbContext.Ads.FindAsync(adId);
				if (ad == null)
				{
					throw new InvalidOperationException("Ad not found.");
				}

				Guid buyerId, sellerId;
				if (ad.UserId == currentUserId)
				{
					sellerId = currentUserId;
					buyerId = otherUserId;
				}
				else
				{
					sellerId = ad.UserId;
					buyerId = currentUserId;
				}

				var chatSession = new ChatSession
				{
					BuyerId = buyerId,
					SellerId = sellerId,
					AdId = adId
				};

				await _dbContext.ChatSessions.AddAsync(chatSession);
				await _dbContext.SaveChangesAsync();

				return chatSession.ChatSessionId;
			}
		}

	}
}
