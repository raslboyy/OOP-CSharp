namespace Backups.Entities
{
    public interface IBackupJob
    {
        void AddFile(string name);
        void RemoveFile(string name);
        string CreateRestorePoint();
    }
}