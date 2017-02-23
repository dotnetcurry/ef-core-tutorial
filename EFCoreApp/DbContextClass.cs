using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace EFCoreApp
{
    public class CompanyEntities : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connstr"].ToString();
            optionsBuilder.UseSqlServer(connstr);
        }
        
    }
}
