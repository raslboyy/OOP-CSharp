using System;

namespace Shops.Tools.Customer
{
    public class CustomerException : CustomerServiceException
    {
        public CustomerException()
        {
        }

        public CustomerException(string message)
            : base(message)
        {
        }

        public CustomerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}