namespace AutoXen.Services.Exceptions
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
