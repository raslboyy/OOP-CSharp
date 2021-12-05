using System.Runtime.Serialization;

namespace BackupsExtra.Entities.LoggerModule
{
    [DataContract]
    public class PrefixLogger : LoggerDecorator
    {
        public PrefixLogger(string prefix, ILogger wrappee)
            : base(wrappee)
        {
            Prefix = prefix;
        }

        private string Prefix { get; }

        public override void Log(string message)
        {
            Wrappee.Log($"{Prefix} : {message}");
        }
    }
}