namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateInsuranceModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceRequestsInsurerInsurances");

            migrationBuilder.AddColumn<int>(
                name: "InsurerId",
                table: "InsuranceRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsuranceRequestsInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceRequestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequestsInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestsInsurances_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestsInsurances_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_InsurerId",
                table: "InsuranceRequests",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestsInsurances_InsuranceId",
                table: "InsuranceRequestsInsurances",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestsInsurances_InsuranceRequestId",
                table: "InsuranceRequestsInsurances",
                column: "InsuranceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceRequests_Insurers_InsurerId",
                table: "InsuranceRequests",
                column: "InsurerId",
                principalTable: "Insurers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceRequests_Insurers_InsurerId",
                table: "InsuranceRequests");

            migrationBuilder.DropTable(
                name: "InsuranceRequestsInsurances");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceRequests_InsurerId",
                table: "InsuranceRequests");

            migrationBuilder.DropColumn(
                name: "InsurerId",
                table: "InsuranceRequests");

            migrationBuilder.CreateTable(
                name: "InsuranceRequestsInsurerInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceRequestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InsurerInsuranceId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequestsInsurerInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestsInsurerInsurances_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestsInsurerInsurances_InsurerInsurances_InsurerInsuranceId",
                        column: x => x.InsurerInsuranceId,
                        principalTable: "InsurerInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestsInsurerInsurances_InsuranceRequestId",
                table: "InsuranceRequestsInsurerInsurances",
                column: "InsuranceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestsInsurerInsurances_InsurerInsuranceId",
                table: "InsuranceRequestsInsurerInsurances",
                column: "InsurerInsuranceId");
        }
    }
}
