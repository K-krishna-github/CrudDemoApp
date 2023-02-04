using CrudDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDemoApp.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        public DbSet<Role> roles { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
