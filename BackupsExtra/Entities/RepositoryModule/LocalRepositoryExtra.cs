using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using Backups.Entities.RepositoryModule;

namespace BackupsExtra.Entities.RepositoryModule
{
    [DataContract]
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
            File.Copy(fromPath, toPath, true);
        }

        public void RemoveDirectory(string path)
        {
            path = Path.Combine(RootPath, path);
            DeleteDirectory(path);
        }

        private static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
}