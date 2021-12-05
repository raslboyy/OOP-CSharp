using System;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using BackupsExtra.Entities.LoggerModule;
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
    [KnownType(typeof(ConsoleLogger))]
    [KnownType(typeof(FileLogger))]
    [KnownType(typeof(PrefixLogger))]
    [KnownType(typeof(TimeLogger))]
    public class BackupJobExtra : IBackupJobExtra, IDisposable
    {
        private bool disposed = false;

        public BackupJobExtra(IRepositoryExtra repository)
        : this(repository.Load())
        {
            Logger.Log("Load backup job");
        }

        public BackupJobExtra(string name, IRepositoryExtra repository, IRestorePointsStorageExtra restorePointsStorage, ILogger logger)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            JobObjects = new JobObjectsStorage(repository);
            RestorePoints = restorePointsStorage;
            RepositoryExtra = repository;
            Logger = new PrefixLogger(Name, logger);
            Logger.Log("Create backup job");
        }

        public BackupJobExtra(BackupJobExtra other)
        {
            Name = other.Name;
            RestorePoints = other.RestorePoints;
            JobObjects = other.JobObjects;
            Logger = other.Logger;
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
        [DataMember]
        private ILogger Logger { get; set; }

        public void AddFile(string name)
        {
            JobObjects.Add(name);
            Logger.Log($"Add file {name}");
        }

        public void RemoveFile(string name)
        {
            JobObjects.Remove(name);
            Logger.Log($"Remove file {name}");
        }

        public string CreateRestorePoint()
        {
            string name = RestorePoints.Add(JobObjects).Name;
            Logger.Log($"Create restore point {name}");
            return Name;
        }

        public void Restore(string restorePointName, string path = null)
        {
            RestorePoints.Restore(restorePointName, path);
            Logger.Log($"Restore {restorePointName}");
        }

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
            Logger.Log("Save backup job");
            disposed = true;
        }
    }
}