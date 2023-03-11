using Blogi.Application;
using Blogi.Application.Services.LanguageService;
using Blogi.Persistence;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddLocalization();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization();

// Localization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var serviceProvider = builder.Services.BuildServiceProvider();
	var languageService = serviceProvider.GetRequiredService<ILanguageService>();
	var languages = languageService.GetListAsync().Result;
	var cultures = languages.Select(x => new CultureInfo(x.Culture)).ToArray();

	var engCulture = cultures.FirstOrDefault(x => x.Name == "en-US");
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(engCulture.Name ?? "en-US");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRequestLocalization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
