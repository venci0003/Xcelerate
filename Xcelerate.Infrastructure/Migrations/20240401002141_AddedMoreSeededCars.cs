using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xcelerate.Infrastructure.Migrations
{
    public partial class AddedMoreSeededCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7877359f-0be1-44e5-b90a-6bdf80456239", "AQAAAAEAACcQAAAAECBDYQG/GTB265bEw06vfBMfqoDCSaqAE4ULjgLB6qow37I5EnyE/riLl0X8khj9gQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e06294cc-4fc5-43e3-95ef-f7af59bc04d9", "AQAAAAEAACcQAAAAEHKduaa2JRPaJfCvd1LnoucMEy4Vo72kH6xVchCEvTnS/9uPAD4FGS2i/8+bkxkecw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fbbeaec-181e-46f3-816b-45c6c15143bf", "AQAAAAEAACcQAAAAEGUIjn/8q9I7AlfqkHjq+/0RB9gOkZPUiUWwyOTkC9948faGhoFWSfv1W5RyYiBCxQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3aac0bb-18f2-4282-bb29-b6c299ecc736", "AQAAAAEAACcQAAAAEG2NwqY3cJkSfjUEhqaJJfOkUQHcptCI6lP4YV40rlOTWADIsnojlC4Vnz2Wmfmj2A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c1af731-ff25-4077-b660-d3b19bf28a78", "AQAAAAEAACcQAAAAEJWnTgkI8x51UlKPpy/LJJ4J9jmJjW3MZGQx49jJjfwy/l7t+vJ4xDCFTk8LTXb9Ag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb36e091-fa98-4c0c-b44b-c351844bffed", "AQAAAAEAACcQAAAAEGTKpgEfzaCYCWBziczRV6MkxBO8WsDD5AQutx4Ic9SSmsns/3Eu1C0rATOYSikNrQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89f54786-f35a-4d43-9857-e1bd572a684f", "AQAAAAEAACcQAAAAEBz8YRhOdCwVszzJUl3Ym0WGeR/Senm5R4gW110/+o9I53dTh+YiH33JqgIW7O4SbA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "41ff769e-1a78-44d8-a47d-02b3a49e8ccf", "AQAAAAEAACcQAAAAEBpztXdwZa38hhD4a6pqmz+a8mpzroGURH7tl4+YU53ti3NcGb34rsSin55CP5S9tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ef5b5ea-3d21-4801-9795-882534de8641", "AQAAAAEAACcQAAAAEIZ/ROHqLV/MQN3TrA9rM13/5MmNguYuM2ZZAj2yF22cj9Hxvr0ovunQJZPMljC3Lg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1580244-1e91-4f4c-92a3-86e1915e617c", "AQAAAAEAACcQAAAAEBEhrqDTcsI7At25W75O0jSlHkV0eklOXBoULoHHb27JEckmMianaj/KjCzwgctEYg==" });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "EngineId", "CylinderCount", "FuelType", "Horsepower", "Model" },
                values: new object[,]
                {
                    { 21, 4, 1, 240, "F20C" },
                    { 22, 4, 1, 160, "K-Series K20A3" },
                    { 23, 4, 1, 130, "F20B 1.8L VTEC" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 21, "Honda" },
                    { 22, "Honda" },
                    { 23, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "AdId", "AddressId", "BodyType", "Brand", "Colour", "Condition", "DriveTrain", "EngineId", "EuroStandard", "IsForSale", "ManufacturerId", "Mileage", "Model", "Price", "Transmission", "UserId", "Weight", "Year" },
                values: new object[] { 21, 21, 21, 2, 41, 3, 2, 2, 21, 4, true, 21, 113000, "S2000", 30000m, 1, new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"), 1320.25m, 2004 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "AdId", "AddressId", "BodyType", "Brand", "Colour", "Condition", "DriveTrain", "EngineId", "EuroStandard", "IsForSale", "ManufacturerId", "Mileage", "Model", "Price", "Transmission", "UserId", "Weight", "Year" },
                values: new object[] { 22, 22, 22, 4, 41, 1, 2, 1, 22, 5, true, 22, 123000, "Civic Si", 15000m, 1, new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"), 1360.25m, 2004 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "AdId", "AddressId", "BodyType", "Brand", "Colour", "Condition", "DriveTrain", "EngineId", "EuroStandard", "IsForSale", "ManufacturerId", "Mileage", "Model", "Price", "Transmission", "UserId", "Weight", "Year" },
                values: new object[] { 23, 23, 23, 1, 41, 2, 2, 1, 23, 3, true, 23, 212000, "Accord", 180000m, 1, new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"), 1410.35m, 1993 });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "AdId", "CarDescription", "CarId", "CreatedOn", "UserId" },
                values: new object[,]
                {
                    { 21, "Experience the thrill of open-top driving with the iconic Honda S2000. Crafted with precision engineering and a lightweight frame, this roadster delivers exhilarating performance on every curve. With its powerful engine, sleek design, and advanced features like electronically-assisted steering and Vehicle Stability Assist, the S2000 offers an unmatched driving experience. Discover the joy of the road like never before.", 21, "2022-11-10", new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc") },
                    { 22, "Elevate your drive with the Honda Civic 7th gen! With its sleek design, spacious interiors, and advanced engine options, this car redefines compact style. Experience the thrill of the road like never before. Get behind the wheel and discover the perfect blend of innovation and practicality today!", 22, "2023-25-02", new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf") },
                    { 23, "Get ready to turn heads in the fifth-gen European Honda Accord. Designed for comfort and performance, this sedan is a joy to drive. With its sleek exterior and advanced features, it's perfect for your daily commute or weekend adventures. Experience the ultimate blend of style and reliability with the Honda Accord.", 23, "2024-30-05", new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020") }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[,]
                {
                    { 1, 21 },
                    { 1, 23 },
                    { 2, 22 },
                    { 3, 21 },
                    { 4, 22 },
                    { 5, 21 },
                    { 5, 23 },
                    { 6, 22 },
                    { 7, 21 },
                    { 8, 22 },
                    { 9, 23 },
                    { 10, 21 },
                    { 11, 22 },
                    { 13, 21 },
                    { 13, 23 },
                    { 14, 22 },
                    { 15, 21 },
                    { 16, 22 },
                    { 17, 21 },
                    { 17, 23 },
                    { 18, 22 },
                    { 19, 21 },
                    { 20, 22 },
                    { 21, 23 },
                    { 22, 22 },
                    { 24, 22 },
                    { 25, 23 },
                    { 26, 22 },
                    { 28, 22 },
                    { 29, 23 },
                    { 30, 21 },
                    { 32, 22 },
                    { 33, 23 },
                    { 37, 21 },
                    { 37, 23 },
                    { 41, 23 },
                    { 42, 21 },
                    { 44, 21 },
                    { 45, 21 }
                });

            migrationBuilder.InsertData(
                table: "CarAccessories",
                columns: new[] { "AccessoryId", "CarId" },
                values: new object[] { 45, 23 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CarId", "ImageUrl" },
                values: new object[,]
                {
                    { 121, 21, "Honda 2004 S2000.jpg" },
                    { 122, 21, "Honda 2004 S2000 - Side.jpg" },
                    { 123, 21, "Honda 2004 S2000 - Side 2.jpg" },
                    { 124, 21, "Honda 2004 S2000 - Wheel.jpg" },
                    { 125, 21, "Honda 2004 S2000 - Engine.jpg" },
                    { 126, 21, "Honda 2004 S2000 - Interiour.jpg" },
                    { 127, 22, "Honda 2004 Civic Si.jpg" },
                    { 128, 22, "Honda 2004 Civic Si - Side.jpg" },
                    { 129, 22, "Honda 2004 Civic Si - Front.jpg" },
                    { 130, 22, "Honda 2004 Civic Si - Back.jpg" },
                    { 131, 22, "Honda 2004 Civic Si - Interiour.jpg" },
                    { 132, 22, "Honda 2004 Civic Si - Interiour 2.jpg" },
                    { 133, 23, "Honda 1993 Accord.jpg" },
                    { 134, 23, "Honda 1993 Accord - Back.jpg" },
                    { 135, 23, "Honda 1993 Accord - Interiour.jpg" },
                    { 136, 23, "Honda 1993 Accord - Dashboard.jpg" },
                    { 137, 23, "Honda 1993 Accord - Interiour 2.jpg" },
                    { 138, 23, "Honda 1993 Accord - Wheel.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "AdId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "AdId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "AdId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 3, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 5, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 6, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 7, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 10, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 11, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 13, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 13, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 14, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 15, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 16, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 17, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 17, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 18, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 19, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 20, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 21, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 22, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 24, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 25, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 26, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 28, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 29, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 30, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 32, 22 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 33, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 37, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 37, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 41, 23 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 42, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 44, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 45, 21 });

            migrationBuilder.DeleteData(
                table: "CarAccessories",
                keyColumns: new[] { "AccessoryId", "CarId" },
                keyValues: new object[] { 45, 23 });

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "EngineId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "EngineId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "EngineId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb170e0f-a443-4cc4-92d5-25fbc7157147", "AQAAAAEAACcQAAAAEPDj3YLm0gbxSxCULkj/Iv6JWo2j17Hw0KMTk5977ieNg7MpYkqWBAjXWi06FMUqyw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "601189bf-d7e2-401c-a99b-c6a4216b6f2a", "AQAAAAEAACcQAAAAEPkFagJi2WUJX30agv1FGzGEqSpQ7sOZXO9GmT56IzGDaFieCd+YMenyx9GynA2D/A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b004bcf7-7270-425f-82ad-613a55721515", "AQAAAAEAACcQAAAAEK7VRm4+wP7e/m+KHAlo2E+IpBb/qgbYA9IjXJvuKqIBO2tGO9m3lKyCLeuomw/C9Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86c2b1f9-3c0b-4397-82c6-b7ba4b267c0f", "AQAAAAEAACcQAAAAEBSQoQshu5yuGXzE0Fd+/Mce6qBrn65AGlepS1yr0cpQrYKHqOixsKLds+GNuikIdA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d23b6f8f-2cf2-436e-8129-92b81750fe3c", "AQAAAAEAACcQAAAAEOIay2snGacU71MQlXbKTYK+6ioer6t39xnzomEzi7nd4zgJUM/4YHq2gOLc2xLDMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d19cfd52-1f99-4f71-8a2d-2e82152700b7", "AQAAAAEAACcQAAAAEMykfj2v7WSUtmgL62BdF/bXV7ijSCFVE1+HO/wS78qf5iYkYAjU0jhW0m5SSHWokw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bcafabbf-e6c0-4983-90be-60a21367d35a", "AQAAAAEAACcQAAAAEKQTtbe1E3tb8+O76pOuHCI3PUEkvlLuLO+pm2SdcUaOKEH5P+HATCCrpTnhpFVZYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c9a0899-9662-4c99-9734-8565e3163357", "AQAAAAEAACcQAAAAEKZuL9mDgJxfkFlGe8eAazxezLarjs69tXQ9rZZX/CA+5x/Cc8CRip5JmU1r7oOCmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f345b7eb-fbbc-44db-aab5-ae3d130cad59", "AQAAAAEAACcQAAAAEPEBBWKggduCVTIcpNdupbAtYAMKG8YKyFKq9EMs+mSalEoc7xN7Jp2u5aRGpoKZIQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2699deb1-c9e3-49ae-bacf-96485a2fc696", "AQAAAAEAACcQAAAAEEBGMOg4bUa/Xm9EN5vRT4fhBg2gIMlOAaBDHDHnAXsDecpxh/NcLK6XWI67Y7D31Q==" });
        }
    }
}
