using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;

namespace BackupsExtra.Entities.StorageAlgorithmModule
{
    public interface IStorageAlgorithmExtra : IStorageAlgorithm
    {
        IRestorePoint MergeRestorePoints(IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2);
        void DeleteRestorePoint(IRepositoryExtra repository, IRestorePoint point);
    }
}