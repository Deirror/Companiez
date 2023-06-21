using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CompaniesProjectz.Data.Models;

namespace CompaniesProjectz.Data
{
    public class CompaniesProjectzDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompaniesInstInvestor>(entity =>
            {
                entity.HasKey(e => new { e.IdTsCompany, e.IdInstinvestorName });
            });

            modelBuilder.Entity<Company>().HasIndex(u => u.TickerSymbol).IsUnique();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=CompaniesProjectDb; Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public CompaniesProjectzDbContext()
        {

        }

        public CompaniesProjectzDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Company> Companies{ get; set; }
        public DbSet<IndividualInvestor> IndividualInvestors { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<InstitutionalInvestor> InstitutionalInvestors { get; set; }
        public DbSet<CompaniesInstInvestor> CompaniesInstInvestors { get; set; }


    }
}
