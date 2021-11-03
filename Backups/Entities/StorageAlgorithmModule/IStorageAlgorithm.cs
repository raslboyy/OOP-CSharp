using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;

namespace Backups.Entities.StorageAlgorithmModule
{
    public interface IStorageAlgorithm
    {
        void SaveRestorePoint(IRepository repository, IRestorePoint restorePoint);
    }
}