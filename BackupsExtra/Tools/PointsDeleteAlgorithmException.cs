using System;

namespace BackupsExtra.Tools
{
    public class PointsDeleteAlgorithmException : Exception
    {
        public PointsDeleteAlgorithmException()
        {
        }

        public PointsDeleteAlgorithmException(string message)
            : base(message)
        {
        }

        public PointsDeleteAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}