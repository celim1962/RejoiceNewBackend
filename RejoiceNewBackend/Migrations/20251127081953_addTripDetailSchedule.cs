using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejoiceNewBackend.Migrations
{
    /// <inheritdoc />
    public partial class addTripDetailSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripDetailSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActivityDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ActivityName = table.Column<string>(type: "TEXT", nullable: false),
                    ActivityLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ActivityImgUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetailSchedule", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDetailSchedule");
        }
    }
}
