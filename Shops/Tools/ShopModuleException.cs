using System;

namespace Shops.Tools
{
    public class ShopModuleException : Exception
    {
        public ShopModuleException()
        {
        }

        public ShopModuleException(string message)
            : base(message)
        {
        }

        public ShopModuleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}