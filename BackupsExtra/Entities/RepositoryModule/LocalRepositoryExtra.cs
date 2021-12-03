using System.IO;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;

namespace BackupsExtra.Entities.RepositoryModule
{
    public class LocalRepositoryExtra : LocalRepository, IRepositoryExtra
    {
        public void RemoveZip(string path)
        {
            path = Path.Combine(RootPath, path + ".zip");
            File.Delete(path);
        }

        public void MoveZip(string fromPath, string toPath)
        {
            fromPath = Path.Combine(RootPath, fromPath + ".zip");
            toPath = Path.Combine(RootPath, toPath + ".zip");
            File.Move(fromPath, toPath);
        }
    }
}