using System.Runtime.Serialization;

namespace BackupsExtra.Entities.LoggerModule
{
    [DataContract]
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}