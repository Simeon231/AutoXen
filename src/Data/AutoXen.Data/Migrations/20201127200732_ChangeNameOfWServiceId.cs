using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoXen.Data.Migrations
{
    public partial class ChangeNameOfWServiceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "WorkshopRequestWServices");

            migrationBuilder.AlterColumn<int>(
                name: "WServiceId",
                table: "WorkshopRequestWServices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WServiceId",
                table: "WorkshopRequestWServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "WorkshopRequestWServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
