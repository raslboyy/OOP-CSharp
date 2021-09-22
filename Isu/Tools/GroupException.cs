using System;

namespace Isu.Tools
{
    public class GroupException : IsuException
    {
        public GroupException() { }
        public GroupException(string message)
            : base(message) { }
        public GroupException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}