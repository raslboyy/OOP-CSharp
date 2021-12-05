using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Backups.Entities.RepositoryModule;

namespace Backups.Entities.JobObjectModule
{
    [DataContract]
    [KnownType(typeof(JobObject))]
    [KnownType(typeof(LocalRepository))]
    [KnownType(typeof(MockRepository))]
    public class JobObjectsStorage
    {
        public JobObjectsStorage(IRepository repository)
        {
            JobObjects = new List<IJobObject>();
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [DataMember]
        private List<IJobObject> JobObjects { get; set; }
        [DataMember]
        private IRepository Repository { get; set; }
        public IEnumerable<IJobObject> GetJobObjects() => JobObjects;

        public IJobObject Add(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            var jobObject = new JobObject(name);
            JobObjects.Add(jobObject);
            Repository.AddJobObject(jobObject);
            return jobObject;
        }

        public bool Remove(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            var jobObject = new JobObject(name);
            Repository.RemoveJobObject(jobObject);
            return JobObjects.Remove(jobObject);
        }

        public bool Contains(string name) => JobObjects.Find(item => item.Name == name) != null;
    }
}