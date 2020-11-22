namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.CreateTable(
                name: "AnnualTechnicalInspections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualTechnicalInspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    FuelType = table.Column<int>(nullable: true),
                    NumberOfSeats = table.Column<byte>(nullable: true),
                    YearMade = table.Column<short>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    TransmissionType = table.Column<int>(nullable: true),
                    VehicleIdentificationNumber = table.Column<string>(maxLength: 17, nullable: true),
                    RegistrationPlate = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarWashes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadsideAssistances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    AllowedMoreThan3_5T = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadsideAssistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RequestName = table.Column<int>(nullable: false),
                    AcceptedById = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true),
                    FinishedOn = table.Column<DateTime>(nullable: false),
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
                name: "OtherCarUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCarUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherCarUsers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarExtras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<string>(nullable: false),
                    ExtraId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarExtras_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarExtras_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsurerInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    InsurerId = table.Column<int>(nullable: false),
                    InsuranceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurerInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurerInsurances_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurerInsurances_Insurers_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoadsideAssistanceProvinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoadsideAssistanceId = table.Column<int>(nullable: false),
                    ProvicneId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "RoadsideAssistanceServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoadsideAssistanceId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadsideAssistanceServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceServices_RoadsideAssistances_RoadsideAssistanceId",
                        column: x => x.RoadsideAssistanceId,
                        principalTable: "RoadsideAssistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceServices_RServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "RServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopServices_WServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "WServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopServices_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnualTechnicalInspectionRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarDone = table.Column<bool>(nullable: false),
                    BaseRequestId = table.Column<string>(nullable: true),
                    AnnualTechnicalInspectionId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualTechnicalInspectionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualTechnicalInspectionRequests_AnnualTechnicalInspections_AnnualTechnicalInspectionId",
                        column: x => x.AnnualTechnicalInspectionId,
                        principalTable: "AnnualTechnicalInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualTechnicalInspectionRequests_BaseRequests_BaseRequestId",
                        column: x => x.BaseRequestId,
                        principalTable: "BaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarWashRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PickUpLocation = table.Column<string>(nullable: false),
                    PickUpFastAsPossible = table.Column<bool>(nullable: false),
                    AdminChooseCarWash = table.Column<bool>(nullable: false),
                    PickUpTime = table.Column<DateTime>(nullable: true),
                    PickedUp = table.Column<bool>(nullable: false),
                    WashingFinished = table.Column<bool>(nullable: false),
                    ReturnedCar = table.Column<bool>(nullable: false),
                    BaseRequestId = table.Column<string>(nullable: false),
                    CarWashId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWashRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWashRequests_BaseRequests_BaseRequestId",
                        column: x => x.BaseRequestId,
                        principalTable: "BaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarWashRequests_CarWashes_CarWashId",
                        column: x => x.CarWashId,
                        principalTable: "CarWashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    SentOn = table.Column<DateTime>(nullable: false),
                    SentById = table.Column<string>(nullable: true),
                    BaseRequestId = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "InsurersRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InsurenceStart = table.Column<DateTime>(nullable: false),
                    NumberOfInsuranceContributions = table.Column<byte>(nullable: false),
                    BaseRequestId = table.Column<string>(nullable: false),
                    InsurerInsurancesId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurersRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurersRequests_BaseRequests_BaseRequestId",
                        column: x => x.BaseRequestId,
                        principalTable: "BaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsurersRequests_InsurerInsurances_InsurerInsurancesId",
                        column: x => x.InsurerInsurancesId,
                        principalTable: "InsurerInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoadsideAssistanceRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BaseRequestId = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    RoadsideAssistanceProvinceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadsideAssistanceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceRequests_BaseRequests_BaseRequestId",
                        column: x => x.BaseRequestId,
                        principalTable: "BaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceRequests_RoadsideAssistanceProvinces_RoadsideAssistanceProvinceId",
                        column: x => x.RoadsideAssistanceProvinceId,
                        principalTable: "RoadsideAssistanceProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BaseRequestId = table.Column<string>(nullable: false),
                    CarDone = table.Column<bool>(nullable: false),
                    WorkshopServiceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopRequests_BaseRequests_BaseRequestId",
                        column: x => x.BaseRequestId,
                        principalTable: "BaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopRequests_WorkshopServices_WorkshopServiceId",
                        column: x => x.WorkshopServiceId,
                        principalTable: "WorkshopServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_AnnualTechnicalInspectionId",
                table: "AnnualTechnicalInspectionRequests",
                column: "AnnualTechnicalInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_BaseRequestId",
                table: "AnnualTechnicalInspectionRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspections_IsDeleted",
                table: "AnnualTechnicalInspections",
                column: "IsDeleted");

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
                name: "IX_CarExtras_CarId",
                table: "CarExtras",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarExtras_ExtraId",
                table: "CarExtras",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IsDeleted",
                table: "Cars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashes_IsDeleted",
                table: "CarWashes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_BaseRequestId",
                table: "CarWashRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_CarWashId",
                table: "CarWashRequests",
                column: "CarWashId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_IsDeleted",
                table: "Insurances",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsurerInsurances_InsuranceId",
                table: "InsurerInsurances",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurerInsurances_InsurerId",
                table: "InsurerInsurances",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurers_IsDeleted",
                table: "Insurers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_BaseRequestId",
                table: "InsurersRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurersRequests_InsurerInsurancesId",
                table: "InsurersRequests",
                column: "InsurerInsurancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BaseRequestId",
                table: "Messages",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCarUsers_CarId",
                table: "OtherCarUsers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCarUsers_IsDeleted",
                table: "OtherCarUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceProvinces_ProvinceId",
                table: "RoadsideAssistanceProvinces",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceProvinces_RoadsideAssistanceId",
                table: "RoadsideAssistanceProvinces",
                column: "RoadsideAssistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_BaseRequestId",
                table: "RoadsideAssistanceRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_RoadsideAssistanceProvinceId",
                table: "RoadsideAssistanceRequests",
                column: "RoadsideAssistanceProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistances_IsDeleted",
                table: "RoadsideAssistances",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceServices_RoadsideAssistanceId",
                table: "RoadsideAssistanceServices",
                column: "RoadsideAssistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceServices_ServiceId",
                table: "RoadsideAssistanceServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_BaseRequestId",
                table: "WorkshopRequests",
                column: "BaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequests_WorkshopServiceId",
                table: "WorkshopRequests",
                column: "WorkshopServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopServices_ServiceId",
                table: "WorkshopServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopServices_WorkshopId",
                table: "WorkshopServices",
                column: "WorkshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualTechnicalInspectionRequests");

            migrationBuilder.DropTable(
                name: "CarExtras");

            migrationBuilder.DropTable(
                name: "CarWashRequests");

            migrationBuilder.DropTable(
                name: "InsurersRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OtherCarUsers");

            migrationBuilder.DropTable(
                name: "RoadsideAssistanceRequests");

            migrationBuilder.DropTable(
                name: "RoadsideAssistanceServices");

            migrationBuilder.DropTable(
                name: "WorkshopRequests");

            migrationBuilder.DropTable(
                name: "AnnualTechnicalInspections");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "CarWashes");

            migrationBuilder.DropTable(
                name: "InsurerInsurances");

            migrationBuilder.DropTable(
                name: "RoadsideAssistanceProvinces");

            migrationBuilder.DropTable(
                name: "RServices");

            migrationBuilder.DropTable(
                name: "BaseRequests");

            migrationBuilder.DropTable(
                name: "WorkshopServices");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Insurers");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "RoadsideAssistances");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "WServices");

            migrationBuilder.DropTable(
                name: "Workshops");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IsDeleted",
                table: "Settings",
                column: "IsDeleted");
        }
    }
}
