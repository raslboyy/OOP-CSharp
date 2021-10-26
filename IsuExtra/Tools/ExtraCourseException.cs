using System;

namespace IsuExtra.Tools
{
    public class ExtraCourseException : IsuExtraServiceException
    {
        public ExtraCourseException()
        {
        }

        public ExtraCourseException(string message)
            : base(message)
        {
        }

        public ExtraCourseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}