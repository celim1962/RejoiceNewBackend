using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RejoiceNewBackend.Migrations
{
    /// <inheritdoc />
    public partial class addTripDetailAndPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripDetailPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceType = table.Column<string>(type: "TEXT", nullable: true),
                    PriceAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetailPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HomePageImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    DetailImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    MaxOrderPeople = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDetailPrice");

            migrationBuilder.DropTable(
                name: "TripDetails");
        }
    }
}
