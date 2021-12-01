using System;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;

namespace Backups.Entities
{
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

        protected BackupJob(string name, IRepository repository, IStorageAlgorithm storageAlgorithm, IRestorePointsStorage restorePointsStorage)
            : this(name, repository, storageAlgorithm)
        {
            RestorePoints = restorePointsStorage;
        }

        public string Name { get; }
        public IRestorePointsStorage RestorePoints { get; }
        public JobObjectsStorage JobObjects { get; }

        public void AddFile(string name) => JobObjects.Add(name);
        public bool RemoveFile(string name) => JobObjects.Remove(name);
        public string CreateRestorePoint() => RestorePoints.Add(JobObjects).Name;
    }
}