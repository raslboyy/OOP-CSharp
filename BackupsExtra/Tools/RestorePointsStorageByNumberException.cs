using System;

namespace BackupsExtra.Tools
{
    public class RestorePointsStorageByNumberException : Exception
    {
        public RestorePointsStorageByNumberException()
        {
        }

        public RestorePointsStorageByNumberException(string message)
            : base(message)
        {
        }

        public RestorePointsStorageByNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}