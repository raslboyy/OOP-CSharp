using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;

namespace Backups.Entities.RepositoryModule
{
    [DataContract]
    public class MockRepository : IRepository
    {
        public void SplitStorages(IRestorePoint restorePoint)
        {
        }

        public void SingleStorage(IRestorePoint restorePoint)
        {
        }

        public void AddJobObject(IJobObject jobObject)
        {
        }

        public void RemoveJobObject(IJobObject jobObject)
        {
        }

        public void UpdateJobObject(IJobObject jobObject)
        {
        }
    }
}