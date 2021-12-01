using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageByNumber : RestorePointsStorageExtra
    {
        public RestorePointsStorageByNumber(IRepository repository, IStorageAlgorithm storageAlgorithm, int limitSize)
            : base(repository, storageAlgorithm)
        {
            LimitSize = limitSize;
        }

        public int LimitSize { get; }
    }
}