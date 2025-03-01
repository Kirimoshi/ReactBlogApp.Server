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
    [Migration("20250114165932_InitialCreate")]
    partial class InitialCreate
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
                            Id = new Guid("8419f10c-128f-430e-83e8-2ba2bfde7a38"),
                            Author = "Paulo Coelho",
                            Category = "Fiction",
                            Content = "The Alchemist follows the journey of an Andalusian shepherd",
                            Language = "English",
                            PublishedDate = new DateTime(2025, 1, 14, 17, 59, 32, 225, DateTimeKind.Local).AddTicks(5056),
                            Title = "The Alchemist"
                        },
                        new
                        {
                            Id = new Guid("3ab8f659-7e60-4ee3-8fbb-4b6e3f64cdd8"),
                            Author = "Harper Lee",
                            Category = "Fiction",
                            Content = "A novel about the serious issues of rape and racial inequality.",
                            Language = "English",
                            PublishedDate = new DateTime(2025, 1, 14, 17, 59, 32, 228, DateTimeKind.Local).AddTicks(4843),
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = new Guid("776872fc-88ec-4799-acc4-c2718de07232"),
                            Author = "George Orwell",
                            Category = "Fiction",
                            Content = "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ",
                            Language = "English",
                            PublishedDate = new DateTime(2025, 1, 14, 17, 59, 32, 228, DateTimeKind.Local).AddTicks(4872),
                            Title = "1984"
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6a7cfd26-e1f5-4c3c-a325-755499cc235c"),
                            Email = "tom@gmail.com",
                            Password = "12345"
                        },
                        new
                        {
                            Id = new Guid("b35a7846-8520-46b0-ae81-040d18afbcf3"),
                            Email = "bob@gmail.com",
                            Password = "55555"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
