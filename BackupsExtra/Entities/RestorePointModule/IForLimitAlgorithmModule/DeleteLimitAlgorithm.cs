using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule
{
    public class DeleteLimitAlgorithm : ILimitAlgorithm
    {
        public IRestorePoint Execute(IStorageAlgorithmExtra storageAlgorithm, IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            throw new System.NotImplementedException();
        }
    }
}