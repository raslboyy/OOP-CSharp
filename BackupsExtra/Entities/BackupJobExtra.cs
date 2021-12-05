using System;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule;

namespace BackupsExtra.Entities
{
    [DataContract]
    [KnownType(typeof(RestorePointsStorageByNumber))]
    [KnownType(typeof(RestorePointsStorageByDate))]
    [KnownType(typeof(RestorePointsStorageHybridByIntersection))]
    [KnownType(typeof(RestorePointsStorageHybridByUnion))]
    [KnownType(typeof(LocalRepositoryExtra))]
    public class BackupJobExtra : IBackupJobExtra, IDisposable
    {
        private bool disposed = false;

        public BackupJobExtra(IRepositoryExtra repository)
        : this(repository.Load())
        {
        }

        public BackupJobExtra(string name, IRepositoryExtra repository, IRestorePointsStorageExtra restorePointsStorage)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            JobObjects = new JobObjectsStorage(repository);
            RestorePoints = restorePointsStorage;
            RepositoryExtra = repository;
        }

        public BackupJobExtra(BackupJobExtra other)
        {
            Name = other.Name;
            RestorePoints = other.RestorePoints;
            JobObjects = other.JobObjects;
        }

        ~BackupJobExtra()
        {
            Dispose(false);
        }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public IRestorePointsStorageExtra RestorePoints { get; private set; }
        [DataMember]
        public JobObjectsStorage JobObjects { get; private set; }
        [DataMember]
        private IRepositoryExtra RepositoryExtra { get; set; }

        public void AddFile(string name) => JobObjects.Add(name);
        public bool RemoveFile(string name) => JobObjects.Remove(name);
        public string CreateRestorePoint() => RestorePoints.Add(JobObjects).Name;

        public void Restore(string restorePointName, string path = null) =>
            RestorePoints.Restore(restorePointName, path);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
            }

            RepositoryExtra.Save(this);
            disposed = true;
        }
    }
}