using ForumApp.Core.Contracts;
using ForumApp.Core.Services;
using ForumApp.Infrastructure;
using ForumApp.Infrastructure.configuration;
using ForumApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ForumAppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ForumAppDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPostService, PostServices>();
builder.Services.AddScoped<Func<IServiceProvider, Task>>(serviceProvider =>
{
    return async serviceProvider =>
    {
        await Initialize(serviceProvider);
    };
});
builder.Services.AddScoped<ForumAppDbSeeder>();



var app = builder.Build();

// Define Initialize method within the Program class
async Task Initialize(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ForumAppDbContext>();
        var dbSeeder = services.GetRequiredService<ForumAppDbSeeder>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        try
        {

            // Seed users
            var users = new List<(string UserName, string Email, string Password)>
            {
                ("mike_wilson", "mike@example.com", "Password345!"),
                ("john_doe", "john@example.com", "Password123!"),
                ("jane_smith", "jane@example.com", "Password456!"),
                ("emily_jones","emily@example.com","!789drowssaP"),
                ("david_brown","david@example.com","Pass123!word")
            };
            await dbSeeder.SeedUsersAsync(users);

            // Seed posts if the table is empty
            if (!context.Posts.Any())
            {
                await dbSeeder.SeedData();
            }

            context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
        }
    }
}

// Invoke Initialize method during application startup
var serviceProvider = app.Services.CreateScope().ServiceProvider;
var initializeMethod = serviceProvider.GetRequiredService<Func<IServiceProvider, Task>>();
await initializeMethod(serviceProvider);




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
