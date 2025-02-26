using System.Reflection;
using ReactBlogApp.Server.AppContext;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReactBlogApp.Server.Interfaces;
using ReactBlogApp.Server.Services;
using ReactBlogApp.Server.Exceptions;

namespace ReactBlogApp.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            if (builder.Configuration == null) throw new ArgumentNullException(nameof(builder.Configuration));

            builder.Services.AddSqlite<BlogContext>(builder.Configuration.GetConnectionString("sqlConnection"));

            builder.Services.AddScoped<IBlogArticleService, ArticleService>();

            // Adding validators from the current assembly
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddProblemDetails();
        }
    }
}