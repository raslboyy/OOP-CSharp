using System.IO;
using System.Runtime.Serialization;

namespace BackupsExtra.Entities.LoggerModule
{
    [DataContract]
    public class FileLogger : ILogger
    {
        public FileLogger()
        {
            if (!File.Exists("backup_log"))
                File.Create("backup_log");
        }

        public void Log(string message)
        {
            File.AppendAllText("backup_log", message + "\n");
        }
    }
}