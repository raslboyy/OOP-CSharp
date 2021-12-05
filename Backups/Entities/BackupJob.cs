using System;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;

namespace Backups.Entities
{
    [DataContract]
    public class BackupJob : IBackupJob
    {
        public BackupJob(string name, IRepository repository, IStorageAlgorithm storageAlgorithm)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (storageAlgorithm == null)
                throw new ArgumentNullException(nameof(storageAlgorithm));
            RestorePoints = new RestorePointsStorage(repository, storageAlgorithm);
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            JobObjects = new JobObjectsStorage(repository);
        }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public RestorePointsStorage RestorePoints { get; private set; }
        [DataMember]
        public JobObjectsStorage JobObjects { get; private set; }

        public void AddFile(string name) => JobObjects.Add(name);
        public bool RemoveFile(string name) => JobObjects.Remove(name);
        public string CreateRestorePoint() => RestorePoints.Add(JobObjects).Name;
    }
}