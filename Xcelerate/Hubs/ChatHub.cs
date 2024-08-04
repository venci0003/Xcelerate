using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Core.Models.Timestamp;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;
namespace Xcelerate.Hubs
{
	public class ChatHub : Hub
	{

		private readonly XcelerateContext _dbContext;
		private readonly Timestamp _timestamp;

		public ChatHub(XcelerateContext dbContext)
		{
			_dbContext = dbContext;
			_timestamp = new Timestamp();
		}
		public async Task JoinChat(string sessionId)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
		}

		public async Task LoadChatMessages(string sessionId)
		{
			var userId = Context.User.GetUserId();

			var chatMessages = _dbContext.ChatMessages
				.Include(cs => cs.Sender)
				.Where(m => m.SessionId == Guid.Parse(sessionId))
				.OrderBy(m => m.SentAt);

			var chatSession = await _dbContext.ChatSessions
				.Include(cs => cs.Buyer)
				.Include(cs => cs.Seller)
				.Include(cs => cs.Ad)
				.ThenInclude(cs => cs.Car)
				.SingleAsync(cs => cs.ChatSessionId == Guid.Parse(sessionId));

			Guid senderId;
			User sender;
			if (userId == chatSession.Buyer.Id)
			{
				senderId = chatSession.BuyerId;
				sender = chatSession.Buyer;
			}
			else if (userId == chatSession.Seller.Id)
			{
				senderId = chatSession.SellerId;
				sender = chatSession.Seller;
			}
			else
			{
				throw new Exception("The user is neither the buyer nor the seller of this chat session.");
			}

			//await Clients.Group(sessionId).SendAsync("ReceiveMessage", $"{sender.FirstName} {sender.LastName}", chatMessage.Content, senderId, chatSession.BuyerId, chatSession.SellerId);

			foreach (var chatMessage in chatMessages)
			{
				await Clients.User(userId.ToString()).SendAsync("ReceiveMessage", $"{chatMessage.Sender.FirstName} {chatMessage.Sender.LastName}", chatMessage.Content, chatMessage.SenderId, chatSession.BuyerId, chatSession.SellerId);
			}
		}

		public async Task LoadChatOffers(string sessionId)
		{
			var chatOffers = _dbContext.ChatOffers
				.Include(cs => cs.Sender)
				.Where(m => m.SessionId == Guid.Parse(sessionId))
				.OrderByDescending(m => m.SentAt);

			var chatSession = await _dbContext.ChatSessions
				.Where(cs => cs.ChatSessionId == Guid.Parse(sessionId))
				.Select(cs => new { cs.BuyerId, cs.SellerId, cs.Ad })
				.FirstOrDefaultAsync();

			foreach (var chatOffer in chatOffers)
			{
				await Clients.Caller.SendAsync("ReceiveOfferMessage", chatOffer.Sender.FirstName, chatOffer.Content, chatOffer.ChatOfferId, chatOffer.SenderId, chatSession.BuyerId, chatSession.SellerId);
			}
		}



		public async Task SendMessage(string sessionId, string message)
		{
			var userId = Context.User.GetUserId();

			var chatSession = await _dbContext.ChatSessions
				.Include(cs => cs.Buyer)
				.Include(cs => cs.Seller)
				.Include(cs => cs.Ad)
				.ThenInclude(cs => cs.Car)
				.SingleAsync(cs => cs.ChatSessionId == Guid.Parse(sessionId));

			Guid senderId;
			User sender;
			if (userId == chatSession.Buyer.Id)
			{
				senderId = chatSession.BuyerId;
				sender = chatSession.Buyer;
			}
			else if (userId == chatSession.Seller.Id)
			{
				senderId = chatSession.SellerId;
				sender = chatSession.Seller;
			}
			else
			{
				throw new Exception("The user is neither the buyer nor the seller of this chat session.");
			}

			var chatMessage = new ChatMessage
			{
				Content = message,
				SentAt = DateTime.UtcNow,
				SenderId = senderId,
				SessionId = chatSession.ChatSessionId
			};

			await _dbContext.ChatMessages.AddAsync(chatMessage);
			await _dbContext.SaveChangesAsync();

			await Clients.Group(sessionId).SendAsync("ReceiveMessage", $"{sender.FirstName} {sender.LastName}", message, senderId, chatSession.BuyerId, chatSession.SellerId);

			var adId = chatSession.Ad.AdId;

			var carId = chatSession.Ad.CarId;

			var existingNotification = await _dbContext.Messages
	   .AnyAsync(m => m.UserId == (userId == chatSession.Buyer.Id ? chatSession.SellerId : chatSession.BuyerId) && m.Content.Contains($"<a href='/StartChat?otherUserId={sender.Id}&adId={adId}'>here</a>"));

			if (!existingNotification)
			{
				if (userId == chatSession.Buyer.Id)
				{
					await _dbContext.AddAsync(new Message
					{
						UserId = chatSession.SellerId,
						Title = "New Message",
						Content = $"You have received a new message from {sender.FirstName} {sender.LastName}. Click <a href='/StartChat?otherUserId={sender.Id}&adId={adId}&carId={carId}'>here</a> to join the chat.",
						CreatedTime = DateTime.UtcNow,
						IsMessageViewed = false
					});
				}
				else if (userId == chatSession.Seller.Id)
				{
					await _dbContext.AddAsync(new Message
					{
						UserId = chatSession.BuyerId,
						Title = "New Message",
						Content = $"You have received a new message from {sender.FirstName} {sender.LastName}. Click <a href='/StartChat?otherUserId={sender.Id}&adId={adId}&carId={carId}'>here</a> to join the chat.",
						CreatedTime = DateTime.UtcNow,
						IsMessageViewed = false
					});
				}
			}

			await _dbContext.SaveChangesAsync();
		}

