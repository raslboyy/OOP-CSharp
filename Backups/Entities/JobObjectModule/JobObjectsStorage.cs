using System;
using System.Collections.Generic;
using Backups.Entities.RepositoryModule;

namespace Backups.Entities.JobObjectModule
{
    public class JobObjectsStorage
    {
        private readonly List<IJobObject> _jobObjects;

        public JobObjectsStorage(IRepository repository)
        {
            _jobObjects = new List<IJobObject>();
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private IRepository Repository { get; }
        public IEnumerable<IJobObject> GetJobObjects() => _jobObjects;

        public IJobObject Add(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            var jobObject = new JobObject(name);
            _jobObjects.Add(jobObject);
            Repository.AddJobObject(jobObject);
            return jobObject;
        }

        public bool Remove(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            var jobObject = new JobObject(name);
            Repository.RemoveJobObject(jobObject);
            return _jobObjects.Remove(jobObject);
        }

        public bool Contains(string name) => _jobObjects.Find(item => item.Name == name) != null;
    }
}