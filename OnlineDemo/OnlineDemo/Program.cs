using Microsoft.EntityFrameworkCore;
using OnlineDemo.Helpers;
using OnlineDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlineDemoDatabaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineDemoDatabase"));
});

builder.Services.AddSession(options => { 
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<OnlineUsersHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
