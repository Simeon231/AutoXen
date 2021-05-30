namespace AutoXen.Services.Exceptions
{
    using System;

    public class UnauthorizedRequestAccessException : UnauthorizedAccessException
    {
        public UnauthorizedRequestAccessException(string requestName)
            : base(GetMessage(requestName))
        {
        }

        private static string GetMessage(string requestName)
        {
            return $"You are unauthorized for this {requestName} request.";
        }
    }
}
