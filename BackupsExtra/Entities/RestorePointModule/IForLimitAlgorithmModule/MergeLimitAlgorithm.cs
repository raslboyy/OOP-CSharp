using System.Runtime.Serialization;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule
{
    [DataContract]
    public class MergeLimitAlgorithm : ILimitAlgorithm
    {
        public IRestorePoint Execute(IStorageAlgorithmExtra storageAlgorithm, IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            return storageAlgorithm.MergeRestorePoints(repository, point1, point2);
        }
    }
}