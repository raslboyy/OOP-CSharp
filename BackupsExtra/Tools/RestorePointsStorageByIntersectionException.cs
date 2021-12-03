using System;

namespace BackupsExtra.Tools
{
    public class RestorePointsStorageByIntersectionException : Exception
    {
        public RestorePointsStorageByIntersectionException()
        {
        }

        public RestorePointsStorageByIntersectionException(string message)
            : base(message)
        {
        }

        public RestorePointsStorageByIntersectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}