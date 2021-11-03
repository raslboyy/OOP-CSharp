namespace Backups.Entities
{
    public interface IBackupJob
    {
        void AddFile(string name);
        bool RemoveFile(string name);
        string CreateRestorePoint();
    }
}