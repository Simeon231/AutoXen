namespace AutoXen.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRequiredToInsuranceRequestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InsuranceRequestId",
                table: "InsuranceRequestsInsurances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InsuranceRequestId",
                table: "InsuranceRequestsInsurances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
