using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xcelerate.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.AccessoryId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false, comment: "AddressId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "CountryName"),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "TownName"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "StreetName")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "FirstName"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "LastName"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<int>(type: "int", nullable: false, comment: "EngineId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Model"),
                    Horsepower = table.Column<int>(type: "int", nullable: false, comment: "Horsepower"),
                    CylinderCount = table.Column<int>(type: "int", nullable: false, comment: "CylinderCount"),
                    FuelType = table.Column<int>(type: "int", nullable: false, comment: "FuelType")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false, comment: "ManufacturerId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "StatisticalData",
                columns: table => new
                {
                    StatisticId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoldCars = table.Column<int>(type: "int", nullable: false),
                    CreatedCars = table.Column<int>(type: "int", nullable: false),
                    CreatedReviews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalData", x => x.StatisticId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false, comment: "CarId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<int>(type: "int", nullable: false, comment: "Brand"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Model"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year"),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false, comment: "Condition"),
                    EuroStandard = table.Column<int>(type: "int", nullable: false, comment: "EuroStandard"),
                    Colour = table.Column<int>(type: "int", nullable: false, comment: "Colour"),
                    Transmission = table.Column<int>(type: "int", nullable: false, comment: "Transmition"),
                    DriveTrain = table.Column<int>(type: "int", nullable: false, comment: "DriveTrain"),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Weight"),
                    Mileage = table.Column<int>(type: "int", nullable: false, comment: "Mileage"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price"),
                    BodyType = table.Column<int>(type: "int", nullable: false, comment: "BodyType"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsForSale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId");
                    table.ForeignKey(
                        name: "FK_Cars_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId");
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    AdId = table.Column<int>(type: "int", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.AdId);
                    table.ForeignKey(
                        name: "FK_Ads_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ads_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId");
                });

            migrationBuilder.CreateTable(
                name: "CarAccessories",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAccessories", x => new { x.AccessoryId, x.CarId });
                    table.ForeignKey(
                        name: "FK_CarAccessories_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "AccessoryId");
                    table.ForeignKey(
                        name: "FK_CarAccessories_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false, comment: "ReviewId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Comment"),
                    StarsCount = table.Column<int>(type: "int", nullable: false, comment: "StarsCount"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "AdId");
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "AccessoryId", "Name" },
                values: new object[,]
                {
                    { 1, "GpsTrackingSystem" },
                    { 2, "AutomaticStabilityControl" },
                    { 3, "AdaptiveHeadlights" },
                    { 4, "Abs" },
                    { 5, "RearAirbags" },
                    { 6, "FrontAirbags" },
                    { 7, "SideAirbags" },
                    { 8, "Ebd" },
                    { 9, "Esp" },
                    { 10, "Tpms" },
                    { 11, "Parktronic" },
                    { 12, "Isofix" },
                    { 13, "DynamicStabilityControl" },
                    { 14, "Tcs" },
                    { 15, "DistanceControlSystem" },
                    { 16, "DescentControlSystem" },
                    { 17, "Bas" },
                    { 18, "AutoStartStopFunction" },
                    { 19, "BluetoothHandsfreeSystem" },
                    { 20, "DvdTv" },
                    { 21, "SteptronicTiptronic" },
                    { 22, "UsbAudioVideoInAuxOutputs" },
                    { 23, "AdaptiveAirSuspension" },
                    { 24, "KeylessIgnition" },
                    { 25, "DifferentialLock" },
                    { 26, "OnBoardComputer" },
                    { 27, "LightSensor" },
                    { 28, "ElectricMirrors" },
                    { 29, "ElectricGlass" },
                    { 30, "ElectricSuspensionAdjustment" },
                    { 31, "ElectricSeatAdjustment" },
                    { 32, "ElectricPowerSteering" },
                    { 33, "AirConditioner" },
                    { 34, "Climatronic" },
                    { 35, "MultifunctionSteeringWheel" },
                    { 36, "NavigationSystem" },
                    { 37, "SteeringWheelHeating" },
                    { 38, "WindshieldHeating" },
                    { 39, "SeatHeating" },
                    { 40, "SteeringWheelAdjustment" },
                    { 41, "RainSensor" },
                    { 42, "PowerSteering" }
                });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "AccessoryId", "Name" },
                values: new object[,]
                {
                    { 43, "HeadlampWashSystem" },
                    { 44, "CruiseControlSystem" },
                    { 45, "StereoSystem" },
                    { 46, "CoolingGlovebox" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "CountryName", "StreetName", "TownName" },
                values: new object[,]
                {
                    { 1, "Bulgaria", "Ivan Vazov", "Pernik" },
                    { 2, "Italy", "Via del Corso", "Rome" },
                    { 3, "France", "Champs-Élysées", "Paris" },
                    { 4, "USA", "Broadway", "New York" },
                    { 5, "Japan", "Shibuya Crossing", "Tokyo" },
                    { 6, "Australia", "George Street", "Sydney" },
                    { 7, "Canada", "Yonge Street", "Toronto" },
                    { 8, "Germany", "Unter den Linden", "Berlin" },
                    { 9, "Spain", "La Rambla", "Barcelona" },
                    { 10, "United Kingdom", "Oxford Street", "London" },
                    { 11, "United States", "Broadway", "New York City" },
                    { 12, "Canada", "Yonge Street", "Toronto" },
                    { 13, "Australia", "George Street", "Sydney" },
                    { 14, "Germany", "Kurfürstendamm", "Berlin" },
                    { 15, "Italy", "Via del Corso", "Rome" },
                    { 16, "Spain", "Passeig de Gràcia", "Barcelona" },
                    { 17, "France", "Champs-Élysées", "Paris" },
                    { 18, "Australia", "George Street", "Sydney" },
                    { 19, "Canada", "Yonge Street", "Toronto" },
                    { 20, "Italy", "Via Veneto", "Rome" },
                    { 21, "United States", "Broadway", "New York City" },
                    { 22, "Germany", "Kurfürstendamm", "Berlin" },
                    { 23, "Japan", "Shibuya Crossing", "Tokyo" },
                    { 24, "Brazil", "Avenida Atlântica", "Rio de Janeiro" },
                    { 25, "South Africa", "Long Street", "Cape Town" },
                    { 26, "Canada", "Granville Street", "Vancouver" },
                    { 27, "Spain", "Gran Vía", "Madrid" },
                    { 28, "United Kingdom", "Oxford Street", "London" },
                    { 29, "Italy", "Grand Canal", "Venice" },
                    { 30, "Australia", "Collins Street", "Melbourne" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"), 0, "04e7c52f-0b4f-4c63-8f80-96ea06de0e74", "grace.taylor@example.com", false, "Grace", "Taylor", false, null, null, null, "AQAAAAEAACcQAAAAEOiT1rwnt2+2PkbTrCP9RM5Qe5GQ73zcBFZFBBBy+StxCjT2I06G9S9iCMS4vZ15lQ==", null, false, null, false, null },
                    { new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"), 0, "354a53a1-fc1f-4fd6-8ff9-ccbf5f09c76b", "jack.anderson@example.com", false, "Jack", "Anderson", false, null, null, null, "AQAAAAEAACcQAAAAEOz5aTbv83Km0vRXgu72O5rzMzNSZ5ZzBx6RgoupaDkJ+tBbPYvA+nEgM/sPQoSfuQ==", null, false, null, false, null },
                    { new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"), 0, "4d583b74-fb6e-4843-afa6-b1ddc28ee090", "bob.johnson@example.com", false, "Bob", "Johnson", false, null, null, null, "AQAAAAEAACcQAAAAELJ/pOEI0BLdNiGnMkoVM8GZDH6mxH4af4tUNmV5Wk0r7z0L8pT4u/7bPrOvdaGDlw==", null, false, null, false, null },
                    { new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"), 0, "ecf68b6a-4e55-4d5a-b9f2-2993f13d7f50", "david.brown@example.com", false, "David", "Brown", false, null, null, null, "AQAAAAEAACcQAAAAEL73MKLmRxmxRDdAU7i6p5F39m4hKFpEiHKdi6V8/I92pG2SHy4BxUPzwXWNMJqS+A==", null, false, null, false, null },
                    { new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"), 0, "0dd6348a-f0cf-4b46-9555-5150c2624381", "charlie.williams@example.com", false, "Charlie", "Williams", false, null, null, null, "AQAAAAEAACcQAAAAEF6JUXv+KeqWYwkV7TvDV/9KDmIVIFzCjw+S3nkWWIGar3UYwYsPjtmHcst61pORFA==", null, false, null, false, null },
                    { new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"), 0, "3eb4f965-96f4-4dd3-a491-abcc0694628e", "frank.davis@example.com", false, "Frank", "Davis", false, null, null, null, "AQAAAAEAACcQAAAAECgDuhgWYtcgtaIwMP6xT51Wj2YnIzGS7e4i1rVXpZCmEg1ZAwYiWp25ymySLH5oLg==", null, false, null, false, null },
                    { new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"), 0, "1e089189-51fc-4e69-9e54-4e49340130d3", "alice.smith@example.com", false, "Alice", "Smith", false, null, null, null, "AQAAAAEAACcQAAAAEMjI+lh6sJA7H5dmkXtE2s4mO/a2aBVVTSSjw6BqIxijGrjLmK26bJhbuHQi37Paig==", null, false, null, false, null },
                    { new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"), 0, "2b83a205-2d11-4b26-89b5-156457401311", "eva.miller@example.com", false, "Eva", "Miller", false, null, null, null, "AQAAAAEAACcQAAAAEAguhSaiN7sZXpqtSplfVcN382yje5tS3aFKIHOoSHIt0dclfNDI/ZA1O2z9ODNXHA==", null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"), 0, "17e7caea-8fc7-4851-a4c0-df080b789433", "ivy.walker@example.com", false, "Ivy", "Walker", false, null, null, null, "AQAAAAEAACcQAAAAEDhFl85IEArfiVCi6dpcWSALHKD4CrUHOLHq/Qk33UhdIDfBW4jPDJBvfQsLuPKQTA==", null, false, null, false, null },
                    { new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"), 0, "8ce18cce-7853-4f36-abac-bb9d644b37a2", "henry.clark@example.com", false, "Henry", "Clark", false, null, null, null, "AQAAAAEAACcQAAAAEFic9bgqgG50Yj+K9pG58lcO4Jd7bNvnkJPb2Me4sVMnsH5KsLOBc0NUEydya3VJdQ==", null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "EngineId", "CylinderCount", "FuelType", "Horsepower", "Model" },
                values: new object[,]
                {
                    { 1, 6, 1, 301, "V6" },
                    { 2, 4, 1, 306, "In-Line 4-Cylinder with Turbocharger" },
                    { 3, 8, 2, 526, "5.2-liter V-8 engine" },
                    { 4, 4, 1, 147, "1.4L Turbo Inline-4" },
                    { 5, 4, 1, 255, "Turbocharged 2.0" },
                    { 6, 4, 1, 306, "2.0" },
                    { 7, 8, 1, 400, "5.6-liter V-8 " },
                    { 8, 4, 1, 147, "Turbocharged N Line" },
                    { 9, 6, 2, 473, "Twin-turbo 3.0-liter inline-six" },
                    { 10, 4, 2, 181, "2.5" },
                    { 11, 8, 1, 60, "V8" },
                    { 12, 8, 1, 320, "5.3L" },
                    { 13, 8, 2, 260, "5.4L" },
                    { 14, 4, 2, 85, "EDC 1.4" },
                    { 15, 12, 1, 389, "S600L" },
                    { 16, 4, 1, 210, "DOHC i-VTEC 2.0" },
                    { 17, 6, 1, 290, "3.2L DOHC" },
                    { 18, 6, 1, 200, "B204R" },
                    { 19, 6, 1, 185, "B204L" },
                    { 20, 16, 1, 225, "2.0L" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Honda" },
                    { 3, "Ford" },
                    { 4, "Volkswagen" },
                    { 5, "Mercedes-Benz" },
                    { 6, "Audi" },
                    { 7, "Infiniti" },
                    { 8, "Hyundai" },
                    { 9, "BMW" },
                    { 10, "Nissan" },
                    { 11, "Chevrolet" },
                    { 12, "Chevrolet" },
                    { 13, "Ford" },
                    { 14, "Renault" },
                    { 15, "Mercedes-Benz" },
                    { 16, "Acura" },
                    { 17, "Acura" },
                    { 18, "Saab" },
                    { 19, "Saab" },
                    { 20, "Renault" }
                });

            migrationBuilder.InsertData(
                table: "StatisticalData",
                columns: new[] { "StatisticId", "CreatedCars", "CreatedReviews", "SoldCars" },
                values: new object[] { 1, 210, 88, 160 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "AdId", "AddressId", "BodyType", "Brand", "Colour", "Condition", "DriveTrain", "EngineId", "EuroStandard", "IsForSale", "ManufacturerId", "Mileage", "Model", "Price", "Transmission", "UserId", "Weight", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 99, 1, 2, 1, 1, 4, true, 1, 30000, "Camry TRD", 25000m, 2, new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"), 1623.5m, 2020 },
                    { 2, 2, 2, 4, 41, 6, 1, 1, 2, 6, true, 2, 15000, "Civic Type R", 62000m, 1, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"), 1395.75m, 2021 },
                    { 3, 3, 3, 1, 34, 1, 2, 2, 3, 6, true, 3, 25000, "Mustang GT350R", 30000m, 2, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"), 1600.25m, 2020 },
                    { 4, 4, 4, 4, 102, 1, 2, 1, 4, 5, true, 4, 20000, "Golf", 18000m, 1, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"), 1400.75m, 2019 },
                    { 5, 5, 5, 1, 67, 22, 1, 3, 5, 6, true, 5, 10000, "C-Class", 40000m, 2, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"), 1800.5m, 2022 },
                    { 6, 6, 6, 1, 9, 3, 2, 1, 6, 6, true, 6, 30000, "A3", 28000m, 2, new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"), 1500.25m, 2022 },
                    { 7, 7, 7, 6, 47, 22, 2, 3, 7, 2, true, 7, 25000, "QX80", 35000m, 2, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"), 2000.0m, 2022 },
                    { 8, 8, 8, 1, 44, 3, 1, 1, 8, 5, true, 8, 15000, "Elantra", 23000m, 2, new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"), 1400.5m, 2021 },
                    { 9, 9, 9, 1, 12, 22, 2, 3, 9, 1, true, 9, 320000, "3 Series", 42000m, 2, new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"), 1700.0m, 2022 },
                    { 10, 10, 10, 6, 73, 3, 2, 1, 10, 4, true, 10, 18000, "Rogue", 28000m, 2, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"), 1600.75m, 2021 },
                    { 11, 11, 11, 6, 18, 5, 2, 2, 11, 2, true, 11, 310000, "El Camino SS", 308000m, 1, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"), 1742.85m, 1969 },
                    { 12, 12, 12, 6, 18, 1, 2, 4, 12, 3, true, 12, 230000, "Tahoe", 30000m, 2, new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"), 2583.05m, 2013 },
                    { 13, 13, 13, 6, 34, 2, 2, 4, 13, 2, true, 13, 190000, " F-350 Super Duty", 42000m, 1, new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"), 1353.05m, 2000 },
                    { 14, 14, 14, 4, 81, 3, 1, 4, 14, 5, true, 14, 10000, "Clio", 22000m, 1, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"), 1240.55m, 2013 },
                    { 15, 15, 15, 1, 67, 2, 1, 2, 15, 3, true, 15, 40186, "W140", 280000m, 1, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"), 1240.55m, 1998 },
                    { 16, 16, 16, 2, 3, 3, 2, 1, 16, 3, true, 16, 100200, "RSX Type-S", 80000m, 1, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"), 1420.15m, 2005 },
                    { 17, 17, 17, 1, 3, 5, 2, 2, 16, 4, true, 17, 210000, "NSX", 230000m, 2, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"), 1510.25m, 2005 },
                    { 18, 18, 18, 1, 87, 22, 2, 1, 18, 3, true, 18, 170000, "9-3 Aero", 50000m, 1, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"), 1710.25m, 2001 },
                    { 19, 19, 19, 5, 87, 1, 2, 1, 19, 4, true, 19, 152000, "93 SportCombi", 70000m, 1, new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"), 1810.15m, 2006 },
                    { 20, 20, 20, 2, 81, 13, 2, 1, 20, 5, true, 20, 213000, "Megane II", 40000m, 1, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"), 1510.15m, 2003 }
                });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "AdId", "CarDescription", "CarId", "CreatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, "The 2020 Toyota Camry TRD is a sporty, performance-oriented version of the long-standing mid-size sedan1. It’s the first Camry that could be construed as \"sporty\".\nPerformance The TRD’s front brake rotors are larger than those on the next-sportiest Camry, the XSE V-6 model, and are squeezed by two-piston calipers instead of single-piston units. It’s equipped with stiffer springs and larger-diameter anti-roll bars, stiffer underbody braces, and a V-brace behind the rear seats.", 1, "2024-10-02", new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e") },
                    { 2, "The 2021 Honda Civic Type R Limited Edition is a high-performance, four-door hatchback that stands out in its class. Despite its bold and somewhat juvenile bodywork, it offers a transformative driving experience, volcanic acceleration, and is entirely practical for daily use.\r\n\r\nThe car is powered by a 306-hp turbocharged four-cylinder engine and a six-speed manual transmission, making it one of the quickest sport compacts. Honda has managed to virtually eliminate the dreaded torque steer that plagues powerful front-drive cars, providing talkative steering, tremendous cornering grip, and a ride that’s surprisingly smooth", 2, "2018-10-02", new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 3, "The 2020 Ford Mustang Shelby GT350R is a powerful, high-strung muscle car designed to rock race tracks while still being at home on the street. Its special 5.2-liter V-8 engine, code-named Voodoo, makes 526 horsepower and revs to a dizzying 8250 rpm. The GT350R has been designed to handle cornering at race-track speeds without being too harsh on the street. It’s equipped with a tautly tuned suspension and robust brakes.", 3, "2024-15-07", new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 4, "The 2020 Volkswagen Golf TSI is a compact hatchback that offers a blend of performance, comfort, and practicality. It’s powered by a 1.4L Turbo Inline-4 Gas engine that produces 147 horsepower at 5000 rpm and 184 lb-ft of torque at 1400 rpm. The Golf is fun to drive with well-calibrated transmissions and confident in corners. It’s not as fast as its sportier GTI counterpart, but it’s still enjoyable to drive.", 4, "2024-22-04", new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 5, "The 2022 Mercedes-Benz C-Class is a luxury sedan that has been fully redesigned for the year. It’s a far cry from where the model started out almost 30 years ago. With smaller and more affordable vehicles supporting it, the C-Class is more of a middleweight luxury sedan than an entry-level taste of the brand.", 5, "2024-08-09", new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf") },
                    { 6, "The 2022 Audi S3 is a compact luxury sedan that has been fully redesigned for the year. It finds an admirable middle ground between the more conventional A3 and higher-performing RS 3, both in terms of price and personality.\r\n\r\nWith 306 horsepower and all-wheel drive as standard, the S3 is a big step up from the 201-hp A3 and a sensible alternative to the RS 3’s monster 401 hp. Despite being Audi’s entry-level vehicles, the A3 and S3 deliver a healthy dose of modern luxury and tech features.", 6, "2024-27-06", new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea") },
                    { 7, "The 2022 Infiniti QX80 is a large, three-row, luxury SUV. It has an attractive and upscale look, a sturdily built interior, and a smooth ride. Here are some key features and specifications:\r\n\r\nEngine: It is powered by a 400-hp 5.6-liter V-8 engine, paired with a seven-speed automatic transmission.\r\nPerformance: The QX80’s engine provides smooth power delivery and snappy throttle response. It can go from zero to 60 mph in 5.9 seconds.\r\nFuel Efficiency: It has a fuel efficiency of 14/20 MPG city/highway.", 7, "2024-14-12", new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 8, "The 2021 Hyundai Elantra is a compact sedan that has been redesigned with modern exterior and interior styling, and more advanced technology features. Here are some key features and specifications:\r\n\r\nEngine: The standard non-hybrid powertrain is a 147-hp four-cylinder engine. There’s also a 201-hp turbocharged N Line model and an available hybrid powertrain.\r\nPerformance: The Elantra offers good ride quality and enough pep for normal city and highway driving. The performance-oriented N Line model provides perkier acceleration and adept handling.\r\nFuel Efficiency: The Elantra Hybrid earned an EPA rating as high as 56 mpg highway.", 8, "2024-18-05", new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c") },
                    { 9, "The 2022 BMW M3 is a high-performance sedan that offers thrilling powertrains and a satisfying manual gearbox. Here are some key features and specifications:\r\n\r\nEngine: The M3 features a twin-turbo 3.0-liter inline-six engine. The standard version delivers 473 horsepower and 406 pound-feet of torque.\r\nPerformance: The M3 is known for its thrilling powertrains and drivability. The standard M3 is rear-wheel drive and comes with a manual gearbox. The Competition model has an enhanced engine with 503 horsepower and a track-tuned chassis.", 9, "2024-09-01", new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0") },
                    { 10, "The 2021 Nissan Rogue is a compact SUV that has been redesigned with modern exterior and interior styling, and more advanced technology features. Here are some key features and specifications:\r\n\r\nEngine: The 2021 model is powered by a 2.5-liter four-cylinder engine. It has received a slight power bump to 181 horsepower.\r\nPerformance: The Rogue offers good ride quality and enough pep for normal city and highway driving. It has improved in both acceleration and handling.\r\nFuel Efficiency: The EPA estimates that front-wheel drive Rogues should deliver up to 27 mpg city and 35 mpg highway.", 10, "2024-25-02", new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 11, "\r\nThe 1969 El Camino SS stands as a pinnacle of American muscle car heritage. With its commanding V8 engine, striking design, and dual-purpose utility, it embodies the essence of power and versatility. A timeless icon revered by enthusiasts, it continues to captivate with its enduring charisma and formidable performance.", 11, "2023-15-03", new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 12, "The 2013 Chevrolet Tahoe is a formidable full-size SUV, boasting a robust 5.3-liter V8 engine that delivers ample power and towing capability. With spacious seating for up to nine passengers, versatile cargo space, and advanced safety features, it combines comfort, utility, and performance for an exhilarating driving experience on and off the road.", 12, "2022-13-09", new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c") },
                    { 13, "The 2000 Ford F-350 Super Duty epitomizes rugged reliability and unmatched towing prowess. With a range of potent engine options, robust construction, and expansive payload capacity, it's a workhorse designed to tackle the toughest jobs. Its durable build and versatile design make it a cornerstone of Ford's truck lineup.", 13, "2020-03-10", new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea") },
                    { 14, "The 2013 Renault Clio embodies sleek style and urban practicality. Renowned for its fuel efficiency and nimble handling, it's perfect for city driving. With a modern interior, advanced features, and a range of efficient engines, the Clio offers a comfortable and enjoyable ride for drivers seeking both style and substance.", 14, "2019-07-12", new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 15, "\r\nThe model series 140 S-Class, introduced in 1991, achieved remarkable success on various fronts. Initial critiques in Germany regarding its external dimensions have since faded, especially as modern vehicles have grown in size and weight. Interestingly, Mercedes-Benz customers in the USA and Asia embraced the S-Class enthusiastically. This model captivated with its innovative design, advanced features, and unmatched spaciousness and comfort, demonstrating the evolving preferences and global acceptance of luxury vehicles over the past three decades.", 15, "2019-03-02", new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 16, "The 2005 Acura Type-S saw modifications to its 2.0-liter i-VTEC engine, boosting power to 210 hp at 7800 rpm and torque to 143 lb-ft at 7000 rpm. It exclusively features a close-ratio 6-speed manual transmission, with lowered final gear ratio for quicker acceleration and improved shift feel.", 16, "2013-04-10", new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 17, "\r\nThe Acura NSX epitomizes precision-crafted performance, combining world-class styling with exceptional drivability and refinement. Offering two distinct powertrains, including a lightweight, all-aluminum V6 engine coupled with a 6-speed manual transmission, it delivers exhilarating performance. With advanced features like Variable Valve Timing and Lift Electronic Control (VTEC™) and a sophisticated chassis, the NSX sets the benchmark for Acura's high-performance lineup.", 17, "2021-05-11", new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 18, "Experience the thrill of the Saab 9-3 Aero, where performance meets innovation. With turbocharged power under the hood and dynamic handling at your fingertips, every drive becomes an exhilarating adventure. Safety is paramount with standard side impact airbags, while innovations like the 'Night Panel' ensure a focused driving experience. Discover the ultimate blend of style and performance today.", 18, "2023-10-09", new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 19, "Unleash the spirit of adventure with the Saab 9-3 SportCombi. Designed for those who crave versatility and style, this compact executive car embodies Scandinavian elegance. From its agile performance to its cutting-edge safety features, the 93 SportCombi is ready to elevate your driving experience. Explore the road with confidence and flair.", 19, "2018-10-09", new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0") },
                    { 20, "Revolutionize your drive with the Mégane II – a true embodiment of Renault's bold new style. Winner of European Car Of The Year 2003, this car sets the standard for safety and innovation. With its sleek design and cutting-edge technologies like the Renault Card keyless ignition system, every journey becomes an adventure. Explore the road with confidence and style.", 20, "2020-10-09", new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 18 },
                    { 1, 19 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 18 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 18 },
                    { 3, 19 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 18 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 11 },
                    { 5, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 5, 16 },
                    { 5, 18 },
                    { 5, 19 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 18 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 6, 20 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 6 },
                    { 7, 7 },
                    { 7, 8 },
                    { 7, 9 },
                    { 7, 10 },
                    { 7, 11 },
                    { 7, 12 },
                    { 7, 13 },
                    { 7, 14 },
                    { 7, 15 },
                    { 7, 16 },
                    { 7, 18 },
                    { 7, 19 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 8, 6 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 8, 12 },
                    { 8, 13 },
                    { 8, 14 },
                    { 8, 15 },
                    { 8, 16 },
                    { 8, 18 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 5 },
                    { 9, 8 },
                    { 9, 10 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 9, 11 },
                    { 9, 12 },
                    { 9, 13 },
                    { 9, 14 },
                    { 9, 15 },
                    { 9, 16 },
                    { 9, 20 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 5 },
                    { 10, 6 },
                    { 10, 7 },
                    { 10, 8 },
                    { 10, 9 },
                    { 10, 10 },
                    { 10, 11 },
                    { 10, 12 },
                    { 10, 13 },
                    { 10, 14 },
                    { 10, 15 },
                    { 10, 16 },
                    { 10, 19 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 4 },
                    { 11, 6 },
                    { 11, 9 },
                    { 11, 18 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 12, 5 },
                    { 12, 7 },
                    { 12, 8 },
                    { 12, 10 },
                    { 12, 11 },
                    { 12, 12 },
                    { 12, 13 },
                    { 12, 14 },
                    { 12, 15 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 12, 16 },
                    { 12, 18 },
                    { 12, 20 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 4 },
                    { 13, 5 },
                    { 13, 6 },
                    { 13, 9 },
                    { 13, 18 },
                    { 13, 19 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 4 },
                    { 14, 5 },
                    { 14, 6 },
                    { 14, 7 },
                    { 14, 8 },
                    { 14, 10 },
                    { 14, 11 },
                    { 14, 12 },
                    { 14, 13 },
                    { 14, 14 },
                    { 14, 15 },
                    { 14, 16 },
                    { 14, 18 },
                    { 14, 20 },
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 3 },
                    { 15, 4 },
                    { 15, 7 },
                    { 15, 9 },
                    { 15, 10 },
                    { 15, 11 },
                    { 15, 12 },
                    { 15, 13 },
                    { 15, 14 },
                    { 15, 15 },
                    { 15, 16 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 15, 19 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 5 },
                    { 16, 6 },
                    { 16, 8 },
                    { 16, 10 },
                    { 16, 11 },
                    { 16, 12 },
                    { 16, 13 },
                    { 16, 14 },
                    { 16, 15 },
                    { 16, 16 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 17, 6 },
                    { 17, 19 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 3 },
                    { 18, 4 },
                    { 18, 5 },
                    { 18, 7 },
                    { 18, 8 },
                    { 18, 9 },
                    { 18, 10 },
                    { 18, 11 },
                    { 18, 12 },
                    { 18, 13 },
                    { 18, 14 },
                    { 18, 15 },
                    { 18, 16 },
                    { 18, 20 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 3 },
                    { 19, 5 },
                    { 19, 6 },
                    { 19, 8 },
                    { 19, 9 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 19, 10 },
                    { 19, 11 },
                    { 19, 12 },
                    { 19, 13 },
                    { 19, 14 },
                    { 19, 15 },
                    { 19, 16 },
                    { 19, 19 },
                    { 20, 1 },
                    { 20, 3 },
                    { 20, 6 },
                    { 20, 7 },
                    { 20, 18 },
                    { 21, 7 },
                    { 21, 9 },
                    { 21, 17 },
                    { 21, 18 },
                    { 22, 2 },
                    { 22, 4 },
                    { 22, 5 },
                    { 22, 6 },
                    { 22, 8 },
                    { 22, 9 },
                    { 22, 10 },
                    { 22, 11 },
                    { 22, 12 },
                    { 22, 13 },
                    { 22, 14 },
                    { 22, 15 },
                    { 22, 16 },
                    { 22, 17 },
                    { 22, 18 },
                    { 22, 20 },
                    { 23, 7 },
                    { 23, 17 },
                    { 24, 20 },
                    { 25, 2 },
                    { 25, 4 },
                    { 25, 17 },
                    { 26, 6 },
                    { 26, 7 },
                    { 26, 8 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 26, 9 },
                    { 26, 10 },
                    { 26, 11 },
                    { 26, 12 },
                    { 26, 13 },
                    { 26, 14 },
                    { 26, 15 },
                    { 26, 16 },
                    { 26, 17 },
                    { 26, 20 },
                    { 27, 5 },
                    { 27, 6 },
                    { 27, 8 },
                    { 27, 10 },
                    { 27, 11 },
                    { 27, 12 },
                    { 27, 13 },
                    { 27, 14 },
                    { 27, 15 },
                    { 27, 16 },
                    { 27, 17 },
                    { 28, 4 },
                    { 28, 9 },
                    { 28, 17 },
                    { 29, 7 },
                    { 29, 17 },
                    { 30, 4 },
                    { 30, 5 },
                    { 30, 8 },
                    { 30, 9 },
                    { 30, 19 },
                    { 31, 5 },
                    { 31, 6 },
                    { 31, 17 },
                    { 31, 20 },
                    { 32, 18 },
                    { 33, 4 },
                    { 33, 6 },
                    { 33, 7 },
                    { 33, 8 },
                    { 33, 10 },
                    { 33, 11 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 33, 12 },
                    { 33, 13 },
                    { 33, 14 },
                    { 33, 15 },
                    { 33, 16 },
                    { 33, 17 },
                    { 33, 20 },
                    { 35, 5 },
                    { 35, 6 },
                    { 35, 7 },
                    { 35, 8 },
                    { 35, 9 },
                    { 35, 10 },
                    { 35, 11 },
                    { 35, 12 },
                    { 35, 13 },
                    { 35, 14 },
                    { 35, 15 },
                    { 35, 16 },
                    { 35, 17 },
                    { 35, 20 },
                    { 36, 4 },
                    { 36, 5 },
                    { 36, 17 },
                    { 36, 18 },
                    { 37, 7 },
                    { 37, 9 },
                    { 37, 19 },
                    { 38, 17 },
                    { 38, 20 },
                    { 39, 4 },
                    { 39, 6 },
                    { 40, 5 },
                    { 40, 8 },
                    { 40, 10 },
                    { 40, 11 },
                    { 40, 12 },
                    { 40, 13 },
                    { 40, 14 },
                    { 40, 15 },
                    { 40, 16 },
                    { 40, 17 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 40, 20 },
                    { 41, 4 },
                    { 41, 7 },
                    { 42, 6 },
                    { 42, 9 },
                    { 42, 19 },
                    { 43, 17 },
                    { 43, 20 },
                    { 44, 19 },
                    { 45, 4 },
                    { 45, 5 },
                    { 45, 7 },
                    { 45, 8 },
                    { 45, 9 },
                    { 45, 10 },
                    { 45, 11 },
                    { 45, 12 },
                    { 45, 13 },
                    { 45, 14 },
                    { 45, 15 },
                    { 45, 16 },
                    { 45, 18 },
                    { 45, 19 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CarId", "ImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "2020_toyota_camry_trd_1.jpg" },
                    { 2, 1, "2020_toyota_camry_trd_3.jpg" },
                    { 3, 1, "2020_toyota_camry_trd_5.jpg" },
                    { 4, 1, "2020_toyota_camry_trd_6.jpg" },
                    { 5, 1, "2020_toyota_camry_trd_7.jpg" },
                    { 6, 1, "2020_toyota_camry_trd_11.jpg" },
                    { 7, 2, "2021_honda_civic_type_r_limited_edition.jpg" },
                    { 8, 2, "2021_honda_civic_type_r_limited_edition_2.jpg" },
                    { 9, 2, "2021_honda_civic_type_r_limited_edition_3.jpg" },
                    { 10, 2, "2021_honda_civic_type_r_limited_edition_4.jpg" },
                    { 11, 2, "2021_honda_civic_type_r_limited_edition_5.jpg" },
                    { 12, 2, "2021_honda_civic_type_r_limited_edition_11.jpg" },
                    { 13, 3, "2020_ford_mustang_shelby_gt350r.jpg" },
                    { 14, 3, "2020_ford_mustang_shelby_gt350r_1.jpg" },
                    { 15, 3, "2020_ford_mustang_shelby_gt350r_2.jpg" },
                    { 16, 3, "2020_ford_mustang_shelby_gt350r_3.jpg" },
                    { 17, 3, "2020_ford_mustang_shelby_gt350r_5.jpg" },
                    { 18, 3, "2020_ford_mustang_shelby_gt350r_7.jpg" },
                    { 19, 4, "2020_volkswagen_golf.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CarId", "ImageUrl" },
                values: new object[,]
                {
                    { 20, 4, "2020_volkswagen_golf_47.jpg" },
                    { 21, 4, "2020_volkswagen_golf_48.jpg" },
                    { 22, 4, "2020_volkswagen_golf_50.jpg" },
                    { 23, 4, "2020_volkswagen_golf_51.jpg" },
                    { 24, 4, "2020_volkswagen_golf_23.jpg" },
                    { 25, 5, "2022-Mercedes-Benz-C-Class.jpg" },
                    { 26, 5, "2022-Mercedes-Benz-C-Class 2.jpg" },
                    { 27, 5, "2022-Mercedes-Benz-C-Class 3.jpg" },
                    { 28, 5, "2022-Mercedes-Benz-C-Class 4.jpg" },
                    { 29, 5, "2022-Mercedes-Benz-C-Class 5.jpg" },
                    { 30, 5, "2022-Mercedes-Benz-C-Class 6.jpg" },
                    { 31, 6, "2021_audi_s3_6.jpg" },
                    { 32, 6, "2021_audi_s3_5.jpg" },
                    { 33, 6, "2021_audi_s3_10.jpg" },
                    { 34, 6, "2021_audi_s3_11.jpg" },
                    { 35, 6, "2021_audi_s3_12.jpg" },
                    { 36, 6, "2021_audi_s3_15.jpg" },
                    { 37, 7, "2022_infiniti_qx80_1.jpg" },
                    { 38, 7, "2022_infiniti_qx80_11.jpg" },
                    { 39, 7, "2022_infiniti_qx80_12.jpg" },
                    { 40, 7, "2022_infiniti_qx80_13.jpg" },
                    { 41, 7, "2022_infiniti_qx80_17.jpg" },
                    { 42, 7, "2022_infiniti_qx80_20.jpg" },
                    { 43, 8, "2021_hyundai_elantra_3.jpg" },
                    { 44, 8, "2021_hyundai_elantra_4.jpg" },
                    { 45, 8, "2021_hyundai_elantra_5.jpg" },
                    { 46, 8, "2021_hyundai_elantra_6.jpg" },
                    { 47, 8, "2021_hyundai_elantra_7.jpg" },
                    { 48, 8, "2021_hyundai_elantra_16.jpg" },
                    { 49, 9, "2022_bmw_m3_competition_xdrive.jpg" },
                    { 50, 9, "2022_bmw_m3_competition_xdrive_23.jpg" },
                    { 51, 9, "2022_bmw_m3_competition_xdrive_25.jpg" },
                    { 52, 9, "2022_bmw_m3_competition_xdrive_27.jpg" },
                    { 53, 9, "2022_bmw_m3_competition_xdrive_28.jpg" },
                    { 54, 9, "2022_bmw_m3_competition_xdrive_29.jpg" },
                    { 55, 10, "2021_nissan_rogue_1.jpg" },
                    { 56, 10, "2021_nissan_rogue_3.jpg" },
                    { 57, 10, "2021_nissan_rogue_5.jpg" },
                    { 58, 10, "2021_nissan_rogue_6.jpg" },
                    { 59, 10, "2021_nissan_rogue_12.jpg" },
                    { 60, 10, "2021_nissan_rogue_18.jpg" },
                    { 61, 11, "1969 El Camino SS-Side-Profile.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CarId", "ImageUrl" },
                values: new object[,]
                {
                    { 62, 11, "1969 El Camino SS_Front.jpg" },
                    { 63, 11, "1969 El Camino SS-Trunk.jpg" },
                    { 64, 11, "1969 El Camino SS-Side-Door.jpg" },
                    { 65, 11, "1969 El Camino SS-Chassis.jpg" },
                    { 66, 11, "1969 El Camino SS_Engine.jpg" },
                    { 67, 12, "2013 Chevrolet Tahoe-Side-Profile.jpg" },
                    { 68, 12, "2013 Chevrolet Tahoe-Front.jpg" },
                    { 69, 12, "2013 Chevrolet Tahoe-Side.jpg" },
                    { 70, 12, "2013 Chevrolet Tahoe-Back.jpg" },
                    { 71, 12, "2013 Chevrolet Tahoe-Engine.jpg" },
                    { 72, 12, "2013 Chevrolet Tahoe-Interiour.jpg" },
                    { 73, 13, "2000 Ford F-350 Super Duty-Side-Profile.jpg" },
                    { 74, 13, "2000 Ford F-350 Super Duty-Front.jpg" },
                    { 75, 13, "2000 Ford F-350 Super Duty-Side-Profile-2.jpg" },
                    { 76, 13, "2000 Ford F-350 Super Duty-Back.jpg" },
                    { 77, 13, "2000 Ford F-350 Super Duty-Engine.jpg" },
                    { 78, 13, "2000 Ford F-350 Super Duty-Interiour.jpg" },
                    { 79, 14, "2013_renault_clio_32.jpg" },
                    { 80, 14, "2013_renault_clio_33.jpg" },
                    { 81, 14, "2013_renault_clio_34.jpg" },
                    { 82, 14, "2013_renault_clio_35.jpg" },
                    { 83, 14, "2013_renault_clio_36.jpg" },
                    { 84, 14, "2013_renault_clio_47.jpg" },
                    { 85, 15, "1998 Mercedes-Benz W140 S-class S600L-Side-Profile.jpg" },
                    { 86, 15, "1998 Mercedes-Benz W140 S-class S600L-Back.jpg" },
                    { 87, 15, "1998 Mercedes-Benz W140 S-class S600L-Front.jpg" },
                    { 88, 15, "1998 Mercedes-Benz W140 S-class S600L-Engine.jpg" },
                    { 89, 15, "1998 Mercedes-Benz W140 S-class S600L-Dashboard.jpg" },
                    { 90, 15, "1998 Mercedes-Benz W140 S-class S600L-Interiour.jpg" },
                    { 91, 16, "Acura 2005 RSX Type-S.jpg" },
                    { 92, 16, "Acura 2005 RSX Type-S-Side.jpg" },
                    { 93, 16, "Acura 2005 RSX Type-S-Back.jpg" },
                    { 94, 16, "Acura 2005 RSX Type-S-Front.jpg" },
                    { 95, 16, "Acura 2005 RSX Type-S-Interiour.jpg" },
                    { 96, 16, "Acura 2005 RSX Type-S-Engine.jpg" },
                    { 97, 17, "Acura 2005 NSX-Side-Profile.jpg" },
                    { 98, 17, "Acura 2005 NSX.jpg" },
                    { 99, 17, "Acura 2005 NSX-Back.jpg" },
                    { 100, 17, "Acura 2005 NSX-Engine.jpg" },
                    { 101, 17, "Acura 2005 NSX-Interiour.jpg" },
                    { 102, 17, "Acura 2005 NSX-Dashboard.jpg" },
                    { 103, 18, "Saab 2001 9-3 Aero.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CarId", "ImageUrl" },
                values: new object[,]
                {
                    { 104, 18, "Saab 2001 9-3 Aero-Side.jpg" },
                    { 105, 18, "Saab 2001 9-3 Aero-Other-Side.jpg" },
                    { 106, 18, "Saab 2001 9-3 Aero-Front.jpg" },
                    { 107, 18, "Saab 2001 9-3 Aero-Wheel.jpg" },
                    { 108, 18, "Saab 2001 9-3 Aero-Emblem.jpg" },
                    { 109, 19, "Saab 2006 93 SportCombi.jpg" },
                    { 110, 19, "Saab 2006 93 SportCombi-Back.jpg" },
                    { 111, 19, "Saab 2006 93 SportCombi-Trunk.jpg" },
                    { 112, 19, "Saab 2006 93 SportCombi-Side.jpg" },
                    { 113, 19, "Saab 2006 93 SportCombi-Dashboard.jpg" },
                    { 114, 19, "Saab 2006 93 SportCombi-Driving.jpg" },
                    { 115, 20, "Renault Megane II CoupeCabriolet.jpg" },
                    { 116, 20, "Renault Megane II CoupeCabriolet-Side.jpg" },
                    { 117, 20, "Renault Megane II CoupeCabriolet-Side-Top.jpg" },
                    { 118, 20, "Renault Megane II CoupeCabriolet-Front.jpg" },
                    { 119, 20, "Renault Megane II CoupeCabriolet-Trunk.jpg" },
                    { 120, 20, "Renault Megane II CoupeCabriolet-Interiour.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "AdId", "Comment", "StarsCount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Love the sporty feel of my Toyota Camry TRD! The handling is superb, and the interior is stylish. The TRD enhancements really add a punch. A great choice for those seeking a blend of performance and comfort.", 5, new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e") },
                    { 2, 1, "Impressed with the Toyota Camry TRD's acceleration and overall performance. The exterior design is eye-catching, and the cabin is spacious and comfortable. However, fuel efficiency could be better for a sedan in this segment.", 5, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 3, 1, "The Toyota Camry TRD disappointed me with its lackluster fuel economy. Despite its sporty appearance, the ride quality feels a bit stiff, especially on rough roads. It's a decent option if you prioritize performance over fuel efficiency.", 2, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 4, 1, "Absolutely thrilled with my Toyota Camry TRD! The sleek design turns heads wherever I go, and the handling is smooth and responsive. Interior features are top-notch, making every drive enjoyable. Highly recommend this car!", 5, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 5, 1, "My experience with the Toyota Camry TRD has been mixed. While the performance is commendable and the cabin is comfortable, I've encountered issues with the infotainment system, which can be frustrating to use at times.", 3, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf") },
                    { 6, 2, "The Honda Civic Type R is an absolute blast to drive! Its turbocharged engine delivers exhilarating performance, and the sharp handling makes every corner a joy. The aggressive styling sets it apart from the crowd. Highly recommended!", 5, new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea") },
                    { 7, 2, "The Honda Civic Type R offers impressive performance and handling, but the stiff ride quality may not be suitable for everyone. The cabin is spacious and well-equipped, though some may find the design too flashy for their taste.", 3, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 8, 2, "Disappointed with the Honda Civic Type R's fuel efficiency, as it falls short compared to other models in its class. While the performance is thrilling, the ride can feel harsh on rough roads. Not the most practical choice for daily commuting", 2, new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c") },
                    { 9, 2, "Absolutely loving my Honda Civic Type R! The aggressive styling turns heads wherever I go, and the performance is simply outstanding. The interior is comfortable and packed with features. A dream car for enthusiasts!", 5, new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0") },
                    { 10, 2, "The Honda Civic Type R is a mixed bag for me. While I appreciate its performance and handling, the loud exhaust can become tiresome on long drives. Additionally, the infotainment system feels outdated compared to rivals in its segment.", 4, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 11, 3, "The Ford Mustang GT350R is a true performance machine! Its V8 engine roars with power, and the precise handling makes every drive exhilarating. The aggressive styling and track-focused features set it apart. A must-have for any enthusiast!", 5, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 12, 3, "The Ford Mustang GT350R offers thrilling performance and a track-ready setup, but its stiff suspension may not suit everyone's tastes for daily driving. The cabin is sporty and well-appointed, though some may find it lacking in refinement.", 3, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 13, 3, "Disappointed with the Ford Mustang GT350R's fuel economy, which falls short of expectations for a modern sports car. While the performance is thrilling, the stiff ride and loud exhaust may be too much for some buyers. Not ideal for daily commuting.", 1, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 14, 3, "Absolutely blown away by the Ford Mustang GT350R! The aggressive styling, track-tuned performance, and spine-tingling exhaust note make every drive an adrenaline rush. The handling is razor-sharp, and the interior is race-inspired. A true driver's car!", 5, new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e") },
                    { 15, 3, "The Ford Mustang GT350R offers thrilling performance, but its harsh ride and loud exhaust can become fatiguing on long drives. Additionally, the lack of advanced technology features may disappoint buyers seeking modern conveniences in a sports car.", 4, new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c") },
                    { 16, 4, "The Golf is a versatile and practical hatchback. Its fuel-efficient engine delivers impressive performance, and the handling is nimble around city streets. The interior is well-built and spacious, making it a great choice for daily commuting or weekend getaways.", 5, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 17, 4, "The Volkswagen Golf offers a balanced mix of performance and comfort. While it may not be as powerful as some rivals, its refined ride quality and upscale interior make it a compelling choice for those prioritizing comfort and practicality over outright performance.", 4, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 18, 4, "The Volkswagen's performance may feel underwhelming to enthusiasts seeking more power and excitement. Additionally, some competitors offer more advanced tech features. However, its fuel efficiency and comfortable ride make it a sensible option for daily driving.", 3, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 19, 4, "Absolutely loving this car! It strikes the perfect balance between fun-to-drive dynamics and everyday usability. The interior is modern and well-equipped, and the compact size makes it easy to navigate through city traffic. Highly recommended!", 5, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 20, 4, "While the Volkswagen Golf offers a comfortable ride and solid build quality, it lacks the engaging driving experience of some rivals. The interior design feels a bit dated, and the infotainment system could be more user-friendly. Overall, a decent choice in the hatchback segment.", 2, new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0") },
                    { 21, 5, "The Mercedes-Benz C-Class exudes luxury and sophistication. Its refined interior, comfortable ride, and advanced technology features elevate the driving experience. The powerful engine options deliver smooth performance, making every journey a pleasure. A class-leading choice in its segment.", 5, new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0") },
                    { 22, 5, "The Mercedes-Benz C-Class offers a perfect blend of luxury and performance. Its elegant exterior design is matched by a plush interior with high-quality materials. The ride is smooth and composed, though some may find the handling less engaging compared to sportier rivals.", 5, new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea") },
                    { 23, 5, "While the Mercedes-Benz C-Class impresses with its luxurious interior and smooth ride, it falls short in terms of reliability compared to some competitors. Additionally, the infotainment system can be complicated to use, detracting from the overall driving experience.", 3, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 24, 5, "Absolutely thrilled with my car! The attention to detail in its design, the refined interior, and the smooth, powerful performance make it a standout choice in the luxury sedan segment. Driving this car is truly a pleasure!", 5, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 25, 5, "The Mercedes-Benz C-Class offers a luxurious driving experience, but it comes at a steep price. Some may find the base engine underpowered compared to rivals, and the optional features can quickly inflate the cost. Overall, a premium choice for those willing to pay the premium price.", 4, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 26, 6, "The Audi A3 is a fantastic blend of luxury and performance. Its sleek design, upscale interior, and smooth ride make it a standout in its class. The available tech features add convenience and sophistication to the driving experience. Highly recommended!", 5, new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e") },
                    { 27, 6, "The Audi A3 offers a refined driving experience with a comfortable ride and luxurious interior. However, some may find the backseat space lacking, and the base engine could use more power. Overall, a solid choice for those seeking a compact luxury sedan.", 4, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 28, 6, "While the Audi A3 impresses with its stylish design and upscale interior, it falls short in terms of performance compared to some rivals. The base engine lacks punch, and the handling may not be as engaging as sportier competitors in its segment.", 3, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 29, 6, "Absolutely love my Audi A3! The sleek exterior, premium interior, and responsive handling make every drive a joy. The turbocharged engine provides plenty of power, and the advanced tech features add convenience and sophistication. Couldn't be happier with my choice!", 5, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 30, 6, "The Audi A3 offers a luxurious interior and comfortable ride, but it comes at a premium price compared to some competitors. Additionally, the backseat space is cramped, and the infotainment system can be complicated to use while driving. Overall, a decent option in the luxury compact sedan segment.", 3, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf") },
                    { 31, 7, "The Infiniti QX80 is the epitome of luxury and power. Its spacious and opulent interior, combined with a commanding presence on the road, makes it a standout in its class. The smooth ride and powerful engine ensure a premium driving experience.", 5, new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea") },
                    { 32, 7, "The Infiniti QX80 offers a luxurious and comfortable ride with its spacious cabin and upscale materials. However, its handling can feel cumbersome, especially in tight spaces. The fuel economy could also be better for a vehicle of its size.", 4, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 33, 7, "While the Infiniti QX80 impresses with its luxurious interior and powerful engine, its fuel economy leaves much to be desired. The handling feels bulky, and the dated infotainment system lacks the modern features found in competitors.", 2, new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c") },
                    { 34, 7, "Absolutely in love with my Infiniti QX80! The plush interior, smooth ride, and abundance of high-tech features make every journey a pleasure. The powerful engine effortlessly cruises on the highway, and the spacious cabin ensures comfort for all passengers.", 5, new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0") },
                    { 35, 7, "The Infiniti QX80 offers a luxurious driving experience with its upscale interior and powerful engine. However, its large size can make it challenging to maneuver in tight spaces, and the fuel economy is below average for its class. Consider other options if efficiency is a priority.", 2, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") },
                    { 36, 8, "The Hyundai Elantra is a fantastic value for its class. Its sleek design, comfortable ride, and generous standard features make it a top choice for budget-conscious buyers. The fuel efficiency is impressive, making it practical for daily commuting.", 4, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 37, 8, "The Hyundai Elantra offers a comfortable ride and a spacious cabin with plenty of tech features, making it a practical choice for everyday driving. However, the handling could be more engaging, and some competitors offer more powerful engine options.", 4, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 38, 8, "While the Hyundai Elantra boasts a sleek design and comfortable ride, it falls short in terms of performance compared to rivals. The base engine lacks power, and the handling may not be as sharp as some competitors in its segment.", 3, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf") },
                    { 39, 8, "Absolutely delighted with my Hyundai Elantra! It exceeds expectations with its stylish design, comfortable interior, and smooth ride. The fuel efficiency is a major plus, saving me money at the pump without sacrificing performance. Highly recommend!", 5, new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea") },
                    { 40, 8, "The Hyundai Elantra offers decent value for its price, but it lacks the refinement and performance of some competitors. The interior materials feel cheap, and the ride can be noisy on rough roads. Consider other options if you prioritize comfort and luxury.", 1, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") },
                    { 41, 9, "The BMW 3 Series disappointed me with its lackluster reliability. I've had numerous issues with the engine and electronics, leading to costly repairs. Additionally, the interior feels cramped, and the ride quality is rough on uneven roads. Not worth the premium price tag.", 1, new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c") },
                    { 42, 9, "My experience with the BMW 3 Series has been marred by constant trips to the dealership for repairs. The build quality is subpar, with various components failing prematurely. The infotainment system is overly complicated and prone to glitches. A frustrating ownership experience overall.", 1, new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "AdId", "Comment", "StarsCount", "UserId" },
                values: new object[,]
                {
                    { 43, 9, "The BMW 3 Series fell short of my expectations in terms of performance. The handling, while decent, lacks the precision and agility I anticipated from a sport sedan. The engine feels underpowered, especially compared to rivals in its class. Disappointed with the overall driving dynamics.", 2, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 44, 9, "I regret purchasing the BMW 3 Series due to its exorbitant maintenance costs. Routine service visits are unnecessarily expensive, and parts are priced at a premium. The resale value is also disappointing, making ownership costs higher than anticipated. Not a wise investment in the long run.", 1, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 45, 9, "The BMW 3 Series failed to impress me with its outdated design and lack of modern features. The interior feels dated compared to competitors, and the infotainment system is clunky and unintuitive. The ride quality is harsh, especially on rough roads. Expected more from a luxury sedan.", 4, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf") },
                    { 46, 10, "Absolutely loving my Nissan Rogue! It's the perfect blend of practicality and comfort. Whether it's grocery runs or road trips, this SUV handles it all with ease. Plus, the fuel efficiency is a pleasant surprise. Highly recommend to anyone in need of a reliable and versatile vehicle.", 5, new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e") },
                    { 47, 10, "The Nissan Rogue has been a game-changer for my family. With its spacious interior and smooth ride, our road trips have become much more enjoyable. The safety features give us peace of mind, and the stylish design doesn't hurt either. Couldn't be happier with our choice!", 5, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 48, 10, "My Nissan Rogue has exceeded all my expectations. From its sleek exterior to its comfortable interior, it's a joy to drive every day. The fuel economy is impressive, and the tech features keep me connected on the go. Overall, a solid investment that I'm glad I made.", 4, new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6") },
                    { 49, 10, "The Nissan Rogue has been the perfect companion for my adventurous lifestyle. Its ample cargo space easily accommodates all my gear, and the intelligent AWD system gives me confidence in any terrain. Plus, the fuel efficiency means I can explore without breaking the bank. Highly recommend to fellow outdoor enthusiasts!", 4, new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc") },
                    { 50, 10, "Overall, my experience with the Nissan Rogue has been average. While it fulfills its purpose as a family-friendly SUV with ample space and decent fuel economy, I find the ride quality to be somewhat lacking, especially on rough roads. Additionally, some of the interior materials feel a bit cheap for its price range.", 3, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CarId",
                table: "Ads",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "IX_CarAccessories_CarId",
                table: "CarAccessories",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AddressId",
                table: "Cars",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CarId",
                table: "Images",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AdId",
                table: "Reviews",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CarAccessories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "StatisticalData");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
