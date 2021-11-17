using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;

namespace Backups.Entities.RepositoryModule
{
    public interface IRepository
    {
        void SplitStorages(IRestorePoint restorePoint);
        void SingleStorage(IRestorePoint restorePoint);
        void AddJobObject(IJobObject jobObject);
        void RemoveJobObject(IJobObject jobObject);
        void UpdateJobObject(IJobObject jobObject);
    }
}