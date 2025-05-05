namespace Shared.Middleware
{
    // Base Exception for API-related errors
    public abstract class ApiException(string message, int statusCode, string errorCode) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;
        public string ErrorCode { get; } = errorCode;
        public DateTime Timestamp { get; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"[{Timestamp}] {ErrorCode}: {Message}";
        }
    }

    // Custom NotFound exception
    public class NotFoundException(string message) : ApiException(message, 404, "NOT_FOUND")
    {
    }

    // Custom BadRequest exception
    public class BadRequestException(string message) : ApiException(message, 400, "BAD_REQUEST")
    {
    }

    // Custom UnauthorizedAccessException
    public class UnauthorizedAccessException(string message) : ApiException(message, 401, "UNAUTHORIZED")
    {
    }

    // Custom InternalServerError exception
    public class InternalServerErrorException(string message) : ApiException(message, 500, "INTERNAL_SERVER_ERROR")
    {
    }
}
