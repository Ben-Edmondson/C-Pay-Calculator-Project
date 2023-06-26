﻿using Microsoft.EntityFrameworkCore;
using PayCalc.ClassLibrary.Models;
namespace PayCalc.ClassLibrary.dbContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<PermanentEmployee>? PermanentEmployees { get; set; }
        public DbSet<TemporaryEmployee>? TemporaryEmployees { get; set; }

        public string DbPath { get; }

        public MyDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "employees.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

    }
}
