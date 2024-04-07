using BookingWebProject.ModelBinders.DecimalModelBinder;
using Microsoft.AspNetCore.Identity;
using Xcelerate.Extensions;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);

//builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddDefaultIdentity<User>(options =>
{
	options.Password.RequireDigit = true;
	options.SignIn.RequireConfirmedAccount = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
	.AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<XcelerateContext>();

builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews()
	.AddMvcOptions(options =>
	{
		//options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
		options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
	});

builder.Services.AddServices();

builder.Services.Configure<IISServerOptions>(options =>
{
	options.AllowSynchronousIO = true;
});

//builder.Services.Configure<IdentityOptions>(options =>
//{
//	// Password settings.
//	//options.Password.RequireDigit = true;
//	//options.Password.RequireLowercase = true;
//	//options.Password.RequireNonAlphanumeric = true;
//	//options.Password.RequireUppercase = true;
//	//options.Password.RequiredLength = 6;
//	//options.Password.RequiredUniqueChars = 1;

//	// Lockout settings.
//	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//	options.Lockout.MaxFailedAccessAttempts = 5;
//	options.Lockout.AllowedForNewUsers = true;

//	// User settings.
//	options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//	options.User.RequireUniqueEmail = false;
//});

builder.Services.ConfigureApplicationCookie(options =>
{
	// CookieSettings.
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(45);
	options.SlidingExpiration = true;

	options.LoginPath = "/Account/Login";
	//options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.LogoutPath = "/Home/HomePage";
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//	.AddCookie(options =>
//	{
//		options.LoginPath = "/Account/Login";
//	});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdministrator("F3B1E0A3-0F36-4E83-AA76-DEB9AF5D5F07");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=HomePage}/{id?}");
//app.MapRazorPages();

app.UseEndpoints(config =>
{
	config.MapControllerRoute(
		name: "home",
		pattern: "{controller=Home}/{action=HomePage}/{id?}"
	);

	config.MapControllerRoute(
	name: "admin",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
	config.MapRazorPages();
});

app.Run();
