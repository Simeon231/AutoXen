namespace AutoXen.Services.Data.Exceptions
{
    using System;

    public class WrongCarOwnerException : Exception
    {
        private static readonly string defaultMessage = "You are not the car owner!";

        public WrongCarOwnerException(string message)
            : base(message)
        {
        }

        public WrongCarOwnerException()
            : base(defaultMessage)
        {
        }
    }
}
