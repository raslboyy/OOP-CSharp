using System;

namespace Shops.Tools.Shop
{
    public class AWorkerException : ShopException
    {
        public AWorkerException()
        {
        }

        public AWorkerException(string message)
            : base(message)
        {
        }

        public AWorkerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}