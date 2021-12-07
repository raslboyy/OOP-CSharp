using System;
using System.Runtime.Serialization;
using Backups.Entities;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.LoggerModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule;
using BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities
{
    [DataContract]
    [KnownType(typeof(LocalRepositoryExtra))]
    [KnownType(typeof(ConsoleLogger))]
    [KnownType(typeof(FileLogger))]
    [KnownType(typeof(PrefixLogger))]
    [KnownType(typeof(TimeLogger))]
    public class BackupJobExtra : BackupJob, IBackupJobExtra, IDisposable
    {
        public BackupJobExtra(IRepositoryExtra repository)
        : this(repository.Load())
        {
            Logger.Log("Load backup job");
        }

        public BackupJobExtra(BackupJobExtra other)
        {
            Name = other.Name;
            RestorePoints = other.RestorePoints;
            JobObjects = other.JobObjects;
            Logger = other.Logger;
            RepositoryExtra = other.RepositoryExtra;
        }

        public BackupJobExtra(
            string name,
            IRepositoryExtra repository,
            IStorageAlgorithmExtra storageAlgorithm,
            ILogger logger,
            ILimitAlgorithm limitAlgorithm)
            : base(name, repository, storageAlgorithm)
        {
            RepositoryExtra = repository;
            Logger = logger;
            RestorePoints = new RestorePointsStorageExtra(repository, storageAlgorithm, limitAlgorithm);
        }

        [DataMember]
        private IRepositoryExtra RepositoryExtra { get; set; }
        [DataMember]
        private IStorageAlgorithmExtra StorageAlgorithmExtra { get; set; }
        [DataMember]
        private ILogger Logger { get; set; }

        public override void AddFile(string name)
        {
            base.AddFile(name);
            Logger.Log($"Add file {name}");
        }

        public override void RemoveFile(string name)
        {
            base.RemoveFile(name);
            Logger.Log($"Remove file {name}");
        }

        public override string CreateRestorePoint()
        {
            string name = base.CreateRestorePoint();
            Logger.Log($"Create restore point {name}");
            return Name;
        }

        public void Restore(string restorePointName, string path = null)
        {
            IRestorePoint point = RestorePoints.Find(restorePointName);
            if (point == null)
                throw new BackupJobExtraException("No such restore point exists.");
            StorageAlgorithmExtra.Restore(RepositoryExtra, point, path);
            Logger.Log($"Restore {restorePointName}");
        }

        public void Dispose()
        {
            RepositoryExtra.Save(this);
            Logger.Log("Save backup job");
        }
    }
}