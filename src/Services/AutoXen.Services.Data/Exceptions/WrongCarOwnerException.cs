namespace AutoXen.Services.Data.Exceptions
{
    using System;

    public class WrongCarOwnerException : Exception
    {
        public WrongCarOwnerException(string message)
            : base(message)
        {
        }
    }
}
