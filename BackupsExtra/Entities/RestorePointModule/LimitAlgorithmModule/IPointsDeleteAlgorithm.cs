using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule
{
    public interface IPointsDeleteAlgorithm
    {
        void Apply(RestorePointsStorage restorePointsStorage, int number, IStorageAlgorithmExtra storageAlgorithm, IRepositoryExtra repository);
    }
}