
using BlueBird.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UserFormContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDatabase")));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserForm}/{action=Index}");

app.Run();
