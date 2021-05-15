using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoXen.Data.Migrations
{
    public partial class MoveRoadsideAssistancePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RoadsideAssistances");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "RoadsideAssistanceServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RoadsideAssistanceServices");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "RoadsideAssistances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
