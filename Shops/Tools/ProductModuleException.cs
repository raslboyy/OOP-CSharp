using System;

namespace Shops.Tools
{
    public class ProductModuleException : Exception
    {
        public ProductModuleException()
        {
        }

        public ProductModuleException(string message)
            : base(message)
        {
        }

        public ProductModuleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}