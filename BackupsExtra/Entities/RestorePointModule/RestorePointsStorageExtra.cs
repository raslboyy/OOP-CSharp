using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public abstract class RestorePointsStorageExtra : RestorePointsStorage, IRestorePointsStorageExtra
    {
        protected RestorePointsStorageExtra(IRepository repository, IStorageAlgorithm storageAlgorithm)
            : base(repository, storageAlgorithm)
        {
            LimitAlgorithm = new DeleteLimitAlgorithm();
        }

        public ILimitAlgorithm LimitAlgorithm { get; private set; }

        public void SetMergeLimitAlgorithm() => LimitAlgorithm = new MergeLimitAlgorithm();
        public void SetDeleteLimitAlgorithm() => LimitAlgorithm = new DeleteLimitAlgorithm();
    }
}