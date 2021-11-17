using System;

namespace Backups.Entities.JobObjectModule
{
    public readonly struct JobObject : IJobObject
    {
        public JobObject(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
    }
}