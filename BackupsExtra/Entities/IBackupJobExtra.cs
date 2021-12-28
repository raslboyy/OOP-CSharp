using Backups.Entities;

namespace BackupsExtra.Entities
{
    public interface IBackupJobExtra : IBackupJob
    {
        void Restore(string restorePointName, string path = null);
    }
}