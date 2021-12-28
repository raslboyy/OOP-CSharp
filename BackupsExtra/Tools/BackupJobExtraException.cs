using System;

namespace BackupsExtra.Tools
{
    public class BackupJobExtraException : Exception
    {
        public BackupJobExtraException()
        {
        }

        public BackupJobExtraException(string message)
            : base(message)
        {
        }

        public BackupJobExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}