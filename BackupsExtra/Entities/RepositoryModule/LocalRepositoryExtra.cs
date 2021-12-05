using System.IO;
using System.IO.Compression;
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

        public void RestoreZip(string path)
        {
            path = Path.Combine(RootPath, path);
            ZipFile.ExtractToDirectory(path + ".zip", path);
        }

        public void CopyReplaceFile(string fromPath, string toPath)
        {
            fromPath = Path.Combine(RootPath, fromPath);
            toPath = Path.Combine(RootPath, toPath);
            File.Copy(fromPath, toPath, true);
        }

        public void RemoveDirectory(string path)
        {
            path = Path.Combine(RootPath, path);
            Directory.Delete(path);
        }
    }
}