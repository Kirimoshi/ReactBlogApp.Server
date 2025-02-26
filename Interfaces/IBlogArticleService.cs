using ReactBlogApp.Server.Contracts;
using System.Collections;

namespace ReactBlogApp.Server.Interfaces
{
    public interface IBlogArticleService {
        Task<ArticleResponse> AddArticleAsync(CreateArticleRequest createArticleRequest);
        Task<ArticleResponse> UpdateArticleAsync(Guid articleId, UpdateArticleRequest updateArticleRequest);
        Task<bool> DeleteArticleAsync(Guid articleId);
        Task<ArticleResponse> GetArticleByIdAsync(Guid articleId);
        Task<IEnumerable<ArticleResponse>> GetAllArticlesAsync();
    }
}