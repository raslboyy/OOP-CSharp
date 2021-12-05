using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    public interface IRestorePointsStorageExtra
    {
        IRestorePoint Add(JobObjectsStorage jobObjectsStorage);
        void Restore(string name, string path);
    }
}