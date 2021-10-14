using System;

namespace Shops.Tools.Shop
{
    public class StorageWorkerException : ShopException
    {
        public StorageWorkerException()
        {
        }

        public StorageWorkerException(string message)
            : base(message)
        {
        }

        public StorageWorkerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}