using Microsoft.EntityFrameworkCore;
using PayCalc_Project.Models;

namespace PayCalc_Class_Library.Persistent_Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionString");
            }
        }
        public DbSet<PermanentEmployee>? PermanentEmployees { get; set; }
        public DbSet<TemporaryEmployee>? TemporaryEmployees { get; set;}
    }
}
