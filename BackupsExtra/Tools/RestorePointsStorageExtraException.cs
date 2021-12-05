using System;

namespace BackupsExtra.Tools
{
    public class RestorePointsStorageExtraException : Exception
    {
        public RestorePointsStorageExtraException()
        {
        }

        public RestorePointsStorageExtraException(string message)
            : base(message)
        {
        }

        public RestorePointsStorageExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}