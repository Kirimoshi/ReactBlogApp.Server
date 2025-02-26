using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactBlogApp.Server.Models;

namespace ReactBlogApp.Server.Configurations
{
    public class ArticleTypeConfigurations : IEntityTypeConfiguration<BlogArticleModel>
    {
        public void Configure(EntityTypeBuilder<BlogArticleModel> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Content)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(b => b.PublishedDate)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .HasColumnType("DATETIME2");

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Language)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new BlogArticleModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Dependency Injection in ASP.NET Core",
                    Author = "John Smith",
                    Content = "Understanding how the built-in dependency injection container works in ASP.NET Core...",
                    Category = "ASP.NET Core",
                    Language = "English",
                    PublishedDate = DateTime.Now,
                },
                new BlogArticleModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Asynchronous Programming in C#",
                    Author = "Emma Johnson",
                    Content = "In this article, we will explore async/await and best practices for writing asynchronous code in C#.",
                    Category = "C#",
                    Language = "English",
                    PublishedDate = DateTime.Now,
                },
                new BlogArticleModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Middleware in ASP.NET Core",
                    Author = "Michael Brown",
                    Content = "How middleware works in ASP.NET Core and how to use it effectively...",
                    Category = "ASP.NET Core",
                    Language = "English",
                    PublishedDate = DateTime.Now,
                }
                );
        }
    }
}
