using System;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;

namespace Backups.Entities.RestorePointModule
{
    [DataContract]
    [KnownType(typeof(JobObject))]
    public class Storage : IStorage
    {
        public Storage(IJobObject jobObject, IRepository repository, int restorePointId)
        {
            JobObject = jobObject;
            Name = jobObject.Name;
            repository.UpdateJobObject(jobObject);
        }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public IJobObject JobObject { get; private set; }
    }
}