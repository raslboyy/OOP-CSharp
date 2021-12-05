using System.IO;
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
        }
    }
}