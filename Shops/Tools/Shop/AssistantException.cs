using System;

namespace Shops.Tools.Shop
{
    public class AssistantException : ShopException
    {
        public AssistantException()
        {
        }

        public AssistantException(string message)
            : base(message)
        {
        }

        public AssistantException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}