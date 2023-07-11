using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Database
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext()
        {
            
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=sf-cpu-336\SQLEXPRESS;Initial Catalog=Practical26;Integrated Security=True;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
