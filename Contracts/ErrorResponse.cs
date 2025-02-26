namespace ReactBlogApp.Server.Contracts
{
    public record class ErrorResponse
    {
        public string Error { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
