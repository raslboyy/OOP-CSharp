using System;
using Shops.Tools.Shop;

namespace Shops.Tools.Product
{
    public class ProductListException : ShopException
    {
        public ProductListException()
        {
        }

        public ProductListException(string message)
            : base(message)
        {
        }

        public ProductListException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}