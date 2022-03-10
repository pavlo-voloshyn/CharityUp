using System.Net;

namespace Web.ApiGateway.CustomExceptions;

/// <summary>
/// Exception class used for throwing when request to microservice wasn't successful
/// </summary>
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
