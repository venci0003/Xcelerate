using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xcelerate.Infrastructure.Migrations
{
    public partial class ChangedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2892f37-b5a4-405a-8f33-27e6b59ca3cc", "AQAAAAEAACcQAAAAEFulUf3IUXRfVkkMKwv5jJIM4uy2hwudMNtkKkBMozZ2Z9Y/vGRNB1h3UgBYq6puVQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42833eb8-73d5-4d17-a6ce-5ad8b5c3100f", "AQAAAAEAACcQAAAAEEJPzCqIaDSK3OnJ9dLbKxURmnsd1q7a1LDgQvOahYgMDVZXxnP+Fn8V37onj12SvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1478eca-5997-4208-8c3e-8267848a1fc3", "AQAAAAEAACcQAAAAELqS8ynw5YptR1JYFi9YYvW/QtpxvHADjg+IVvHWsav/p3DxJ0yvY6UwBsDFzsN87g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "889ea5f6-26ab-4336-8c69-b8ba2130687a", "AQAAAAEAACcQAAAAEB1CsdU4/1B16YVj5bo6qtz9t1ma7j1LcmZ9Gg0CwIBLkw7L+id8w3Ww1IDFxLJgvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f003fd3-44e9-4a74-bfc7-69b82ae26a3c", "AQAAAAEAACcQAAAAEIPJ03Pouhlfs+R38fwVlirHJigIOwlyhwHS0XT2FZEXObr6FZU881f8mkvjoa8qUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "61a0cef0-14ab-41b0-a626-0fe59bf8c3c2", "AQAAAAEAACcQAAAAEG/0peratOtsFgUiE2MqdaEDWcEmCtU3I2YMtrJDyhj44A74Ww9YAkxDbz985G1N+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c18bb235-9dc6-4abf-ba53-be31158a82b9", "AQAAAAEAACcQAAAAEE8LUSMyOfrgX1+zgYESw3/RoZBHNMWvRFrJw/i7+NJhXiRaRhzPEreelmra8283uQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f79d380-e829-4823-81de-80cb78ce2941", "AQAAAAEAACcQAAAAEDmYgJ+BdGUdv0h0HgaC8KbqlkKxGEGWVySN2trTBPmrqtTT0o6JnrXu6kwFCgrbQA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a725ac0-884f-475c-9039-26351d656d36", "AQAAAAEAACcQAAAAEOJV/7y8+5C0HvGwbl/f21PEJLT/jx0mgdoNvavbtIrqQb1ox8n7x/qtDwtRf2+sdg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cfa23534-e5ba-43f0-b74e-76d729d5ec21", "AQAAAAEAACcQAAAAEKQrh4ArxM8o9xyToYaZfs/16sP3LAun5B+7Y++GtR60XQfPAMTeD3CaiK1OJdQTVw==" });
        }
    }
}
