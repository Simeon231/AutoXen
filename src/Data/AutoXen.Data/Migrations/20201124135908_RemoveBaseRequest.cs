namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveBaseRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_BaseRequests_BaseRequestId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarWashRequests_BaseRequests_BaseRequestId",
                table: "CarWashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurersRequests_BaseRequests_BaseRequestId",
                table: "InsurersRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RoadsideAssistanceRequests_BaseRequests_BaseRequestId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRequests_BaseRequests_BaseRequestId",
                table: "WorkshopRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "BaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRequests_BaseRequestId",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_RoadsideAssistanceRequests_BaseRequestId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_InsurersRequests_BaseRequestId",
                table: "InsurersRequests");

            migrationBuilder.DropIndex(
                name: "IX_CarWashRequests_BaseRequestId",
                table: "CarWashRequests");

            migrationBuilder.DropIndex(
                name: "IX_AnnualTechnicalInspectionRequests_BaseRequestId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "BaseRequestId",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "BaseRequestId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "BaseRequestId",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "BaseRequestId",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "BaseRequestId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.AddColumn<string>(
                name: "AcceptedById",
                table: "WorkshopRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "WorkshopRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedOn",
                table: "WorkshopRequests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "WorkshopRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WorkshopRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "AcceptedById",
                table: "RoadsideAssistanceRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "RoadsideAssistanceRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RoadsideAssistanceRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RoadsideAssistanceRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedOn",
                table: "RoadsideAssistanceRequests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RoadsideAssistanceRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "RoadsideAssistanceRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoadsideAssistanceRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "AcceptedById",
                table: "InsurersRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "InsurersRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "InsurersRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "InsurersRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedOn",
                table: "InsurersRequests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InsurersRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "InsurersRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "InsurersRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "AcceptedById",
                table: "CarWashRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "CarWashRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CarWashRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CarWashRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedOn",
                table: "CarWashRequests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarWashRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CarWashRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CarWashRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "AcceptedById",
                table: "AnnualTechnicalInspectionRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "AnnualTechnicalInspectionRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AnnualTechnicalInspectionRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AnnualTechnicalInspectionRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedOn",
                table: "AnnualTechnicalInspectionRequests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AnnualTechnicalInspectionRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AnnualTechnicalInspectionRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnnualTechnicalInspectionRequests",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_AcceptedById",
                table: "WorkshopRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_CarId",
                table: "WorkshopRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_IsDeleted",
                table: "WorkshopRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_UserId",
                table: "WorkshopRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_AcceptedById",
                table: "RoadsideAssistanceRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_CarId",
                table: "RoadsideAssistanceRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_IsDeleted",
                table: "RoadsideAssistanceRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_UserId",
                table: "RoadsideAssistanceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_AcceptedById",
                table: "InsurersRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_CarId",
                table: "InsurersRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_IsDeleted",
                table: "InsurersRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_UserId",
                table: "InsurersRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_AcceptedById",
                table: "CarWashRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_CarId",
                table: "CarWashRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_IsDeleted",
                table: "CarWashRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_UserId",
                table: "CarWashRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_AcceptedById",
                table: "AnnualTechnicalInspectionRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_CarId",
                table: "AnnualTechnicalInspectionRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_IsDeleted",
                table: "AnnualTechnicalInspectionRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_UserId",
                table: "AnnualTechnicalInspectionRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_AspNetUsers_AcceptedById",
                table: "AnnualTechnicalInspectionRequests",
                column: "AcceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_Cars_CarId",
                table: "AnnualTechnicalInspectionRequests",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_AspNetUsers_UserId",
                table: "AnnualTechnicalInspectionRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashRequests_AspNetUsers_AcceptedById",
                table: "CarWashRequests",
                column: "AcceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashRequests_Cars_CarId",
                table: "CarWashRequests",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashRequests_AspNetUsers_UserId",
                table: "CarWashRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurersRequests_AspNetUsers_AcceptedById",
                table: "InsurersRequests",
                column: "AcceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurersRequests_Cars_CarId",
                table: "InsurersRequests",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurersRequests_AspNetUsers_UserId",
                table: "InsurersRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadsideAssistanceRequests_AspNetUsers_AcceptedById",
                table: "RoadsideAssistanceRequests",
                column: "AcceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadsideAssistanceRequests_Cars_CarId",
                table: "RoadsideAssistanceRequests",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadsideAssistanceRequests_AspNetUsers_UserId",
                table: "RoadsideAssistanceRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRequests_AspNetUsers_AcceptedById",
                table: "WorkshopRequests",
                column: "AcceptedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRequests_Cars_CarId",
                table: "WorkshopRequests",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRequests_AspNetUsers_UserId",
                table: "WorkshopRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_AspNetUsers_AcceptedById",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_Cars_CarId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_AspNetUsers_UserId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarWashRequests_AspNetUsers_AcceptedById",
                table: "CarWashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarWashRequests_Cars_CarId",
                table: "CarWashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_CarWashRequests_AspNetUsers_UserId",
                table: "CarWashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurersRequests_AspNetUsers_AcceptedById",
                table: "InsurersRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurersRequests_Cars_CarId",
                table: "InsurersRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_InsurersRequests_AspNetUsers_UserId",
                table: "InsurersRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RoadsideAssistanceRequests_AspNetUsers_AcceptedById",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RoadsideAssistanceRequests_Cars_CarId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RoadsideAssistanceRequests_AspNetUsers_UserId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRequests_AspNetUsers_AcceptedById",
                table: "WorkshopRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRequests_Cars_CarId",
                table: "WorkshopRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRequests_AspNetUsers_UserId",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRequests_AcceptedById",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRequests_CarId",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRequests_IsDeleted",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRequests_UserId",
                table: "WorkshopRequests");

            migrationBuilder.DropIndex(
                name: "IX_RoadsideAssistanceRequests_AcceptedById",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_RoadsideAssistanceRequests_CarId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_RoadsideAssistanceRequests_IsDeleted",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_RoadsideAssistanceRequests_UserId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_InsurersRequests_AcceptedById",
                table: "InsurersRequests");

            migrationBuilder.DropIndex(
                name: "IX_InsurersRequests_CarId",
                table: "InsurersRequests");

            migrationBuilder.DropIndex(
                name: "IX_InsurersRequests_IsDeleted",
                table: "InsurersRequests");

            migrationBuilder.DropIndex(
                name: "IX_InsurersRequests_UserId",
                table: "InsurersRequests");

            migrationBuilder.DropIndex(
                name: "IX_CarWashRequests_AcceptedById",
                table: "CarWashRequests");

            migrationBuilder.DropIndex(
                name: "IX_CarWashRequests_CarId",
                table: "CarWashRequests");

            migrationBuilder.DropIndex(
                name: "IX_CarWashRequests_IsDeleted",
                table: "CarWashRequests");

            migrationBuilder.DropIndex(
                name: "IX_CarWashRequests_UserId",
                table: "CarWashRequests");

            migrationBuilder.DropIndex(
                name: "IX_AnnualTechnicalInspectionRequests_AcceptedById",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AnnualTechnicalInspectionRequests_CarId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AnnualTechnicalInspectionRequests_IsDeleted",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AnnualTechnicalInspectionRequests_UserId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "FinishedOn",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkshopRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "FinishedOn",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoadsideAssistanceRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "FinishedOn",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InsurersRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "FinishedOn",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarWashRequests");

            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "FinishedOn",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnnualTechnicalInspectionRequests");

            migrationBuilder.AddColumn<string>(
                name: "BaseRequestId",
                table: "WorkshopRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "BaseRequestId",
                table: "RoadsideAssistanceRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "BaseRequestId",
                table: "InsurersRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "BaseRequestId",
                table: "CarWashRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "BaseRequestId",
                table: "AnnualTechnicalInspectionRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AcceptedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestName = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseRequestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SentById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_BaseRequests_BaseRequestId",
                        column: x => x.BaseRequestId,
                        principalTable: "BaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_BaseRequestId",
                table: "WorkshopRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_BaseRequestId",
                table: "RoadsideAssistanceRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_BaseRequestId",
                table: "InsurersRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_BaseRequestId",
                table: "CarWashRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_BaseRequestId",
                table: "AnnualTechnicalInspectionRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_AcceptedById",
                table: "BaseRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_CarId",
                table: "BaseRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_IsDeleted",
                table: "BaseRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequests_UserId",
                table: "BaseRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BaseRequestId",
                table: "Messages",
                column: "BaseRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualTechnicalInspectionRequests_BaseRequests_BaseRequestId",
                table: "AnnualTechnicalInspectionRequests",
                column: "BaseRequestId",
                principalTable: "BaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashRequests_BaseRequests_BaseRequestId",
                table: "CarWashRequests",
                column: "BaseRequestId",
                principalTable: "BaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsurersRequests_BaseRequests_BaseRequestId",
                table: "InsurersRequests",
                column: "BaseRequestId",
                principalTable: "BaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadsideAssistanceRequests_BaseRequests_BaseRequestId",
                table: "RoadsideAssistanceRequests",
                column: "BaseRequestId",
                principalTable: "BaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRequests_BaseRequests_BaseRequestId",
                table: "WorkshopRequests",
                column: "BaseRequestId",
                principalTable: "BaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
