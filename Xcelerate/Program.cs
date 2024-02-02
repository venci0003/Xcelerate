using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<XcelerateContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<XcelerateContext>();

builder.Services.AddControllersWithViews()
	.AddMvcOptions(options =>
	{
		//This filter adds a guid on the forms
		options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
		options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
	});

builder.Services.Configure<IISServerOptions>(options =>
{
	options.AllowSynchronousIO = true;
});

builder.Services.Configure<IdentityOptions>(options =>
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
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // CookieSettings.
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(45);
    options.SlidingExpiration = true;

    //options.LoginPath = "/Identity/Account/Login";
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    //options.LogoutPath = "/Identity/Account/Logout";
});


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
		name: "ad",
		pattern: "{controller=Ad}/{action=Information}/{carId?}");

	config.MapControllerRoute(
	  name: "adCreate",
	  pattern: "{controller=Ad}/{action=Create}");

	config.MapRazorPages();
});

app.Run();
