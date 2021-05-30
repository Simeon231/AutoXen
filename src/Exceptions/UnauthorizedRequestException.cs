namespace AutoXen.Services.Exceptions
{
    using System;

    public class UnauthorizedRequestException : UnauthorizedAccessException
    {
        public UnauthorizedRequestException(string requestName)
            : base(GetMessage(requestName))
        {
        }

        private static string GetMessage(string requestName)
        {
            return $"You are unauthorized for this {requestName} request.";
        }
    }
}
