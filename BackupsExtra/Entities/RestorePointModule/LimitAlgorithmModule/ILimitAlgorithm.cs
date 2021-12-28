using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule
{
    public interface ILimitAlgorithm
    {
        public IPointsDeleteAlgorithm PointsDeleteAlgorithm { get; }
        public void Apply(RestorePointsStorage restorePointsStorage, IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm);
    }
}