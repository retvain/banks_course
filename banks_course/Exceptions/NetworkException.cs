namespace banks_course.Exceptions;

public class NetworkException(string message) : Exception(message)
{
    public static NetworkException BecauseErrorConnectToUrl(string url, string error)
    {
        var errorMessage = $"Error connection to ({url}): {error}";
        return new NetworkException(errorMessage);
    }
}