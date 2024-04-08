using Microsoft.AspNetCore.Identity;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Extensions
{
	public static class WebApplicationBuilderExtensions
	{
		public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string userId)
		{
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;
			UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
			RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(AdminRoleName))
				{
					return;
				}
				IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
				await roleManager.CreateAsync(role);

				User userToFind = await userManager.FindByIdAsync(userId);
				await userManager.AddToRoleAsync(userToFind, AdminRoleName);

			})
				.GetAwaiter()
				.GetResult();
			// To do chaining
			return app;
		}
	}
}
