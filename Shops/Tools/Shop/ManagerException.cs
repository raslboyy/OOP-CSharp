using System;

namespace Shops.Tools.Shop
{
    public class ManagerException : ShopException
    {
        public ManagerException()
        {
        }

        public ManagerException(string message)
            : base(message)
        {
        }

        public ManagerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}