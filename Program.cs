using EmployeeMVC.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeMVC.Database;
using EmployeeMVC.Services;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
options => options.EnableRetryOnFailure()));

var app = builder.Build();

// DatabaseMgmtServices.MigrationInit(app);

// var scope = builder.Services.CreateScope();

// var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

// context.Database.Migrate();

// DatabaseMgmtServices.MigrationInit(app);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
