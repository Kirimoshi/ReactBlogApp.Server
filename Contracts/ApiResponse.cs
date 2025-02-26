namespace ReactBlogApp.Server.Contracts
{
    public class ApiResponse<T>(T Data, string Message)
    {
        public T Data { get; set; } = Data;
        public string Message { get; set; } = Message;
    }
}
