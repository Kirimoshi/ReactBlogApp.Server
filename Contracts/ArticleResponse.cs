namespace ReactBlogApp.Server.Contracts
{
    public record ArticleResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
    }
}
