using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xcelerate.Infrastructure.Migrations
{
    public partial class AddedNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsData",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsData", x => x.NewsId);
                });

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

            migrationBuilder.InsertData(
                table: "NewsData",
                columns: new[] { "NewsId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "Explore the dynamic landscape of mobility solutions, from ride-sharing advancements to urban transport innovations. Delve into the latest trends shaping the way we move and discover how technology is reshaping the concept of transportation as we know it.", "Driving Forward: Accelerating into the Future of Mobility" },
                    { 2, "Discover the electrifying revolution sweeping through the automotive world as electric vehicles take center stage. From Tesla's latest models to emerging EV startups, uncover the driving force behind the shift towards sustainable transportation.", "Revolutionizing the Road: The Rise of Electric Vehicles" },
                    { 3, "Step into the world of autonomous driving and discover the transformative potential of self-driving technology. From AI-powered navigation systems to advanced sensor technology, explore the journey towards a safer and more efficient driving experience.", "Beyond the Horizon: Exploring the Future of Autonomous Cars" },
                    { 4, "Delve into the captivating world of automotive design and uncover the fusion of artistry and engineering shaping the cars of tomorrow. From iconic classics to futuristic concepts, explore the evolution of automotive styling through the ages.\r\n", "Designing Tomorrow: The Art and Science of Automotive Styling" },
                    { 5, "Journey into the heart of automotive innovation and uncover the groundbreaking engineering behind today's most advanced vehicles. From hybrid powertrains to next-generation materials, explore the technologies driving the future of automotive performance.", "Under the Hood: The Latest in Automotive Engineering" },
                    { 6, "Join the movement towards a greener future as the automotive industry embraces sustainability. From eco-friendly manufacturing practices to zero-emission vehicle initiatives, discover the initiatives driving the transition to a more environmentally conscious transportation ecosystem.", "Green Revolution: Navigating the Shift Towards Sustainable Transportation" },
                    { 7, "Explore the opportunities and obstacles on the horizon as the automotive industry navigates a rapidly evolving landscape. From regulatory hurdles to shifting consumer preferences, delve into the complexities shaping the future of mobility.", "The Road Ahead: Navigating the Challenges of Tomorrow's Mobility" },
                    { 8, "Experience the revolution of connectivity as cars become smarter, more intuitive, and seamlessly integrated into our digital lives. Explore the latest advancements in vehicle-to-infrastructure technology and discover how connectivity is redefining the driving experience.", "Unleashing Potential: The Power of Connected Cars" },
                    { 9, "Dive into the forefront of technological innovation as automotive engineers push the boundaries of what's possible. From augmented reality dashboards to blockchain-enabled supply chains, explore the groundbreaking advancements shaping the future of transportation.", "Innovation Drive: Pioneering Breakthroughs in Automotive Technology" },
                    { 10, "Experience the epitome of automotive luxury as leading brands redefine what it means to drive in style. From opulent interiors to bespoke customization options, discover the latest trends in high-end automotive craftsmanship.", "Redefining Luxury: The Evolution of High-End Automobiles" },
                    { 11, "Prioritize safety on the road with a closer look at the latest advancements in automotive security technology. From advanced driver assistance systems to cutting-edge collision avoidance features, explore the innovations keeping drivers and passengers safe.", "Safety First: Advancing the Standards of Automotive Security" },
                    { 12, "Witness the intersection of performance and sustainability as electric vehicles redefine the meaning of speed and power. From lightning-fast acceleration to precision handling, uncover the thrilling capabilities of the latest electric performance models.", "The Power Play: Exploring the Rise of Electric Performance Vehicles" },
                    { 13, "Address the unique challenges of urban transportation with innovative solutions designed for the cityscape. From compact electric scooters to autonomous shuttle services, discover how urban mobility initiatives are reshaping the way we navigate our cities.\r\n", "Urban Mobility: Navigating the Future of City Transportation" },
                    { 14, "Test14", "Test14" },
                    { 15, "Peek behind the curtain of automotive manufacturing and witness the transformative changes revolutionizing production processes. From 3D printing to AI-driven automation, explore the technologies driving efficiency and sustainability in car factories.", "Behind the Scenes: The Manufacturing Revolution in Automotive Production" },
                    { 16, "Embark on a journey through the competitive landscape of autonomous driving as industry giants and startups vie for leadership. From Tesla's Full Self-Driving Beta to Waymo's robotaxis, explore the diverse approaches shaping the future of self-driving technology.", "The Race for Autonomy: Competing Visions in Self-Driving Technology" },
                    { 17, "Address the critical infrastructure needs of the growing electric vehicle market and explore solutions to charging accessibility and range anxiety. From fast-charging networks to battery swapping stations, uncover the innovations driving the EV charging revolution.\r\n", "Charging Ahead: Overcoming Challenges in the Electric Vehicle Infrastructure" },
                    { 18, "Explore the shift towards sustainable materials in automotive design and discover how eco-friendly alternatives are reshaping the industry. From recycled plastics to plant-based composites, delve into the cutting-edge materials driving sustainability in car manufacturing.", "Sustainable Innovation: Eco-Friendly Materials in Automotive Design" },
                    { 19, "Trace the evolution of transportation from horse-drawn carriages to the electric, connected vehicles of today. Explore how traditional automotive principles merge with modern innovation to shape the future of mobility for generations to come.", "The Evolution of Mobility: Bridging the Gap Between Tradition and Innovation" },
                    { 20, "Spotlight the contributions of women in the traditionally male-dominated automotive sector and explore initiatives aimed at promoting diversity and inclusion. From female engineers to women in leadership roles, celebrate the trailblazers shaping the future of the industry.\r\n", "Driving Diversity: Empowering Women in the Automotive Industry" },
                    { 21, "Test21", "Test21" },
                    { 22, "Test22", "Test22" },
                    { 23, "Test23", "Test23" },
                    { 24, "Test24", "Test24" },
                    { 25, "Test25", "Test25" },
                    { 26, "Test26", "Test26" },
                    { 27, "Test27", "Test27" },
                    { 28, "Test28", "Test28" },
                    { 29, "Test29", "Test29" },
                    { 30, "Test30", "Test30" },
                    { 31, "Test31", "Test31" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsData");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c106d5a-7440-44dd-b8d3-3c1b7aca8020"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04e7c52f-0b4f-4c63-8f80-96ea06de0e74", "AQAAAAEAACcQAAAAEOiT1rwnt2+2PkbTrCP9RM5Qe5GQ73zcBFZFBBBy+StxCjT2I06G9S9iCMS4vZ15lQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b6f6e67-5adf-4f78-a74e-27b02430c709"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "354a53a1-fc1f-4fd6-8ff9-ccbf5f09c76b", "AQAAAAEAACcQAAAAEOz5aTbv83Km0vRXgu72O5rzMzNSZ5ZzBx6RgoupaDkJ+tBbPYvA+nEgM/sPQoSfuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2cc5da14-f51c-4b51-96b3-0c296c2ee8dc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4d583b74-fb6e-4843-afa6-b1ddc28ee090", "AQAAAAEAACcQAAAAELJ/pOEI0BLdNiGnMkoVM8GZDH6mxH4af4tUNmV5Wk0r7z0L8pT4u/7bPrOvdaGDlw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("495cc255-9e57-40e1-a4de-b1adbfdbc0fc"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ecf68b6a-4e55-4d5a-b9f2-2993f13d7f50", "AQAAAAEAACcQAAAAEL73MKLmRxmxRDdAU7i6p5F39m4hKFpEiHKdi6V8/I92pG2SHy4BxUPzwXWNMJqS+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a31bb92-7ec2-45e3-81a8-912542b314c6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0dd6348a-f0cf-4b46-9555-5150c2624381", "AQAAAAEAACcQAAAAEF6JUXv+KeqWYwkV7TvDV/9KDmIVIFzCjw+S3nkWWIGar3UYwYsPjtmHcst61pORFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9173efb3-6dc6-4c27-8d1a-555107353aea"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3eb4f965-96f4-4dd3-a491-abcc0694628e", "AQAAAAEAACcQAAAAECgDuhgWYtcgtaIwMP6xT51Wj2YnIzGS7e4i1rVXpZCmEg1ZAwYiWp25ymySLH5oLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9abb04a0-36a0-4a35-8c1a-34d324aa169e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e089189-51fc-4e69-9e54-4e49340130d3", "AQAAAAEAACcQAAAAEMjI+lh6sJA7H5dmkXtE2s4mO/a2aBVVTSSjw6BqIxijGrjLmK26bJhbuHQi37Paig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0b378dd-78aa-4884-afa7-7ec6626c9cdf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b83a205-2d11-4b26-89b5-156457401311", "AQAAAAEAACcQAAAAEAguhSaiN7sZXpqtSplfVcN382yje5tS3aFKIHOoSHIt0dclfNDI/ZA1O2z9ODNXHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b13edf51-1ff3-46d7-bf4c-c55caac1a7c0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17e7caea-8fc7-4851-a4c0-df080b789433", "AQAAAAEAACcQAAAAEDhFl85IEArfiVCi6dpcWSALHKD4CrUHOLHq/Qk33UhdIDfBW4jPDJBvfQsLuPKQTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d7ddad-411e-4fe8-a7d9-c2638f376f1c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ce18cce-7853-4f36-abac-bb9d644b37a2", "AQAAAAEAACcQAAAAEFic9bgqgG50Yj+K9pG58lcO4Jd7bNvnkJPb2Me4sVMnsH5KsLOBc0NUEydya3VJdQ==" });
        }
    }
}
