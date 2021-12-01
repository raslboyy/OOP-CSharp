using System;
using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageHybridByUnion : RestorePointsStorageExtra
    {
        public RestorePointsStorageHybridByUnion(IRepository repository, IStorageAlgorithm storageAlgorithm, DateTime dateTime, int limit)
            : base(repository, storageAlgorithm)
        {
            DeadDateTime = dateTime;
            LimitSize = limit;
        }

        public DateTime DeadDateTime { get; }
        public int LimitSize { get; }
    }
}