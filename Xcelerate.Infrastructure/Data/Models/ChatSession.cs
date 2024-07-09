using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class ChatSession
	{
		[Key]
		public Guid ChatSessionId { get; set; }

		// Foreign key for the buyer (user)
		[ForeignKey("Buyer")]
		public Guid BuyerId { get; set; }
		public User Buyer { get; set; }

		// Foreign key for the seller (user)
		[ForeignKey("Seller")]
		public Guid SellerId { get; set; }
		public User Seller { get; set; }

		[ForeignKey("Ad")]
		public int AdId { get; set; }
		public Ad Ad { get; set; }

		// Navigation property for messages in this session
		public ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

		public ICollection<ChatOffer> ChatOffers { get; set; } = new List<ChatOffer>();

	}
}
