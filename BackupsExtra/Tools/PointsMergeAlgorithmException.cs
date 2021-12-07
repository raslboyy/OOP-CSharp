using System;

namespace BackupsExtra.Tools
{
    public class PointsMergeAlgorithmException : Exception
    {
        public PointsMergeAlgorithmException()
        {
        }

        public PointsMergeAlgorithmException(string message)
            : base(message)
        {
        }

        public PointsMergeAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}