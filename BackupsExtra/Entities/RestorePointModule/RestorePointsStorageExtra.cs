using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public abstract class RestorePointsStorageExtra : RestorePointsStorage, IRestorePointsStorageExtra
    {
        protected RestorePointsStorageExtra(IRepositoryExtra repository, IStorageAlgorithm storageAlgorithm)
            : base(repository, storageAlgorithm)
        {
            LimitAlgorithm = new DeleteLimitAlgorithm();
            RepositoryExtra = repository;
        }

        public ILimitAlgorithm LimitAlgorithm { get; private set; }
        protected IRepositoryExtra RepositoryExtra { get; }

        public void SetMergeLimitAlgorithm() => LimitAlgorithm = new MergeLimitAlgorithm();
        public void SetDeleteLimitAlgorithm() => LimitAlgorithm = new DeleteLimitAlgorithm();
    }
}