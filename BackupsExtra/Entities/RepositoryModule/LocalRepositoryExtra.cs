using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Xml;
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

        public BackupJobExtra Load()
        {
            var serializer = new DataContractSerializer(typeof(BackupJobExtra));
            var filestream = new FileStream(Path.Combine(RootPath, ".state"), FileMode.Open);
            var reader = XmlDictionaryReader.CreateTextReader(filestream, new XmlDictionaryReaderQuotas());
            return (BackupJobExtra)serializer.ReadObject(reader);
        }

        public void Save(BackupJobExtra backupJobExtra)
        {
            var serializer = new DataContractSerializer(typeof(BackupJobExtra));
            var writer = XmlWriter.Create(Path.Combine(RootPath, ".state"), new XmlWriterSettings
            {
                Indent = true,
            });
            serializer.WriteObject(writer, backupJobExtra);
            writer.Close();
        }

        private static void DeleteDirectory(string targetDir)
        {
            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(targetDir, false);
        }
    }
}