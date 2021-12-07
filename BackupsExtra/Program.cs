using System.IO;
using BackupsExtra.Entities;
using BackupsExtra.Entities.LoggerModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            // var ser = new XmlSerializer(typeof(BackupJobExtra));
            // TextWriter writer = new StreamWriter(".config");
            // ser.Serialize(writer, backupJob);
            // writer.Close();
            // var backupJobExtra = new BackupJobExtra(new LocalRepositoryExtra());
            // backupJobExtra.CreateRestorePoint();
        }

        private static void Local1()
        {
            ILogger logger = new FileLogger("backup_log");
            logger = new TimeLogger(logger);
            var backupJob = new BackupJobExtra(
                "backup",
                new LocalRepositoryExtra(),
                new SingleStorageExtra(),
                logger,
                new ByNumberAlgorithm(new PointsDeleteAlgorithm(), 2));
            backupJob.AddFile("test1");
            backupJob.AddFile("test2");
            string point = backupJob.CreateRestorePoint();
            backupJob.Dispose();
        }

        private static void Local2()
        {
            var backupJob = new BackupJobExtra(new LocalRepositoryExtra());

            string point = backupJob.CreateRestorePoint();
            File.Delete("test1");
            backupJob.RemoveFile("test1");
            backupJob.CreateRestorePoint();

            backupJob.Restore(point);
        }
    }
}