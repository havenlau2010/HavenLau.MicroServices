using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAPConsoleSubscribeDemo
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public const string ConnectionString = "Server=192.168.88.101;Database=zxTest;User=sa;Password =whlx8888;";

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
