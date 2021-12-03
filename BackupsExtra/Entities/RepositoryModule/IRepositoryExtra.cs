using Backups.Entities.RepositoryModule;

namespace BackupsExtra.Entities.RepositoryModule
{
    public interface IRepositoryExtra : IRepository
    {
        void RemoveDirectory(string path);
    }
}