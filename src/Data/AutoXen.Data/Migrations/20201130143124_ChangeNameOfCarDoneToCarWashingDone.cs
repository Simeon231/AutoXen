namespace AutoXen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeNameOfCarDoneToCarWashingDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarDone",
                table: "WorkshopRequests");

            migrationBuilder.AddColumn<bool>(
                name: "CarWashingDone",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarWashingDone",
                table: "WorkshopRequests");

            migrationBuilder.AddColumn<bool>(
                name: "CarDone",
                table: "WorkshopRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
