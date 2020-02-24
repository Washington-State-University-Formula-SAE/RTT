using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DataLayer
{
    public class TelematryContext : DbContext
    {
        public DbSet<VehicleRPM> VehicleRPM { get; set; }
        public DbSet<VehicleSpeed> VehicleSpeed { get; set; }
        public DbSet<AcceleratorPosition> AcceleratorPosition { get; set; }
        public DbSet<BrakeActive> BrakeActive { get; set; }
        public DbSet<GearActive> GearActive { get; set; }
        public DbSet<WheelSpeed> WheelSpeed { get; set; }
        public DbSet<SteeringPosition> SteeringPosition { get; set; }
        public DbSet<EngineTemperature> EngineTemperature { get; set; }

        public TelematryContext()
        {

        }
        public TelematryContext(DbContextOptions<TelematryContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("connection string (ONLY CONFIGURE THIS FOR MIGRATIONS!!!)");
                throw new Exception("No optionsBuilder is configured!");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleRPM>()
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
            modelBuilder.Entity<EngineTemperature>()
                .HasKey(b => b.TimeStamp);
        }
    }
}
