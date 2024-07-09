using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class User : IdentityUser<Guid>
	{

		[Required]
		[Comment("FirstName")]
		public string FirstName { get; set; } = null!;

		[Required]
		[Comment("LastName")]
		public string LastName { get; set; } = null!;

		[Required]
		[Comment("User's balance (fake money)")]
		public decimal Balance { get; set; } = 0;

		public ICollection<Ad> Ads { get; set; } = new List<Ad>();

		public ICollection<Review> Reviews { get; set; } = new List<Review>();

		public ICollection<Car> Cars { get; set; } = new List<Car>();

		public ICollection<Message> Messages { get; set; } = new List<Message>();

		public ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

		// Navigation property for the chat session where the user is either the buyer or the seller
		public ICollection<ChatSession> ChatSessions { get; set; } = new List<ChatSession>();
	}
}
