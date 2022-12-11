using Blogi.Application;
using Blogi.Application.Services.LanguageService;
using Blogi.Persistence;
using Core.Application.FormAuth.CookieScheme;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
var lang=builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();


builder.Services.AddLocalization();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization();

//Localization
var languageService = lang.BuildServiceProvider().GetService<ILanguageService>();
var languages = languageService.GetListAsync().Result;
var cultures = languages.Select(x => new CultureInfo(x.Culture)).ToArray();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{

    var engCulture = cultures.FirstOrDefault(x => x.Name == "en-US");
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(engCulture.Name ?? "en-US");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});



// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = AuthDefaults.Scheme;
    options.DefaultSignInScheme = AuthDefaults.Scheme;
    options.DefaultChallengeScheme = AuthDefaults.Scheme;
    options.DefaultAuthenticateScheme = AuthDefaults.Scheme;
})
.AddCookie(AuthDefaults.Scheme, options =>
                {

                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.LoginPath = new PathString(AuthDefaults.LogIn);
                    options.LogoutPath = new PathString(AuthDefaults.LogOut);
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();