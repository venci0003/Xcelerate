using System.ComponentModel.DataAnnotations;
using static Xcelerate.Common.EntityValidation.UserEntity;

namespace Xcelerate.Core.Models.Account
{
    public class RegisterViewModel
    {
		[Required(ErrorMessage = "First name is required.")]
		[StringLength(FirstNameMaxLength, ErrorMessage = "First name must be between {2} and {1} characters.", MinimumLength = FirstNameMinLength)]
		public string FirstName { get; set; } = null!;

		[Required(ErrorMessage = "Last name is required.")]
		[StringLength(LastNameMaxLength, ErrorMessage = "Last name must be between {2} and {1} characters.", MinimumLength = LastNameMinLength)]
		public string LastName { get; set; } = null!;

		[Required(ErrorMessage = "Email address is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		[StringLength(EmailAddressMaxValue, ErrorMessage = "Email address must be between {2} and {1} characters.", MinimumLength = EmailAddressMinValue)]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = "Password is required.")]
		[StringLength(PasswordMaxLength, ErrorMessage = "Password must be between {2} and {1} characters.", MinimumLength = PasswordMinLength)]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Required(ErrorMessage = "Please confirm your password.")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
		public string ConfirmPassword { get; set; } = null!;


	}
}
