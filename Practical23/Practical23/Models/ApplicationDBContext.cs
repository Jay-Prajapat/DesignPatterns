using Microsoft.EntityFrameworkCore;

namespace Practical23.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
