using System;

namespace Banks.Tools
{
    public class AAccountException : Exception
    {
        public AAccountException()
        {
        }

        public AAccountException(string message)
            : base(message)
        {
        }

        public AAccountException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}