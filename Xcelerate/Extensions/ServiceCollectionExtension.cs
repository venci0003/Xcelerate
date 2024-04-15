namespace Xcelerate.Extensions
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Areas.Admin.Contracts;
	using Areas.Admin.Services;
	using Core.Contracts;
	using Core.Services;
	using Infrastructure.Data;
	using Infrastructure.Data.Models;
	using ModelBinders;
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

		public static void AddGlobalFilters(this IServiceCollection services)
		{
			services.Configure<MvcOptions>(options =>
			{
				options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
				options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
			});
		}
	}
}
