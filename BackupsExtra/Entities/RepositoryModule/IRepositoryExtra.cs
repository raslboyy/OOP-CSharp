using Backups.Entities.RepositoryModule;

namespace BackupsExtra.Entities.RepositoryModule
{
    public interface IRepositoryExtra : IRepository
    {
        void RemoveZip(string path);
        void MoveZip(string fromPath, string toPath);
        void RestoreZip(string path);
        void CopyReplaceFile(string fromPath, string toPath);
        void RemoveDirectory(string path);
        BackupJobExtra Load();
        void Save(BackupJobExtra backupJobExtra);
    }
}