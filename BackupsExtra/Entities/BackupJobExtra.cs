using System;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule;

namespace BackupsExtra.Entities
{
    [DataContract]
    [KnownType(typeof(RestorePointsStorageByNumber))]
    [KnownType(typeof(RestorePointsStorageByDate))]
    [KnownType(typeof(RestorePointsStorageHybridByIntersection))]
    [KnownType(typeof(RestorePointsStorageHybridByUnion))]
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

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public IRestorePointsStorageExtra RestorePoints { get; private set; }
        [DataMember]
        public JobObjectsStorage JobObjects { get; private set; }

        public void AddFile(string name) => JobObjects.Add(name);
        public bool RemoveFile(string name) => JobObjects.Remove(name);
        public string CreateRestorePoint() => RestorePoints.Add(JobObjects).Name;

        public void Restore(string restorePointName, string path = null) =>
            RestorePoints.Restore(restorePointName, path);
    }
}