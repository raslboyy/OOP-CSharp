using System;

namespace BackupsExtra.Tools
{
    public class ByNumberAlgorithmException : Exception
    {
        public ByNumberAlgorithmException()
        {
        }

        public ByNumberAlgorithmException(string message)
            : base(message)
        {
        }

        public ByNumberAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}