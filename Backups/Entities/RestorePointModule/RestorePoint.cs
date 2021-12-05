using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;

namespace Backups.Entities.RestorePointModule
{
    [DataContract]
    [KnownType(typeof(Storage))]
    public class RestorePoint : IRestorePoint
    {
        public RestorePoint(JobObjectsStorage jobObjectsStorage, IRepository repository, int id)
        {
            if (jobObjectsStorage == null)
                throw new ArgumentNullException(nameof(jobObjectsStorage));
            Time = DateTime.Now;
            Name = Time.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + id;
            Storages = new List<IStorage>();
            foreach (IJobObject jobObject in jobObjectsStorage.GetJobObjects())
            {
                var storage = new Storage(jobObject, repository, id);
                Storages.Add(storage);
            }
        }

        [DataMember]
        public DateTime Time { get; private set; }
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        private List<IStorage> Storages { get; set; }

        public IEnumerable<IStorage> GetStorages() => Storages;
        public bool ContainsJobObject(string name) => Storages.Find(item => item.JobObject.Name == name) != null;
        public void AddStorage(IStorage storage) => Storages.Add(storage);
    }
}