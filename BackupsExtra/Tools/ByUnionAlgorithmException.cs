using System;

namespace BackupsExtra.Tools
{
    public class ByUnionAlgorithmException : Exception
    {
        public ByUnionAlgorithmException()
        {
        }

        public ByUnionAlgorithmException(string message)
            : base(message)
        {
        }

        public ByUnionAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}