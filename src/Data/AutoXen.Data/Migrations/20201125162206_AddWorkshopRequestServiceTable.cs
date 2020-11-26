namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddWorkshopRequestServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRequests_WorkshopServices_WorkshopServiceId",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRequests_WorkshopServiceId",
                table: "WorkshopRequests");

            migrationBuilder.CreateTable(
                name: "WorkshopRequestServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    WorkshopRequestId = table.Column<string>(nullable: true),
                    WorkshopServiceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRequestServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopRequestServices_WorkshopRequests_WorkshopRequestId",
                        column: x => x.WorkshopRequestId,
                        principalTable: "WorkshopRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopRequestServices_WorkshopServices_WorkshopServiceId",
                        column: x => x.WorkshopServiceId,
                        principalTable: "WorkshopServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequestServices_WorkshopRequestId",
                table: "WorkshopRequestServices",
                column: "WorkshopRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequestServices_WorkshopServiceId",
                table: "WorkshopRequestServices",
                column: "WorkshopServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopRequestServices");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_WorkshopServiceId",
                table: "WorkshopRequests",
                column: "WorkshopServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRequests_WorkshopServices_WorkshopServiceId",
                table: "WorkshopRequests",
                column: "WorkshopServiceId",
                principalTable: "WorkshopServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
