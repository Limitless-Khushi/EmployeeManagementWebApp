using Microsoft.EntityFrameworkCore;
using EmployeeManagementWebApp.Models;

namespace EmployeeManagementWebApp.Data
{
    // Coordinates Entity Framework functionality for our Employee model
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Creates the database table based on our Employee model structure
        public DbSet<Employee> Employees { get; set; }
    }
}