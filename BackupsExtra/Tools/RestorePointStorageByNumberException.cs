using System;

namespace BackupsExtra.Tools
{
    public class RestorePointStorageByNumberException : Exception
    {
        public RestorePointStorageByNumberException()
        {
        }

        public RestorePointStorageByNumberException(string message)
            : base(message)
        {
        }

        public RestorePointStorageByNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}