using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class Message
	{
		public int MessageId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
		public DateTime CreatedTime { get; set; }
        public bool IsMessageViewed { get; set; }
    }
}
