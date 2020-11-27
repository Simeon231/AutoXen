namespace AutoXen.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Price = table.Column<double>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CarDone = table.Column<bool>(nullable: false),
                    AnnualTechnicalInspectionId = table.Column<int>(nullable: false),
                    AcceptedById = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualTechnicalInspectionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualTechnicalInspectionRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualTechnicalInspectionRequests_AnnualTechnicalInspections_AnnualTechnicalInspectionId",
                        column: x => x.AnnualTechnicalInspectionId,
                        principalTable: "AnnualTechnicalInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualTechnicalInspectionRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualTechnicalInspectionRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                name: "CarWashRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PickUpLocation = table.Column<string>(nullable: false),
                    PickUpFastAsPossible = table.Column<bool>(nullable: false),
                    AdminChooseCarWash = table.Column<bool>(nullable: false),
                    PickUpTime = table.Column<DateTime>(nullable: true),
                    PickedUp = table.Column<bool>(nullable: false),
                    WashingFinished = table.Column<bool>(nullable: false),
                    ReturnedCar = table.Column<bool>(nullable: false),
                    CarWashId = table.Column<int>(nullable: true),
                    AcceptedById = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWashRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWashRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarWashRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarWashRequests_CarWashes_CarWashId",
                        column: x => x.CarWashId,
                        principalTable: "CarWashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarWashRequests_AspNetUsers_UserId",
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
                name: "WorkshopRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OtherServices = table.Column<string>(maxLength: 300, nullable: true),
                    CarDone = table.Column<bool>(nullable: false),
                    PickUpLocation = table.Column<string>(maxLength: 150, nullable: false),
                    PickUpFastAsPossible = table.Column<bool>(nullable: false),
                    AdminChooseWorkshop = table.Column<bool>(nullable: false),
                    PickUpTime = table.Column<DateTime>(nullable: true),
                    PickedUp = table.Column<bool>(nullable: false),
                    ReturnedCar = table.Column<bool>(nullable: false),
                    AcceptedById = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsurersRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    InsurenceStart = table.Column<DateTime>(nullable: false),
                    NumberOfInsuranceContributions = table.Column<byte>(nullable: false),
                    InsurerInsurancesId = table.Column<int>(nullable: false),
                    AcceptedById = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_InsurersRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoadsideAssistanceRequests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    RoadsideAssistanceProvinceId = table.Column<int>(nullable: false),
                    AcceptedById = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    FinishedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadsideAssistanceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceRequests_AspNetUsers_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceRequests_RoadsideAssistanceProvinces_RoadsideAssistanceProvinceId",
                        column: x => x.RoadsideAssistanceProvinceId,
                        principalTable: "RoadsideAssistanceProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadsideAssistanceRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopRequestWorkshopServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    WorkshopRequestId = table.Column<string>(nullable: false),
                    WorkshopServiceId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRequestWorkshopServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopRequestWorkshopServices_WorkshopRequests_WorkshopRequestId",
                        column: x => x.WorkshopRequestId,
                        principalTable: "WorkshopRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopRequestWorkshopServices_WorkshopServices_WorkshopServiceId",
                        column: x => x.WorkshopServiceId,
                        principalTable: "WorkshopServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopRequestWServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(nullable: false),
                    WServiceId = table.Column<int>(nullable: true),
                    WorkshopRequestId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRequestWServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopRequestWServices_WServices_WServiceId",
                        column: x => x.WServiceId,
                        principalTable: "WServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopRequestWServices_WorkshopRequests_WorkshopRequestId",
                        column: x => x.WorkshopRequestId,
                        principalTable: "WorkshopRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_AcceptedById",
                table: "AnnualTechnicalInspectionRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspectionRequests_AnnualTechnicalInspectionId",
                table: "AnnualTechnicalInspectionRequests",
                column: "AnnualTechnicalInspectionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AnnualTechnicalInspections_IsDeleted",
                table: "AnnualTechnicalInspections",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_IsDeleted",
                table: "AspNetRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_CarWashRequests_AcceptedById",
                table: "CarWashRequests",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_CarId",
                table: "CarWashRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_CarWashId",
                table: "CarWashRequests",
                column: "CarWashId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_IsDeleted",
                table: "CarWashRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashRequests_UserId",
                table: "CarWashRequests",
                column: "UserId");

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
                name: "IX_RoadsideAssistanceRequests_RoadsideAssistanceProvinceId",
                table: "RoadsideAssistanceRequests",
                column: "RoadsideAssistanceProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadsideAssistanceRequests_UserId",
                table: "RoadsideAssistanceRequests",
                column: "UserId");

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
                name: "IX_WorkshopRequestWorkshopServices_WorkshopRequestId",
                table: "WorkshopRequestWorkshopServices",
                column: "WorkshopRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequestWorkshopServices_WorkshopServiceId",
                table: "WorkshopRequestWorkshopServices",
                column: "WorkshopServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequestWServices_WServiceId",
                table: "WorkshopRequestWServices",
                column: "WServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRequestWServices_WorkshopRequestId",
                table: "WorkshopRequestWServices",
                column: "WorkshopRequestId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarExtras");

            migrationBuilder.DropTable(
                name: "CarWashRequests");

            migrationBuilder.DropTable(
                name: "InsurersRequests");

            migrationBuilder.DropTable(
                name: "OtherCarUsers");

            migrationBuilder.DropTable(
                name: "RoadsideAssistanceRequests");

            migrationBuilder.DropTable(
                name: "RoadsideAssistanceServices");

            migrationBuilder.DropTable(
                name: "WorkshopRequestWorkshopServices");

            migrationBuilder.DropTable(
                name: "WorkshopRequestWServices");

            migrationBuilder.DropTable(
                name: "AnnualTechnicalInspections");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "WorkshopServices");

            migrationBuilder.DropTable(
                name: "WorkshopRequests");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Insurers");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "RoadsideAssistances");

            migrationBuilder.DropTable(
                name: "WServices");

            migrationBuilder.DropTable(
                name: "Workshops");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
