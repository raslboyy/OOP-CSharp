using System;

namespace Shops.Tools.Customer
{
    public class CustomerServiceException : Exception
    {
        public CustomerServiceException()
        {
        }

        public CustomerServiceException(string message)
            : base(message)
        {
        }

        public CustomerServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}