﻿using Microsoft.EntityFrameworkCore;
using PayCalc.ClassLibrary.Models;

namespace PayCalc.ClassLibrary.dbContext
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<PermanentEmployee>? PermanentEmployees { get; set; }
        public virtual DbSet<TemporaryEmployee>? TemporaryEmployees { get; set; }

        private readonly bool _useInMemory;

        private string DbPath;

        public MyDbContext()
        {
            _useInMemory = false;
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "employees.db");
        }

        public MyDbContext(DbContextOptions<MyDbContext> options, bool useInMemory = false) : base(options)
        {
            _useInMemory = useInMemory;
            if (!_useInMemory)
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                DbPath = Path.Join(path, "employees.db");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_useInMemory)
                {
                    optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
                }
                else
                {
                    optionsBuilder.UseSqlite($"Data Source={DbPath}");
                }
            }
        }
    }
}


