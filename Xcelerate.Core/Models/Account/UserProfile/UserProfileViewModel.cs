using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Common;
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
	}
}
