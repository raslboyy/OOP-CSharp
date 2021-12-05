using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;

namespace Backups.Entities.RestorePointModule
{
    public class Storage : IStorage
    {
        public Storage(IJobObject jobObject, IRepository repository, int restorePointId)
        {
            JobObject = jobObject;
            Name = jobObject.Name;
            repository.UpdateJobObject(jobObject);
        }

        public string Name { get; }
        public IJobObject JobObject { get; }
    }
}