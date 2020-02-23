﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(TelematryContext))]
    [Migration("20200223094749_morestuff")]
    partial class morestuff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.AcceleratorPosition", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("TimeStamp");

                    b.ToTable("AcceleratorPosition");
                });

            modelBuilder.Entity("Models.BrakeActive", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.HasKey("TimeStamp");

                    b.ToTable("BrakeActive");
                });

            modelBuilder.Entity("Models.GearActive", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gear")
                        .HasColumnType("int");

                    b.HasKey("TimeStamp");

                    b.ToTable("GearActive");
                });

            modelBuilder.Entity("Models.SteeringPosition", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("TimeStamp");

                    b.ToTable("SteeringPosition");
                });

            modelBuilder.Entity("Models.VehicleRPM", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("RPM")
                        .HasColumnType("int");

                    b.HasKey("TimeStamp");

                    b.ToTable("VehicleRPM");
                });

            modelBuilder.Entity("Models.VehicleSpeed", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("TimeStamp");

                    b.ToTable("VehicleSpeed");
                });

            modelBuilder.Entity("Models.WheelSpeed", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<short>("FrontDriver")
                        .HasColumnType("smallint");

                    b.Property<short>("FrontPassenger")
                        .HasColumnType("smallint");

                    b.Property<short>("RearDriver")
                        .HasColumnType("smallint");

                    b.Property<short>("RearPassenger")
                        .HasColumnType("smallint");

                    b.HasKey("TimeStamp");

                    b.ToTable("WheelSpeed");
                });
#pragma warning restore 612, 618
        }
    }
}
