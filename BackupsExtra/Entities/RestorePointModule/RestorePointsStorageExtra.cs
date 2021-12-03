using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public abstract class RestorePointsStorageExtra : RestorePointsStorage, IRestorePointsStorageExtra
    {
        protected RestorePointsStorageExtra(IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm)
            : base(repository, storageAlgorithm)
        {
            LimitAlgorithm = new DeleteLimitAlgorithm();
            RepositoryExtra = repository;
            StorageAlgorithmExtra = storageAlgorithm;
        }

        public ILimitAlgorithm LimitAlgorithm { get; private set; }
        protected IRepositoryExtra RepositoryExtra { get; }
        protected IStorageAlgorithmExtra StorageAlgorithmExtra { get; }

        public void SetMergeLimitAlgorithm() => LimitAlgorithm = new MergeLimitAlgorithm();
        public void SetDeleteLimitAlgorithm() => LimitAlgorithm = new DeleteLimitAlgorithm();
    }
}