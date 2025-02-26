using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactBlogApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()"),
                    Author = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Language = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "Category", "Content", "Language", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("3ab8f659-7e60-4ee3-8fbb-4b6e3f64cdd8"), "Harper Lee", "Fiction", "A novel about the serious issues of rape and racial inequality.", "English", new DateTime(2025, 1, 14, 17, 59, 32, 228, DateTimeKind.Local).AddTicks(4843), "To Kill a Mockingbird" },
                    { new Guid("776872fc-88ec-4799-acc4-c2718de07232"), "George Orwell", "Fiction", "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ", "English", new DateTime(2025, 1, 14, 17, 59, 32, 228, DateTimeKind.Local).AddTicks(4872), "1984" },
                    { new Guid("8419f10c-128f-430e-83e8-2ba2bfde7a38"), "Paulo Coelho", "Fiction", "The Alchemist follows the journey of an Andalusian shepherd", "English", new DateTime(2025, 1, 14, 17, 59, 32, 225, DateTimeKind.Local).AddTicks(5056), "The Alchemist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("6a7cfd26-e1f5-4c3c-a325-755499cc235c"), "tom@gmail.com", "12345" },
                    { new Guid("b35a7846-8520-46b0-ae81-040d18afbcf3"), "bob@gmail.com", "55555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
