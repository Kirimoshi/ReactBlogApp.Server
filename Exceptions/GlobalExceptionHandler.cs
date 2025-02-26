using Microsoft.AspNetCore.Diagnostics;
using ReactBlogApp.Server.Contracts;
using System.Net;

namespace ReactBlogApp.Server.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An error occurred while processing your request");

            var errorResponse = new ErrorResponse
            {
                Message = exception.Message,
                Error = exception.GetType().Name
            };

            errorResponse.StatusCode = exception switch
            {
                BadHttpRequestException => (int)HttpStatusCode.BadRequest,
                NoArticleFoundException or ArticleDoesNotExistException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
