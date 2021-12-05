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
            IBackupJobExtra backupJob = new BackupJobExtra(
                "backup",
                new LocalRepositoryExtra(),
                new RestorePointsStorageByNumber(new LocalRepositoryExtra(), new SingleStorageExtra(), 2));
            backupJob.AddFile("test1");
            backupJob.AddFile("test2");
            string point = backupJob.CreateRestorePoint();

            File.WriteAllText("test1", "fdf");

            backupJob.Restore(point);
        }
    }
}