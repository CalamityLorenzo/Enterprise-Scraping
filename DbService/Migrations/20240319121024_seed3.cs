using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbService.Migrations
{
    /// <inheritdoc />
    public partial class seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("463981c8-fa6e-4ba2-9ab7-01f89d3b290c"), "base64:eee", "https://www.google.co.uk/search?num=100&q={0}", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4949), "Google (Alt)", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4950) },
                    { new Guid("a35fbea2-e41e-4692-9071-1c8bb29a0365"), "base64:eee", "https://www.google.co.uk/search?num=100&q={0}", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4841), "Google", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4898) },
                    { new Guid("c5951b98-e351-4561-9ea0-9fa2c59b23d4"), "base64:eee", "https://www.dogpile.com/serp?q={0}", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4931), "Dogpile", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4933) }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("4f8ea409-957b-4296-bf49-7bbce84903ea"), new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5021), "Colin", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5022) },
                    { new Guid("c2d69d70-43e8-4c69-b15f-76e6d052d0d9"), new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4979), "Paul", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4980) },
                    { new Guid("d487ae02-e8b7-4b1c-8d3c-5802679dfe66"), new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5005), "Sara", new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5006) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("463981c8-fa6e-4ba2-9ab7-01f89d3b290c"));

            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("a35fbea2-e41e-4692-9071-1c8bb29a0365"));

            migrationBuilder.DeleteData(
                table: "SearchProviders",
                keyColumn: "Id",
                keyValue: new Guid("c5951b98-e351-4561-9ea0-9fa2c59b23d4"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("4f8ea409-957b-4296-bf49-7bbce84903ea"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("c2d69d70-43e8-4c69-b15f-76e6d052d0d9"));

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("d487ae02-e8b7-4b1c-8d3c-5802679dfe66"));

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
    }
}
