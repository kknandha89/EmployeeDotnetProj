using EmployeeMVC.Models;
using EmployeeMVC.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeMVC.Services 
{
    public static class DatabaseMgmtServices
    {
        public static void MigrationInit(IApplicationBuilder app)
        {
            // using (var serviceScope = app.ApplicationServices.CreateScope())
            // {
            //     var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            //     context.Database.Migrate();
            // }
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
            }
        }
    }
}