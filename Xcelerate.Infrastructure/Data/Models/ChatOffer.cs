using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class ChatOffer
	{
		[Key]
		public int ChatOfferId { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public DateTime SentAt { get; set; }

		[ForeignKey("Sender")]
		public Guid SenderId { get; set; }
		public User Sender { get; set; }

		[ForeignKey("Session")]
		public Guid SessionId { get; set; }
		public ChatSession Session { get; set; }
	}
}
