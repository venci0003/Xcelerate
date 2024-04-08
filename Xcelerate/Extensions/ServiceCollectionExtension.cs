using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Areas.Admin.Contracts;
using Xcelerate.Areas.Admin.Services;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Services;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddServices(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IAdService, АdService>();
			serviceDescriptors.AddScoped<IAccessoriesService, AccessoriesService>();
			serviceDescriptors.AddScoped<IUserCarsService, UserCarsService>();
			serviceDescriptors.AddScoped<IReviewService, ReviewService>();
			serviceDescriptors.AddScoped<IHomeService, HomeService>();

			serviceDescriptors.AddScoped<IAdminReviewService, AdminReviewService>();
			serviceDescriptors.AddScoped<IAdminNewsService, AdminNewsService>();
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("DefaultConnection");
			services.AddDbContext<XcelerateContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
		{
			services
				.AddDefaultIdentity<User>(options =>
				{
					// Password settings.
					//options.Password.RequireDigit = true;
					//options.Password.RequireLowercase = true;
					//options.Password.RequireNonAlphanumeric = true;
					//options.Password.RequireUppercase = true;
					//options.Password.RequiredLength = 6;
					//options.Password.RequiredUniqueChars = 1;

					// Lockout settings.
					options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
					options.Lockout.MaxFailedAccessAttempts = 5;
					options.Lockout.AllowedForNewUsers = true;

					// User settings.
					options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
					options.User.RequireUniqueEmail = true;
				})
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<XcelerateContext>()
				.AddDefaultTokenProviders();

			return services;
		}
	}
}
