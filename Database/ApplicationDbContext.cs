using EmployeeMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Database 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeCls> Employees {get; set;}
    }
}
