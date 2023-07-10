using Microsoft.EntityFrameworkCore;
using Practical25.Models;

namespace Practical25.Database
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }
        public virtual DbSet<Employee> Employees { get; set; }
    }

}
