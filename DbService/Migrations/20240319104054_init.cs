using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbService.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base64Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchTerms = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Positions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSearches_SearchProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "SearchProviders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSearches_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_Name",
                table: "UserProfiles",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_UserSearches_ProfileId",
                table: "UserSearches",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSearches_ProviderId",
                table: "UserSearches",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSearches_SearchTerms",
                table: "UserSearches",
                column: "SearchTerms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSearches");

            migrationBuilder.DropTable(
                name: "SearchProviders");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
