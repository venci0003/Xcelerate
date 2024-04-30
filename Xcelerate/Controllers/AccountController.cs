namespace Xcelerate.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using Core.Models.Account;
	using Core.Models.Account.UserProfile;
	using Extension;
	using Infrastructure.Data.Models;
	using static Common.ApplicationConstants;
	using System.Net;
	using Griesoft.AspNetCore.ReCaptcha;
	using Xcelerate.Core.Contracts;

	public class AccountController : Controller
	{
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly IMessageService _messageService;
		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IMessageService _messageServiceContext)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.roleManager = roleManager;
			_messageService = _messageServiceContext;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpPost]
		[ValidateRecaptcha(Action = nameof(Register),
			ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel, ValidationResponse recaptchaResponse)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
				return RedirectToAction(nameof(Login));
			}

			if (!recaptchaResponse.Success)
			{
				TempData["ErrorMessage"] = "ReCaptcha error! Try again!";
				return this.View(registerViewModel);
			}

			User user = new User()
			{
				UserName = WebUtility.HtmlEncode(registerViewModel.Email),
				FirstName = WebUtility.HtmlEncode(registerViewModel.FirstName),
				LastName = WebUtility.HtmlEncode(registerViewModel.LastName),
				Email = WebUtility.HtmlEncode(registerViewModel.Email),
			};
			IdentityResult result = await userManager.CreateAsync(user, registerViewModel.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, "User");

				return RedirectToAction(nameof(Login));
			}
			foreach (IdentityError? error in result.Errors)
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

			User user = await userManager.FindByEmailAsync(loginViewModel.Email);
			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false);

					bool isAdmin = await userManager.IsInRoleAsync(user, AdminRoleName);

					if (isAdmin)
					{
						return RedirectToAction("Index", "Home", new { Area = "Admin" });
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
			Guid userId = User.GetUserId();

			if (userId != null)
			{
				User user = await userManager.FindByIdAsync(userId.ToString());

				if (user != null)
				{
					List<MessageViewModel> messages = await _messageService.GetMessagesAsync(userId.ToString());

					UserProfileViewModel userProfileModel = new UserProfileViewModel
					{
						FirstName = user.FirstName,
						LastName = user.LastName,
						Email = user.Email,
						Messages = messages
					};

					return View("UserProfile/Profile", userProfileModel);
				}
			}

			return NotFound();
		}
	}
}
