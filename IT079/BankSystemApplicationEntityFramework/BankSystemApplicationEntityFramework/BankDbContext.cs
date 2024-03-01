// BankDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank_App_Entity
{
    public class BankDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

