using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;

namespace BackupsExtra.Entities.StorageAlgorithmModule
{
    public class SingleStorageExtra : SingleStorage, IStorageAlgorithmExtra
    {
        public IRestorePoint MergeRestorePoints(IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            repository.RemoveDirectory(point1.Name);
            return point2;
        }

        public void DeleteRestorePoint(IRepositoryExtra repository, IRestorePoint point)
        {
            repository.RemoveDirectory(point.Name);
        }
    }
}