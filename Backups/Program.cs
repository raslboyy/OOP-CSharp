using System;
using Backups.Entities;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            IBackupJob backupJob = new BackupJob("backup", new LocalRepository(), new SingleStorage());
            backupJob.AddFile("test1");
            backupJob.AddFile("test2");
            backupJob.CreateRestorePoint();
        }
    }
}