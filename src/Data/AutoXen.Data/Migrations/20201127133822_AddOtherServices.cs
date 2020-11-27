namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddOtherServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopServiceId",
                table: "WorkshopRequests");

            migrationBuilder.AddColumn<bool>(
                name: "AdminChooseWorkshop",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherServices",
                table: "WorkshopRequests",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PickUpFastAsPossible",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PickUpLocation",
                table: "WorkshopRequests",
                maxLength: 150,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpTime",
                table: "WorkshopRequests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PickedUp",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReturnedCar",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminChooseWorkshop",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "OtherServices",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "PickUpFastAsPossible",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "PickUpLocation",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "PickUpTime",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "PickedUp",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "ReturnedCar",
                table: "WorkshopRequests");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopServiceId",
                table: "WorkshopRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
