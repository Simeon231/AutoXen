namespace AutoXen.Services.Exceptions
{
    using System;

    public class WrongCarOwnerException : Exception
    {
        private static readonly string DefaultMessage = "You are not the car owner!";

        public WrongCarOwnerException(string message)
            : base(message)
        {
        }

        public WrongCarOwnerException()
            : base(DefaultMessage)
        {
        }
    }
}
