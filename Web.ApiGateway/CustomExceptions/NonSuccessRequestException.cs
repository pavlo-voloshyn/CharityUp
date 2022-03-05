using System.Net;

namespace Web.ApiGateway.CustomExceptions;

public class NonSuccessRequestException : Exception
{
    public HttpStatusCode Code { get; }
    
    public string Content { get; }

    public NonSuccessRequestException(HttpStatusCode code, string content)
    {
        Code = code;
        Content = content;
    }
}
