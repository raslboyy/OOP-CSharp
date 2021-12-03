using System.IO;
using Backups.Entities.RepositoryModule;

namespace BackupsExtra.Entities.RepositoryModule
{
    public class LocalRepositoryExtra : LocalRepository, IRepositoryExtra
    {
        public void RemoveDirectory(string path)
        {
            path = Path.Combine(RootPath, path + ".zip");
            File.Delete(path);
        }
    }
}