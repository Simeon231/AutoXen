namespace AutoXen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsurenceStart",
                table: "InsuranceRequests",
                newName: "InsuranceStart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsuranceStart",
                table: "InsuranceRequests",
                newName: "InsurenceStart");
        }
    }
}
