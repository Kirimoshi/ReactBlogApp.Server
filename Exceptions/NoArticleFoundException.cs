namespace ReactBlogApp.Server.Exceptions
{
    public class NoArticleFoundException : Exception
    {
        public NoArticleFoundException() : base("No article(s) found") { }
    }
}