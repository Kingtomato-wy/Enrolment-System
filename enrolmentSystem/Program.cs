using enrolmentSystem.Data;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add session services (before building the app)
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;  // Ensures cookies are only accessible via HTTP, not JavaScript
    options.Cookie.IsEssential = true;  // Ensures the cookie is always stored
    options.Cookie.SameSite = SameSiteMode.Strict; // Adjust based on your needs
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Requires HTTPS
});

// Enable cookie policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => false; // Set to true if you need user consent
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Apply cookie policy before session
app.UseCookiePolicy();

// Use session middleware after routing and before authorization
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
=======
using enrolmentSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace GroupAsg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddDistributedMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.MapRazorPages();

            // Read Default Page from appsettings.json
            var defaultPage = builder.Configuration["DefaultPage"] ?? "/Login/Login";

            // Redirect root URL ("/") to DefaultPage
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect(defaultPage);
                }
                else
                {
                    await next();
                }
            });

            app.Run();
        }
    }
}
>>>>>>> origin/wy
