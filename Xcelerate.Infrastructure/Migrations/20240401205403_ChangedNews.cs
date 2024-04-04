using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xcelerate.Infrastructure.Migrations
{
    public partial class ChangedNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4171353-891c-4712-a3fb-c0a639986358", "AQAAAAEAACcQAAAAEAe5Am6Fxal+HrlGhS/9WvV06iaI03f1VAwvCNpVpvnMbeaw1W9UD5Ll+VuGoudhug==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f60ff271-f278-49cf-89a9-b42e709e3929", "AQAAAAEAACcQAAAAEFOLqYhH6BrxXalDSzZUZpR8Ps05bLA3YpPHVgfd7VHduns0ysGVaOQZPkWKZFgWfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ab9ceac-e910-4403-9bee-a3381fabfba8", "AQAAAAEAACcQAAAAEB+0PEY8ysOLNlBZAEgR003lYM35zM7AEFyoq/vdYVZjAIyfMc3AFjguioLGq1yd/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90552e4b-6598-486e-8dcd-8bbe6a5d2512", "AQAAAAEAACcQAAAAEOCDi7ljaESpdvQ5xb2vRzvaa5bBIYkxRVWAdSXjXhheZx+iro5ZSZ1P+p/e3D7fHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "705f45be-d654-4fa9-ad4f-d64eac4fd763", "AQAAAAEAACcQAAAAEOmlt/EHB4NPqfBW53jXgY0QMWLRPIsOI1lIcz2uDTj61gDoEuhoo4VQv17flUC2Gg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df27a1ef-c778-4194-9aec-8983c8e6cb33", "AQAAAAEAACcQAAAAEDjyATx1HsJNl3v6RysPZPwg10EXoyqrpU40H1wusJUqZ15he2+hC8thWTQe4b6BaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32d57d6f-ce5c-4621-98db-a7a91f9eabb5", "AQAAAAEAACcQAAAAEAoLJwSRk9KYeYOTA4MCuAsd/bs+/y2Hln9DHz4iyLCrRAb6FlED97eHjUtpoZIQtQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fa6d0c1-2a1b-4fd3-9202-747433544fbc", "AQAAAAEAACcQAAAAEIkFFXDWlQWxTDJlee/ac3KU+MeYmNOVhihGlMQxZVc/3E0NsDCFIZGhOkdsIvx6oQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed9d9919-0836-4478-927c-d243afedc887", "AQAAAAEAACcQAAAAEDvSRcl4kdoZE3J3S6S8EL8MJA5Z0WyfMOlizmnZwJyZLjQN+niLgpQN1i+g9Qwvzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2231be41-8da5-4e27-93c6-2bfc6320203c", "AQAAAAEAACcQAAAAEJug7ZtvRVkbmqruQSS2y7i8dJwzxKBwCm2gSpqO/YTMA5kEi9SZAnXur9Hhj+xnuQ==" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 21,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In a bid to appeal to the younger generation, car manufacturers unveil \"selfie mode\" for cars. Now your car can take better selfies than you, complete with flattering angles and Instagram filters.", "Car Manufacturers Launch \"Selfie Mode\" for Cars" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 22,
                columns: new[] { "Content", "Title" },
                values: new object[] { "A groundbreaking study suggests that car horns will soon be replaced by laughter. Imagine traffic jams turning into laugh fests, with drivers honking out giggles instead of frustrations. Get ready for a happier commute!", "Study Reveals: Car Horns to be Replaced by Laughter" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 23,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In a remarkable breakthrough, scientists have developed a new engine that runs entirely on coffee. Now, not only can you get your caffeine fix, but you can also fuel your car with it! Say goodbye to gas stations and hello to coffee shops on every corner.", "Breakthrough: Cars Now Run on Coffee" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 24,
                columns: new[] { "Content", "Title" },
                values: new object[] { "What started as a typical traffic jam turned into an unexpected celebration as drivers stepped out of their cars and broke into dance. The impromptu party lasted for hours, with motorists grooving to the beat of their favorite tunes, turning frustration into fun.", "Traffic Jam Transformed into World's Longest Dance Party" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 25,
                column: "Title",
                value: "Cat Drives Owner's Car to Pet Store");

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 26,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In a purr-fectly surprising turn of events, a clever cat managed to start its owner's car and drive to the pet store. Witnesses were amazed as the feline calmly navigated traffic and even signaled for turns. Looks like cats aren't just experts at napping—they're mastering driving too!", "Cat Drives Owner's Car to Pet Store" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 27,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In a groundbreaking study, researchers have discovered that dogs can be trained to operate vehicles. Doggie drivers? It's not just a dream anymore!", "New Study Reveals: Dogs Can Drive Cars!" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 28,
                columns: new[] { "Content", "Title" },
                values: new object[] { "A larger-than-life rubber duck sculpture broke free from its moorings and waddled down the streets, causing hilarious chaos and bringing traffic to a standstill.", "Giant Rubber Duck Causes Traffic Chaos" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 29,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In an unexpected turn of events, a local grandmother shocked everyone by winning a street racing competition. Her secret? She's been playing video games for decades!", "Local Grandma Wins Street Racing Competition" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 30,
                columns: new[] { "Content", "Title" },
                values: new object[] { "The world's first flying car successfully completed its maiden flight, soaring through the skies and marking a new era in transportation. The future is here!", "World's First Flying Car Takes Off" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 31,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In a fascinating discovery, scientists have found that cars possess a hidden language, allowing them to communicate with each other on the road. Are they plotting traffic jams or just chatting about the weather?", "Scientists Discover Cars Can Communicate with Each Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 21,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test21", "Test21" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 22,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test22", "Test22" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 23,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test23", "Test23" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 24,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test24", "Test24" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 25,
                column: "Title",
                value: "Test25");

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 26,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test26", "Test26" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 27,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test27", "Test27" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 28,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test28", "Test28" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 29,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test29", "Test29" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 30,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test30", "Test30" });

            migrationBuilder.UpdateData(
                table: "NewsData",
                keyColumn: "NewsId",
                keyValue: 31,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Test31", "Test31" });
        }
    }
}
