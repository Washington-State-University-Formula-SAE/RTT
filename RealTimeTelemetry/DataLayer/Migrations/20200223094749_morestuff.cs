using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class morestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleRPM",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    RPM = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRPM", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "AcceleratorPosition",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceleratorPosition", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "BrakeActive",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrakeActive", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "GearActive",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Gear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearActive", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "SteeringPosition",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteeringPosition", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSpeed",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpeed", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "WheelSpeed",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    FrontDriver = table.Column<short>(nullable: false),
                    FrontPassenger = table.Column<short>(nullable: false),
                    RearDriver = table.Column<short>(nullable: false),
                    RearPassenger = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelSpeed", x => x.TimeStamp);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceleratorPosition");

            migrationBuilder.DropTable(
                name: "BrakeActive");

            migrationBuilder.DropTable(
                name: "GearActive");

            migrationBuilder.DropTable(
                name: "SteeringPosition");

            migrationBuilder.DropTable(
                name: "VehicleSpeed");

            migrationBuilder.DropTable(
                name: "WheelSpeed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleRPM",
                table: "VehicleRPM");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_RPMTimeStamp",
                table: "VehicleRPM",
                columns: new[] { "RPM", "TimeStamp" });
        }
    }
}
