using System;
using Isu.Services;

namespace Isu.Tools
{
    public class GroupNameException : IsuException
    {
        public GroupNameException()
        {
        }

        public GroupNameException(string message)
            : base(message)
        {
        }

        public GroupNameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}