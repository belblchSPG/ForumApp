using AnimeApp.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AnimeApp.Models;
using AnimeApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AnimeService>();

var app = builder.Build();

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

app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string adminEmail = "SteFF03@yandex.ru";
    string adminPassword = "adminpassword2023";

    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var admin = new ApplicationUser();
        admin.Email = adminEmail;
        admin.UserName = adminEmail;
        admin.FirstName = "Admin";
        admin.LastName = "Admin";
        admin.Nickname = "Admin";

        await userManager.CreateAsync(admin, adminPassword);

        await userManager.AddToRoleAsync(admin, "Admin");
    }
}

app.Run();
