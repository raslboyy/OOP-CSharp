using System;
using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageByDate : RestorePointsStorageExtra
    {
        public RestorePointsStorageByDate(IRepository repository, IStorageAlgorithm storageAlgorithm, DateTime dateTime)
            : base(repository, storageAlgorithm)
        {
            DeadDateTime = dateTime;
        }

        public DateTime DeadDateTime { get; }
    }
}