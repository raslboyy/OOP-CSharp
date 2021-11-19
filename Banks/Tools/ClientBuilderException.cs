using System;

namespace Banks.Tools
{
    public class ClientBuilderException : Exception
    {
        public ClientBuilderException()
        {
        }

        public ClientBuilderException(string message)
            : base(message)
        {
        }

        public ClientBuilderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}