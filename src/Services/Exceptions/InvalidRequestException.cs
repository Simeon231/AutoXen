namespace AutoXen.Services.Exceptions
{
    using System;

    public class InvalidRequestException : Exception
    {
        public InvalidRequestException()
            : base("Invalid request")
        {

        }
    }
}
