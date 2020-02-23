using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public class TelematryContext : DbContext
    {
        public DbSet<VehicleRPM> EngineRPM { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:hackathon2020fsae.database.windows.net,1433;Initial Catalog=hackathon2020fsae;Persist Security Info=False;User ID=fsae;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleRPM>()
                .HasKey(b => b.TimeStamp)
                .HasName("PrimaryKey_TimeStampKey");
        }
    }
}
