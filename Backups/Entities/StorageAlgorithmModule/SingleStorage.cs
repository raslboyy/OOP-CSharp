using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;

namespace Backups.Entities.StorageAlgorithmModule
{
    public class SingleStorage : IStorageAlgorithm
    {
        public void SaveRestorePoint(IRepository repository, IRestorePoint restorePoint) =>
            repository.SingleStorage(restorePoint);
    }
}