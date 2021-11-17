using Backups.Entities.JobObjectModule;

namespace Backups.Entities.RestorePointModule
{
    public interface IStorage
    {
        public string Name { get; }
        public IJobObject JobObject { get; }
    }
}