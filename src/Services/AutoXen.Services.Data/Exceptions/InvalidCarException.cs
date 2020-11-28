namespace AutoXen.Services.Data.Exceptions
{
    using System;

    public class InvalidCarException : Exception
    {
        public InvalidCarException(string message)
            : base(message)
        {
        }
    }
}
