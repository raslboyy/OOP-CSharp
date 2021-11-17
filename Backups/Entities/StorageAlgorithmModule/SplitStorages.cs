using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;

namespace Backups.Entities.StorageAlgorithmModule
{
    public class SplitStorages : IStorageAlgorithm
    {
        public void SaveRestorePoint(IRepository repository, IRestorePoint restorePoint) =>
            repository.SplitStorages(restorePoint);
    }
}