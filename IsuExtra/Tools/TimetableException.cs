using System;

namespace IsuExtra.Tools
{
    public class TimetableException : IsuExtraServiceException
    {
        public TimetableException()
        {
        }

        public TimetableException(string message)
            : base(message)
        {
        }

        public TimetableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}