using System;
using System.Collections.Generic;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;

namespace Backups.Entities.RestorePointModule
{
    public class RestorePoint : IRestorePoint
    {
        private readonly List<IStorage> _storages;

        public RestorePoint(JobObjectsStorage jobObjectsStorage, IRepository repository, int id)
        {
            if (jobObjectsStorage == null)
                throw new ArgumentNullException(nameof(jobObjectsStorage));
            Time = DateTime.Now;
            Name = Time.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + id;
            _storages = new List<IStorage>();
            foreach (IJobObject jobObject in jobObjectsStorage.GetJobObjects())
            {
                var storage = new Storage(jobObject, repository, id);
                _storages.Add(storage);
            }
        }

        public DateTime Time { get; }
        public string Name { get; }
        public IEnumerable<IStorage> GetStorages() => _storages;
        public bool Contains(string name) => _storages.Find(item => item.JobObject.Name == name) != null;
    }
}