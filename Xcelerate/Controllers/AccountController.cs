using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xcelerate.Core.Models.Account;
using Xcelerate.Core.Models.Account.UserProfile;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
				return RedirectToAction(nameof(Login));
			}

			var user = new User()
			{
				UserName = registerViewModel.Email,
				FirstName = registerViewModel.FirstName,
				LastName = registerViewModel.LastName,
				Email = registerViewModel.Email,
			};
			var result = await userManager.CreateAsync(user, registerViewModel.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, "User");

				return RedirectToAction(nameof(Login));
			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
			return RedirectToAction(nameof(Login));
		}

		[HttpGet]
		public IActionResult Login(string returnUrl = "")
		{
			return View(new LoginViewModel() { ReturnUrl = returnUrl });
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
				return RedirectToAction(nameof(Login));
			}

			var user = await userManager.FindByEmailAsync(loginViewModel.Email);
			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false);

					bool isAdmin = await userManager.IsInRoleAsync(user, "Administrator");

					// Redirect to admin area if the user is admin
					if (isAdmin)
					{
						return RedirectToAction("Index", "Home", new { area = "Admin" });
					}

					if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl) && Url.IsLocalUrl(loginViewModel.ReturnUrl))
					{
						return Redirect(loginViewModel.ReturnUrl);
					}
					return RedirectToAction("HomePage", "Home");
				}
			}
			ModelState.AddModelError("", "Invalid email or password");
			return View(loginViewModel);
		}
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("HomePage", "Home");
		}

		public async Task<IActionResult> Profile()
		{
			var userId = User.GetUserId();

			if (userId != null)
			{
				var user = await userManager.FindByIdAsync(userId.ToString());

				if (user != null)
				{
					var userProfileModel = new UserProfileViewModel
					{
						FirstName = user.FirstName,
						LastName = user.LastName,
						Email = user.Email
					};

					return View("UserProfile/Profile", userProfileModel);
				}
			}

			return NotFound();
		}

		//[HttpPost]
		//[Authorize(Roles = AdminRoleName)]
		//public async Task<IActionResult> ChangeRole(Guid id, string? role = null)
		//{
		//	User userToFind = await userManager.FindByIdAsync(id.ToString());
		//	if (!string.IsNullOrWhiteSpace(role))
		//	{
		//		if (!await roleManager.RoleExistsAsync(role))
		//		{
		//			IdentityRole<Guid> newRole = new IdentityRole<Guid>(role);
		//			await roleManager.CreateAsync(newRole);
		//		}
		//		if (!await userManager.IsInRoleAsync(userToFind, role))
		//		{
		//			await userManager.AddToRoleAsync(userToFind, role);
		//			//To save the changes on SeedUsers
		//			await xcelerateContext.SaveChangesAsync();
		//		}
		//	}
		//	else
		//	{
		//		if (await userManager.IsInRoleAsync(userToFind, ModeratorRoleName))
		//		{
		//			await userManager.RemoveFromRoleAsync(userToFind, ModeratorRoleName);
		//			if (!await roleManager.RoleExistsAsync(UserRoleName))
		//			{
		//				IdentityRole<Guid> userRole = new IdentityRole<Guid>(UserRoleName);
		//				await roleManager.CreateAsync(userRole);
		//			}
		//			if (!await userManager.IsInRoleAsync(userToFind, UserRoleName))
		//			{
		//				await userManager.AddToRoleAsync(userToFind, UserRoleName);
		//			}
		//			//To save the changes on SeedUsers
		//			await bookingContext.SaveChangesAsync();
		//		}
		//		else
		//		{
		//			return NotFound();
		//		}
		//	}
		//	return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
		//}
	}
}
