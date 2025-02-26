using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactBlogApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3ab8f659-7e60-4ee3-8fbb-4b6e3f64cdd8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("776872fc-88ec-4799-acc4-c2718de07232"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8419f10c-128f-430e-83e8-2ba2bfde7a38"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a7cfd26-e1f5-4c3c-a325-755499cc235c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b35a7846-8520-46b0-ae81-040d18afbcf3"));

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "Category", "Content", "Language", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("224c11c3-b615-41d4-b42b-ab52127e6608"), "Emma Johnson", "C#", "In this article, we will explore async/await and best practices for writing asynchronous code in C#.", "English", new DateTime(2025, 2, 26, 19, 54, 11, 922, DateTimeKind.Local).AddTicks(4086), "Asynchronous Programming in C#" },
                    { new Guid("3fa39702-882f-441c-a321-d8f3545fd578"), "Michael Brown", "ASP.NET Core", "How middleware works in ASP.NET Core and how to use it effectively...", "English", new DateTime(2025, 2, 26, 19, 54, 11, 922, DateTimeKind.Local).AddTicks(4113), "Middleware in ASP.NET Core" },
                    { new Guid("e1820e56-af03-4102-8542-7b6c692132d9"), "John Smith", "ASP.NET Core", "Understanding how the built-in dependency injection container works in ASP.NET Core...", "English", new DateTime(2025, 2, 26, 19, 54, 11, 920, DateTimeKind.Local).AddTicks(1691), "Dependency Injection in ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("8acc1c1d-7603-4220-baaa-7543a7c93764"), "tom@gmail.com", "$2a$11$QKmDvAAu4UtCROW1FA4vXuCJooXz277QySZZL05qHKdapKAlNIfle" },
                    { new Guid("e4bc9aa3-464f-42e4-9dda-b0c10e817a31"), "bob@gmail.com", "$2a$11$zFAF8UZqX1.v7DLs/4wJ.OO.L.hzbG5pj64osoK5OS005B8dbV/mW" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("224c11c3-b615-41d4-b42b-ab52127e6608"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3fa39702-882f-441c-a321-d8f3545fd578"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e1820e56-af03-4102-8542-7b6c692132d9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8acc1c1d-7603-4220-baaa-7543a7c93764"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4bc9aa3-464f-42e4-9dda-b0c10e817a31"));

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

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
    }
}
