namespace ReactBlogApp.Server.Contracts
{

    public record CreateArticleRequest
    {
        public string Title { get; init; }
        public string Content { get; init; }
        public DateTime? PublishedDate { get; init; }
        public string Author { get; init; }
        public string Category { get; init; }
        public string Language { get; init; }
    }
}