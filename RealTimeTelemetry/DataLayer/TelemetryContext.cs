using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public class TelematryContext : DbContext
    {
        public DbSet<EngineRPM> EngineRPM { get; set; }
        public DbSet<VehicleSpeed> VehicleSpeed { get; set; }
        public DbSet<AcceleratorPosition> AcceleratorPosition { get; set; }
        public DbSet<BrakeActive> BrakeActive { get; set; }
        public DbSet<GearActive> GearActive { get; set; }
        public DbSet<WheelSpeed> WheelSpeed { get; set; }
        public DbSet<SteeringPosition> SteeringPosition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:hackathon2020fsae.database.windows.net,1433;Initial Catalog=hackathon2020fsae;Persist Security Info=False;User ID=fsae;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineRPM>()
                .HasKey(b => b.TimeStamp);
            modelBuilder.Entity<VehicleSpeed>()
                .HasKey(b => b.TimeStamp);
            modelBuilder.Entity<AcceleratorPosition>()
                .HasKey(b => b.TimeStamp);
            modelBuilder.Entity<BrakeActive>()
                .HasKey(b => b.TimeStamp);
            modelBuilder.Entity<GearActive>()
                .HasKey(b => b.TimeStamp);
            modelBuilder.Entity<WheelSpeed>()
                .HasKey(b => b.TimeStamp);
            modelBuilder.Entity<SteeringPosition>()
                .HasKey(b => b.TimeStamp);
        }
    }
}
