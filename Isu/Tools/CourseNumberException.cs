using System;

namespace Isu.Tools
{
    public class CourseNumberException : IsuException
    {
        public CourseNumberException() { }
        public CourseNumberException(string message)
            : base(message) { }
        public CourseNumberException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}