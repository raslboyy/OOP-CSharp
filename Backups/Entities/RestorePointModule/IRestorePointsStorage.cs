using Backups.Entities.JobObjectModule;

namespace Backups.Entities.RestorePointModule
{
    public interface IRestorePointsStorage
    {
        IRestorePoint Add(JobObjectsStorage jobObjectsStorage);
    }
}