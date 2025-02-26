using Microsoft.EntityFrameworkCore;
using ReactBlogApp.Server.AppContext;
using ReactBlogApp.Server.Contracts;
using ReactBlogApp.Server.Interfaces;
using ReactBlogApp.Server.Models;

namespace ReactBlogApp.Server.Services
{
    public class ArticleService(BlogContext context, ILogger<ArticleService> logger) : IBlogArticleService
    {
        public async Task<ArticleResponse> AddArticleAsync(CreateArticleRequest createArticleRequest)
        {
            try
            {
                var article = new BlogArticleModel
                {
                    Id = Guid.NewGuid(),
                    Title = createArticleRequest.Title,
                    Content = createArticleRequest.Content,
                    PublishedDate = createArticleRequest.PublishedDate,
                    Author = createArticleRequest.Author,
                    Category = createArticleRequest.Category,
                    Language = createArticleRequest.Language,
                };

                context.BlogArticles.Add(article);
                await context.SaveChangesAsync();
                logger.LogInformation("Article added successfully");

                return new ArticleResponse
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    PublishedDate = article.PublishedDate,
                    Author = article.Author,
                    Category = article.Category,
                    Language = article.Language,
                };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error adding article: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteArticleAsync(Guid articleId)
        {
            try
            {
                var article = await context.BlogArticles.FindAsync(articleId);
                if (article == null)
                {
                    logger.LogWarning($"Article {articleId} not found");
                    return false;
                }

                context.BlogArticles.Remove(article);
                await context.SaveChangesAsync();
                logger.LogInformation($"Article with ID {article.Id} deleted successfully");
                return true;        
            }
            catch (Exception ex)
            {
                logger.LogError($"Error deleting article: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<ArticleResponse>> GetAllArticlesAsync()
        {
            try
            {
                var articles = await context.BlogArticles.ToListAsync();

                return from article in articles
                       select new ArticleResponse 
                       { 
                           Id = article.Id,
                           Title = article.Title,
                           Content = article.Content,
                           PublishedDate = article.PublishedDate,
                           Author = article.Author,
                           Category = article.Category,
                           Language= article.Language,
                       };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error retrieving articles: {ex.Message}");
                throw;
            }
        }

        public async Task<ArticleResponse> GetArticleByIdAsync(Guid articleId)
        {
            try
            {
                var article = await context.BlogArticles.FindAsync(articleId);
                if (article == null)
                {
                    logger.LogWarning($"Article {articleId} not found");
                    return null;
                }

                return new ArticleResponse
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    PublishedDate = article.PublishedDate,
                    Author = article.Author,
                    Category = article.Category,
                    Language = article.Language,
                };

            }
            catch (Exception ex)
            {
                logger.LogError($"Error retrieving article: {ex.Message}");
                throw;
            }
        }

        public async Task<ArticleResponse> UpdateArticleAsync(Guid articleId, UpdateArticleRequest updateArticleRequest)
        {
            try
            {
                var article = await context.BlogArticles.FindAsync(articleId);
                if (article == null)
                {
                    logger.LogWarning($"Article with ID {articleId} not found");
                    return null;
                }

                article.Title = updateArticleRequest.Title;
                article.Content = updateArticleRequest.Content;
                article.PublishedDate = updateArticleRequest.PublishedDate;
                article.Author = updateArticleRequest.Author;
                article.Category = updateArticleRequest.Category;
                article.Language = updateArticleRequest.Language;

                await context.SaveChangesAsync();
                logger.LogInformation("Article updated successfully");

                return new ArticleResponse
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    PublishedDate = article.PublishedDate,
                    Author = article.Author,
                    Category = article.Category,
                    Language = article.Language,
                };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error updating article: {ex.Message}");
                throw;
            }
        }
    }
}