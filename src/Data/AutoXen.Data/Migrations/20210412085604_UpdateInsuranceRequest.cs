namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateInsuranceRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsurersRequests");

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AcceptedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsurenceStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPayments = table.Column<byte>(type: "tinyint", nullable: false),
                    InsurerId = table.Column<int>(type: "int", nullable: false),
                    FinishedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceRequests_Insurers_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_AcceptedById",
                table: "InsuranceRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_CarId",
                table: "InsuranceRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_InsurerId",
                table: "InsuranceRequests",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_IsDeleted",
                table: "InsuranceRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_UserId",
                table: "InsuranceRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceRequests");

            migrationBuilder.CreateTable(
                name: "InsurersRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AcceptedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsurenceStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsurerInsurancesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfInsuranceContributions = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurersRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurersRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurersRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurersRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurersRequests_InsurerInsurances_InsurerInsurancesId",
                        column: x => x.InsurerInsurancesId,
                        principalTable: "InsurerInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_AcceptedById",
                table: "InsurersRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_CarId",
                table: "InsurersRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_InsurerInsurancesId",
                table: "InsurersRequests",
                column: "InsurerInsurancesId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_IsDeleted",
                table: "InsurersRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_UserId",
                table: "InsurersRequests",
                column: "UserId");
        }
    }
}
