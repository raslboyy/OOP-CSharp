using System;

namespace BackupsExtra.Tools
{
    public class RestorePointsStorageHybridByUnionException : Exception
    {
        public RestorePointsStorageHybridByUnionException()
        {
        }

        public RestorePointsStorageHybridByUnionException(string message)
            : base(message)
        {
        }

        public RestorePointsStorageHybridByUnionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}