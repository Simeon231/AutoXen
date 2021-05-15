namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveRoadsideProvinces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoadsideAssistanceRequests_RoadsideAssistanceProvinces_RoadsideAssistanceProvinceId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropTable(
                name: "RoadsideAssistanceProvinces");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.RenameColumn(
                name: "RoadsideAssistanceProvinceId",
                table: "RoadsideAssistanceRequests",
                newName: "RoadsideAssistanceId");

            migrationBuilder.RenameIndex(
                name: "IX_RoadsideAssistanceRequests_RoadsideAssistanceProvinceId",
                table: "RoadsideAssistanceRequests",
                newName: "IX_RoadsideAssistanceRequests_RoadsideAssistanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoadsideAssistanceRequests_RoadsideAssistances_RoadsideAssistanceId",
                table: "RoadsideAssistanceRequests",
                column: "RoadsideAssistanceId",
                principalTable: "RoadsideAssistances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoadsideAssistanceRequests_RoadsideAssistances_RoadsideAssistanceId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.RenameColumn(
                name: "RoadsideAssistanceId",
                table: "RoadsideAssistanceRequests",
                newName: "RoadsideAssistanceProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_RoadsideAssistanceRequests_RoadsideAssistanceId",
                table: "RoadsideAssistanceRequests",
                newName: "IX_RoadsideAssistanceRequests_RoadsideAssistanceProvinceId");

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadsideAssistanceProvinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvicneId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    RoadsideAssistanceId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadsideAssistanceProvinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceProvinces_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceProvinces_RoadsideAssistances_RoadsideAssistanceId",
                        column: x => x.RoadsideAssistanceId,
                        principalTable: "RoadsideAssistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceProvinces_ProvinceId",
                table: "RoadsideAssistanceProvinces",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceProvinces_RoadsideAssistanceId",
                table: "RoadsideAssistanceProvinces",
                column: "RoadsideAssistanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoadsideAssistanceRequests_RoadsideAssistanceProvinces_RoadsideAssistanceProvinceId",
                table: "RoadsideAssistanceRequests",
                column: "RoadsideAssistanceProvinceId",
                principalTable: "RoadsideAssistanceProvinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
