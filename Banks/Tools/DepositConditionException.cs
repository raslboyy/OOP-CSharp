using System;

namespace Banks.Tools
{
    public class DepositConditionException : Exception
    {
        public DepositConditionException()
        {
        }

        public DepositConditionException(string message)
            : base(message)
        {
        }

        public DepositConditionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}