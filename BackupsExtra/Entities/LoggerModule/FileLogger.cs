using System.IO;
using System.Runtime.Serialization;

namespace BackupsExtra.Entities.LoggerModule
{
    [DataContract]
    public class FileLogger : ILogger
    {
        public FileLogger(string fileName)
        {
            FileName = fileName;
            if (!File.Exists(FileName))
                File.Create(FileName);
        }

        [DataMember]
        public string FileName { get; private set; }

        public void Log(string message)
        {
            File.AppendAllText(FileName, message + "\n");
        }
    }
}