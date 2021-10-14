using System;

namespace Shops.Tools.Product
{
    public class ProductException : ProductListException
    {
        public ProductException()
        {
        }

        public ProductException(string message)
            : base(message)
        {
        }

        public ProductException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}