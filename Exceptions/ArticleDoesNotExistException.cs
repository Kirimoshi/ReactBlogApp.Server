namespace ReactBlogApp.Server.Exceptions
{
    public class ArticleDoesNotExistException(int id): 
        Exception($"Article with ID {id} does not exist");
}
