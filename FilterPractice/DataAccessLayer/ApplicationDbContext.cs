using FilterPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace FilterPractice.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
