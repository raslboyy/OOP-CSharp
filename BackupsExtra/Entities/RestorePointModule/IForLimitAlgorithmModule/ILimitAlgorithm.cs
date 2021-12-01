using Backups.Entities.RestorePointModule;

namespace BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule
{
    public interface ILimitAlgorithm
    {
        IRestorePoint Execute(IRestorePoint point1, IRestorePoint point2);
    }
}