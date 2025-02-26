using ReactBlogApp.Server.Models;

namespace ReactBlogApp.Server.Interfaces
{
    public interface ILoginService
    {
        Task<IResult> UserLoginAsync(UserModel loginData);
    }
}
