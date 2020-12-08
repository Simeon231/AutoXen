namespace AutoXen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeNameOfProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarWashingDone",
                table: "WorkshopRequests");

            migrationBuilder.AddColumn<bool>(
                name: "WorkshopServicesDone",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopServicesDone",
                table: "WorkshopRequests");

            migrationBuilder.AddColumn<bool>(
                name: "CarWashingDone",
                table: "WorkshopRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
