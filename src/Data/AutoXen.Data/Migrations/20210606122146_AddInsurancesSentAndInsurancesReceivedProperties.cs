namespace AutoXen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddInsurancesSentAndInsurancesReceivedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InsurancesReceived",
                table: "InsuranceRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InsurancesSent",
                table: "InsuranceRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsurancesReceived",
                table: "InsuranceRequests");

            migrationBuilder.DropColumn(
                name: "InsurancesSent",
                table: "InsuranceRequests");
        }
    }
}