		public async Task SendOffer(string sessionId, string message)
		{
			try
			{
				var userId = Context.User.GetUserId();

				var chatSession = await _dbContext.ChatSessions
					.Include(cs => cs.Buyer)
					.Include(cs => cs.Seller)
					.Include(cs => cs.Ad)
					.SingleAsync(cs => cs.ChatSessionId == Guid.Parse(sessionId));

				Guid senderId;
				User sender;
				if (userId == chatSession.Buyer.Id)
				{
					senderId = chatSession.BuyerId;
					sender = chatSession.Buyer;
				}
				else if (userId == chatSession.Seller.Id)
				{
					senderId = chatSession.SellerId;
					sender = chatSession.Seller;
				}
				else
				{
					throw new Exception("The user is neither the buyer nor the seller of this chat session.");
				}

				var offerMessage = new ChatOffer
				{
					Content = message,
					SentAt = DateTime.UtcNow,
					SenderId = senderId,
					SessionId = chatSession.ChatSessionId
				};

				await _dbContext.ChatOffers.AddAsync(offerMessage);
				await _dbContext.SaveChangesAsync();

				var chatOffers = await _dbContext.ChatOffers
				.Include(cs => cs.Sender)
				.OrderByDescending(m => m.SentAt)
				.FirstOrDefaultAsync(m => m.SessionId == Guid.Parse(sessionId));

				//"ReceiveOfferMessage", chatOffer.Sender.FirstName, chatOffer.Content, chatOffer.ChatOfferId, chatOffer.SenderId, chatSession.BuyerId, chatSession.SellerId


				await Clients.Group(sessionId).SendAsync("ReceiveOfferMessage", $"{sender.FirstName} {sender.LastName}", message, chatOffers.ChatOfferId, chatOffers.SenderId, chatSession.BuyerId, chatSession.SellerId);

				var adId = chatSession.Ad.AdId;

				var existingNotification = await _dbContext.Messages
					.AnyAsync(m => m.UserId == (userId == chatSession.Buyer.Id ? chatSession.SellerId : chatSession.BuyerId) && m.Content.Contains($"<a href='/StartChat?otherUserId={sender.Id}&adId={adId}'>here</a>"));

				if (!existingNotification)
				{
					if (userId == chatSession.Buyer.Id)
					{
						await _dbContext.AddAsync(new Message
						{
							UserId = chatSession.SellerId,
							Title = "New Message",
							Content = $"You have received a new offer from {sender.FirstName} {sender.LastName}. Click <a href='/StartChat?otherUserId={sender.Id}&adId={adId}'>here</a> to join the chat.",
							CreatedTime = DateTime.UtcNow,
							IsMessageViewed = false
						});
					}
					else if (userId == chatSession.Seller.Id)
					{
						await _dbContext.AddAsync(new Message
						{
							UserId = chatSession.BuyerId,
							Title = "New Message",
							Content = $"You have received a new offer from {sender.FirstName} {sender.LastName}. Click <a href='/StartChat?otherUserId={sender.Id}&adId={adId}'>here</a> to join the chat.",
							CreatedTime = DateTime.UtcNow,
							IsMessageViewed = false
						});
					}
				}

				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				// Log the exception or handle it appropriately
				Console.WriteLine($"Error in SendOffer: {ex.Message}");
				throw; // Rethrow the exception to propagate it
			}
		}

		public async Task DeclineOffer(int offerId)
		{
			try
			{
				// Parse offerId to Guid

				var offer = await _dbContext.ChatOffers.FindAsync(offerId);
				if (offer != null)
				{
					var sessionId = offer.SessionId.ToString();
					_dbContext.ChatOffers.Remove(offer);
					await _dbContext.SaveChangesAsync();
					await Clients.Group(sessionId).SendAsync("OfferDeclined", offerId);
				}
				else
				{
					throw new InvalidOperationException($"Offer with ID {offerId} not found.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in DeclineOffer: {ex.Message}");
				throw; // Optionally handle or rethrow the exception
			}
		}

		public async Task AcceptOffer(string buyerId, string sellerId, decimal amount)
		{
			await Clients.User(buyerId).SendAsync("OfferAccepted", "/UserCars/Index", $"You have successfully bought the car for {amount:C}");

			await Clients.User(sellerId).SendAsync("OfferAccepted", "/Account/Profile", $"You have successfully sold the car for {amount:C}");
		}
		//ADD REDIRECT TO THE CAR THAT THE USER HAS BOUGHT FOR THE FUTURE.

	}
}
