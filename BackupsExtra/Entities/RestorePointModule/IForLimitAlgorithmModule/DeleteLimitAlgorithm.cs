using Backups.Entities.RestorePointModule;

namespace BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule
{
    public class DeleteLimitAlgorithm : ILimitAlgorithm
    {
        public IRestorePoint Execute(IRestorePoint point1, IRestorePoint point2) => point2;
    }
}