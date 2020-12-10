namespace AutoXen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeNameOf2Bools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopServicesDone",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "WashingFinished",
                table: "CarWashRequests");

            migrationBuilder.AddColumn<bool>(
                name: "ServiceFinished",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServiceFinished",
                table: "CarWashRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceFinished",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "ServiceFinished",
                table: "CarWashRequests");

            migrationBuilder.AddColumn<bool>(
                name: "WorkshopServicesDone",
                table: "WorkshopRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WashingFinished",
                table: "CarWashRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
