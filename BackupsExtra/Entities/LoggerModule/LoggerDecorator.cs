using System.Runtime.Serialization;

namespace BackupsExtra.Entities.LoggerModule
{
    [DataContract]
    [KnownType(typeof(FileLogger))]
    [KnownType(typeof(ConsoleLogger))]
    [KnownType(typeof(PrefixLogger))]
    [KnownType(typeof(TimeLogger))]
    public abstract class LoggerDecorator : ILogger
    {
        protected LoggerDecorator(ILogger wrappee)
        {
            Wrappee = wrappee;
        }

        [DataMember]
        protected ILogger Wrappee { get; set; }

        public abstract void Log(string message);
    }
}