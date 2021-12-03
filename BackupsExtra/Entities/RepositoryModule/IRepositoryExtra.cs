using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;

namespace BackupsExtra.Entities.RepositoryModule
{
    public interface IRepositoryExtra : IRepository
    {
        void RemoveZip(string path);
        void MoveZip(string fromPath, string toPath);
    }
}