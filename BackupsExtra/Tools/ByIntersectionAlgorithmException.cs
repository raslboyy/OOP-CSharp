using System;

namespace BackupsExtra.Tools
{
    public class ByIntersectionAlgorithmException : Exception
    {
        public ByIntersectionAlgorithmException()
        {
        }

        public ByIntersectionAlgorithmException(string message)
            : base(message)
        {
        }

        public ByIntersectionAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}