using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using ReactBlogApp.Server.Contracts;
using ReactBlogApp.Server.Interfaces;
using ReactBlogApp.Server.Services;

namespace ReactBlogApp.Server.Endpoints
{
    public static class ArticleEndpoint
    {
        public static IEndpointRouteBuilder MapArticleEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/articles",
                [Authorize]async (CreateArticleRequest createArticleRequest,
                       IBlogArticleService articleService) =>
                {
                    var result = await articleService.AddArticleAsync(createArticleRequest);
                    return Results.Created($"/articles/{result.Id}", result);
                }
            );

            app.MapGet("/articles", async (IBlogArticleService articleService) =>
            {
                var result = await articleService.GetAllArticlesAsync();
                return Results.Ok(result);
            }
            );

            app.MapGet("/articles/{id:guid}", 
                async (IBlogArticleService articleService, Guid id) =>
            {
                var result = await articleService.GetArticleByIdAsync(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            }
            );

            app.MapPut("/articles/{id:guid}",
                [Authorize]async (Guid id, UpdateArticleRequest updateArticleRequest, IBlogArticleService articleService) =>
            {
                var result = await articleService.UpdateArticleAsync(id, updateArticleRequest);
                return result != null ? Results.Ok(result) : Results.NotFound();
            }
            );

            app.MapDelete("articles/{id:guid}",
                [Authorize] async (Guid id, IBlogArticleService articleService) =>
                {
                    var result = await articleService.DeleteArticleAsync(id);
                    return result ? Results.NoContent() : Results.NotFound();
                });

            return app;
        }
    }
}