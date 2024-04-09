using Xcelerate.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.AddServices();

builder.Services.AddGlobalFilters();

builder.Services.Configure<IISServerOptions>(options =>
{
	options.AllowSynchronousIO = true;
});

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

app.UseEndpoints(config =>
{
	config.MapControllerRoute(
	name: "areas",
	pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");

	config.MapControllerRoute(
		name: "home",
		pattern: "{controller=Home}/{action=HomePage}/{id?}"
	);

	config.MapDefaultControllerRoute();

	config.MapRazorPages();
});

app.Run();
