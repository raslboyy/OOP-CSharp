using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;

namespace BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule
{
    public class DeleteLimitAlgorithm : ILimitAlgorithm
    {
        public IRestorePoint Execute(IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            throw new System.NotImplementedException();
        }
    }
}