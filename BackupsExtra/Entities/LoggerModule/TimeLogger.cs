using System;
using System.Runtime.Serialization;

namespace BackupsExtra.Entities.LoggerModule
{
    [DataContract]
    public class TimeLogger : LoggerDecorator
    {
        public TimeLogger(ILogger wrappee)
            : base(wrappee)
        {
        }

        public override void Log(string message)
        {
            Wrappee.Log($"{DateTime.Now} : {message}");
        }
    }
}