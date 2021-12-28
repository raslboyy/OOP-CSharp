using System;
using System.Runtime.Serialization;

namespace Backups.Entities.JobObjectModule
{
    [DataContract]
    public struct JobObject : IJobObject
    {
        public JobObject(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [DataMember]
        public string Name { get; internal set; }
    }
}