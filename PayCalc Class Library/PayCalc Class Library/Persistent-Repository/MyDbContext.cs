using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PayCalc_Project.Models;

namespace PayCalc_Class_Library.Persistent_Repository
{
    public class MyDbContext : DbContext
    {
        private readonly string connectionString;

        public MyDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<PermanentEmployee>? PermanentEmployees { get; set; }
        public DbSet<TemporaryEmployee>? TemporaryEmployees { get; set;}
    }
}
