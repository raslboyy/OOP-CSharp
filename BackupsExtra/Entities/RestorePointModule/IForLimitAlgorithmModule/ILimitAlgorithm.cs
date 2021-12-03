using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;

namespace BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule
{
    public interface ILimitAlgorithm
    {
        IRestorePoint Execute(IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2);
    }
}