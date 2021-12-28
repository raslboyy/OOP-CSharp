using System;

namespace BackupsExtra.Tools
{
    public class ByDateAlgorithmException : Exception
    {
        public ByDateAlgorithmException()
        {
        }

        public ByDateAlgorithmException(string message)
            : base(message)
        {
        }

        public ByDateAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}