using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using BackupsExtra.Entities;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            var storage = new RestorePointsStorageByNumber(new LocalRepositoryExtra(), new SplitStoragesExtra(), 2);
            storage.SetMergeLimitAlgorithm();
            IBackupJobExtra backupJob = new BackupJobExtra(
                "backup",
                new LocalRepositoryExtra(),
                storage);
            backupJob.AddFile("test1");
            backupJob.AddFile("test2");
            string point = backupJob.CreateRestorePoint();

            File.Delete("test1");
            backupJob.RemoveFile("test1");

            point = backupJob.CreateRestorePoint();
            backupJob.CreateRestorePoint();

            backupJob.Restore(point);

            var ser = new XmlSerializer(typeof(BackupJobExtra));
            TextWriter writer = new StreamWriter(".config");
            ser.Serialize(writer, backupJob);
            writer.Close();
        }
    }
}