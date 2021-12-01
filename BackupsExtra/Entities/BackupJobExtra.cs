using System;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule;

namespace BackupsExtra.Entities
{
    public class BackupJobExtra : IBackupJobExtra
    {
        public BackupJobExtra(string name, IRepository repository, IRestorePointsStorageExtra restorePointsStorage)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            JobObjects = new JobObjectsStorage(repository);
            RestorePoints = restorePointsStorage;
        }

        public string Name { get; }
        public IRestorePointsStorageExtra RestorePoints { get; }
        public JobObjectsStorage JobObjects { get; }

        public void AddFile(string name) => JobObjects.Add(name);
        public bool RemoveFile(string name) => JobObjects.Remove(name);
        public string CreateRestorePoint() => RestorePoints.Add(JobObjects).Name;
    }
}