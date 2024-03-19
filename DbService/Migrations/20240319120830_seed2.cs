using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbService.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("216a9c6a-e257-4a02-a05d-28457ee21a53"));

            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("5e4832e6-cfed-4a51-8a4e-60892761e06b"));

            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("d3416981-bd62-4d49-8f0e-5355e86d82f1"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("088da3f6-8714-4f34-a078-87711c6825c2"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("4dbb0b52-557f-40d3-bd8d-79b52463e6aa"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("7bc7a2b6-1fcb-43e5-a27c-565b00146e7b"));

            migrationBuilder.InsertData(
                table: "SearchProviders",
                columns: new[] { "Id", "Base64Image", "BaseUrl", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("7ca1526f-4410-4fee-8ddf-457a480003de"), "base64:eee", "https://www.google.co.uk/search?num=100&q={{0}}", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8025), "Google (Alt)", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8026) },
                    { new Guid("bd9c0848-3aa8-4b04-ba68-68dd984805fc"), "base64:eee", "https://www.dogpile.com/serp?q={{0}}", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8008), "Dogpile", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8010) },
                    { new Guid("c8594551-2646-4472-a0da-ea6504c287a6"), "base64:eee", "https://www.google.co.uk/search?num=100&q={{0}}", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(7918), "Google", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(7974) }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("3700b53a-c1e9-4303-b9b9-3b34e792eda5"), new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8044), "Paul", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8045) },
                    { new Guid("5dd241c4-2d10-4ce3-810e-11e014c55fa0"), new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8063), "Sara", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8064) },
                    { new Guid("db4644d4-ace1-4088-af61-3f369ddb72ca"), new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8079), "Colin", new DateTime(2024, 3, 19, 12, 8, 30, 145, DateTimeKind.Local).AddTicks(8080) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("7ca1526f-4410-4fee-8ddf-457a480003de"));

            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("bd9c0848-3aa8-4b04-ba68-68dd984805fc"));

            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("c8594551-2646-4472-a0da-ea6504c287a6"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("3700b53a-c1e9-4303-b9b9-3b34e792eda5"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("5dd241c4-2d10-4ce3-810e-11e014c55fa0"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("db4644d4-ace1-4088-af61-3f369ddb72ca"));

            migrationBuilder.InsertData(
                table: "SearchProviders",
                columns: new[] { "Id", "Base64Image", "BaseUrl", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("216a9c6a-e257-4a02-a05d-28457ee21a53"), "base64:eee", "https://www.dogpile.com/serp?q=\\{0\\}", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5241), "Dogpile", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5242) },
                    { new Guid("5e4832e6-cfed-4a51-8a4e-60892761e06b"), "base64:eee", "https://www.google.co.uk/search?num=100&q=\\{0\\}", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5157), "Google", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5210) },
                    { new Guid("d3416981-bd62-4d49-8f0e-5355e86d82f1"), "base64:eee", "https://www.google.co.uk/search?num=100&q=\\{0\\}", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5257), "Google (Alt)", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5258) }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("088da3f6-8714-4f34-a078-87711c6825c2"), new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5299), "Sara", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5300) },
                    { new Guid("4dbb0b52-557f-40d3-bd8d-79b52463e6aa"), new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5314), "Colin", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5315) },
                    { new Guid("7bc7a2b6-1fcb-43e5-a27c-565b00146e7b"), new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5282), "Paul", new DateTime(2024, 3, 19, 10, 40, 54, 588, DateTimeKind.Local).AddTicks(5283) }
                });
        }
    }
}
