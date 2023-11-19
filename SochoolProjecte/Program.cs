using Core.Application.FormAuth.CookieScheme;
using Microsoft.AspNetCore.DataProtection;
using School.Application;
using School.Persistence;
using School.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);


// Add builder.Services to the container.
builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo("DataEncrpytionKeys"));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
});

//AddApplicationServices
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddLocalization();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization();


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

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Seed users and roles
    await UsersConfiguration.SeedUsersAndRolesAsync(serviceProvider);
}
app.UseRequestLocalization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
