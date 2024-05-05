using System.ComponentModel.DataAnnotations;
using static Xcelerate.Common.EntityValidation.UserEntity;

namespace Xcelerate.Core.Models.Account.UserProfile
{
	public class UserProfileViewModel
	{
		[MaxLength(FirstNameMaxLength)]
		[MinLength(FirstNameMinLength)]
		public string FirstName { get; set; } = null!;

		[MaxLength(LastNameMaxLength)]
		[MinLength(LastNameMinLength)]
		public string LastName { get; set; } = null!;

		[MaxLength(EmailAddressMaxValue)]
		[MinLength(EmailAddressMinValue)]
		public string Email { get; set; } = null!;

		public List<MessageViewModel> Messages { get; set; } = new List<MessageViewModel>();

		public int UnreadMessageCount { get; set; }
	}
}
