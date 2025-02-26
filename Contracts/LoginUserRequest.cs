namespace ReactBlogApp.Server.Contracts
{
    public record LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
