using System;

namespace BackupsExtra.Tools
{
    public class RestorePointsStorageByDateException : Exception
    {
        public RestorePointsStorageByDateException()
        {
        }

        public RestorePointsStorageByDateException(string message)
            : base(message)
        {
        }

        public RestorePointsStorageByDateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}