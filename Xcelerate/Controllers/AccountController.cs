using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xcelerate.Core.Models.Account;
using Xcelerate.Core.Models.Account.UserProfile;
using Xcelerate.Extension;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpPost]
		[AllowAnonymous]
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
				return RedirectToAction(nameof(Login));
			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
			return RedirectToAction(nameof(Login));
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string returnUrl = "")
		{
			return View(new LoginViewModel() { ReturnUrl = returnUrl });
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			var user = await userManager.FindByEmailAsync(loginViewModel.Email);
			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false);
					if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl) && Url.IsLocalUrl(loginViewModel.ReturnUrl))
					{
                        return Redirect(loginViewModel.ReturnUrl);
                    }
					return RedirectToAction("HomePage","Home");
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

			// Check if the user ID is not null
			if (userId != null)
			{
				// Retrieve the user by ID
				var user = await userManager.FindByIdAsync(userId.ToString());

				// Check if the user is not null
				if (user != null)
				{
					// Create a UserProfileViewModel and set the properties
					var userProfileModel = new UserProfileViewModel
					{
						FirstName = user.FirstName,
						LastName = user.LastName,
						Email = user.Email
						// Set other properties as needed
					};

					// Pass the UserProfileViewModel to the view
					return View("UserProfile/Profile", userProfileModel);
				}
			}

			// Handle the case when the user ID is not found or the user is not found
			return NotFound();
		}
	}
}
