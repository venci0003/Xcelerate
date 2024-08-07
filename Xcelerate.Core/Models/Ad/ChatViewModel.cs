using static Xcelerate.Common.EntityValidation;
using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Core.Models.Ad
{
	public class ChatViewModel
	{
		public Guid ChatSessionId { get; set; }

		public Guid CurrentUserId { get; set; }

		public int CarId { get; set; }

		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }

		[Required(ErrorMessage = "A message is required")]
		[StringLength(500, ErrorMessage = "Message must be between {2} and {1} characters long.", MinimumLength = 1)]
		public string MessageInput { get; set; } = string.Empty;

		[Required(ErrorMessage = "Offer is required.")]
		[Range(500, int.MaxValue, ErrorMessage = "Price offer must be at least $500.")]
		public int Offer { get; set; }
	}
}
