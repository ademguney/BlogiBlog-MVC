using Blogi.Application;
using Blogi.Persistence;
using Core.Application.FormAuth.CookieScheme;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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


// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();




var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Dashboard}/{action=Home}/{id?}");

app.Run();