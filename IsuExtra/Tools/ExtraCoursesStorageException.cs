using System;

namespace IsuExtra.Tools
{
    public class ExtraCoursesStorageException : IsuExtraServiceException
    {
        public ExtraCoursesStorageException()
        {
        }

        public ExtraCoursesStorageException(string message)
            : base(message)
        {
        }

        public ExtraCoursesStorageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}