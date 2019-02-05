using Microsoft.EntityFrameworkCore.Migrations;

namespace BorrowBikeWebApp.Migrations
{
    public partial class BikeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bikes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bikes");
        }
    }
}
