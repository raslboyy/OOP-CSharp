using System;

namespace IsuExtra.Tools
{
    public class IsuExtraServiceException : Exception
    {
        public IsuExtraServiceException()
        {
        }

        public IsuExtraServiceException(string message)
            : base(message)
        {
        }

        public IsuExtraServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}