﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactBlogApp.Server.AppContext;

#nullable disable

namespace ReactBlogApp.Server.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20250226185412_UpdateUserPasswordHash")]
    partial class UpdateUserPasswordHash
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ReactBlogApp.Server.Models.BlogArticleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Articles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1820e56-af03-4102-8542-7b6c692132d9"),
                            Author = "John Smith",
                            Category = "ASP.NET Core",
                            Content = "Understanding how the built-in dependency injection container works in ASP.NET Core...",
                            Language = "English",
                            PublishedDate = new DateTime(2025, 2, 26, 19, 54, 11, 920, DateTimeKind.Local).AddTicks(1691),
                            Title = "Dependency Injection in ASP.NET Core"
                        },
                        new
                        {
                            Id = new Guid("224c11c3-b615-41d4-b42b-ab52127e6608"),
                            Author = "Emma Johnson",
                            Category = "C#",
                            Content = "In this article, we will explore async/await and best practices for writing asynchronous code in C#.",
                            Language = "English",
                            PublishedDate = new DateTime(2025, 2, 26, 19, 54, 11, 922, DateTimeKind.Local).AddTicks(4086),
                            Title = "Asynchronous Programming in C#"
                        },
                        new
                        {
                            Id = new Guid("3fa39702-882f-441c-a321-d8f3545fd578"),
                            Author = "Michael Brown",
                            Category = "ASP.NET Core",
                            Content = "How middleware works in ASP.NET Core and how to use it effectively...",
                            Language = "English",
                            PublishedDate = new DateTime(2025, 2, 26, 19, 54, 11, 922, DateTimeKind.Local).AddTicks(4113),
                            Title = "Middleware in ASP.NET Core"
                        });
                });

            modelBuilder.Entity("ReactBlogApp.Server.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8acc1c1d-7603-4220-baaa-7543a7c93764"),
                            Email = "tom@gmail.com",
                            PasswordHash = "$2a$11$QKmDvAAu4UtCROW1FA4vXuCJooXz277QySZZL05qHKdapKAlNIfle"
                        },
                        new
                        {
                            Id = new Guid("e4bc9aa3-464f-42e4-9dda-b0c10e817a31"),
                            Email = "bob@gmail.com",
                            PasswordHash = "$2a$11$zFAF8UZqX1.v7DLs/4wJ.OO.L.hzbG5pj64osoK5OS005B8dbV/mW"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
