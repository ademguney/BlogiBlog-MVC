using Blogi.Application;
using Blogi.Persistence;
using Core.Application.FormAuth.CookieScheme;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = AuthDefault.Scheme;
    options.DefaultSignInScheme = AuthDefault.Scheme;
    options.DefaultChallengeScheme = AuthDefault.Scheme;
})
                .AddCookie(AuthDefault.Scheme, options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.LoginPath = new PathString(AuthDefault.LogIn);
                    options.LogoutPath = new PathString(AuthDefault.LogOut);
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Home}/{id?}");

app.Run();
