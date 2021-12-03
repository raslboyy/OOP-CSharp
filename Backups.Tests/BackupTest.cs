using System.IO;
using System.Linq;
using Backups.Entities;
using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTest
    {
        [Test]
        public void AddFile_FileInJobObjects()
        {
            var backup = new BackupJob("backup", new MockRepository(), new SplitStorages());

            backup.AddFile("file");
            bool actual = backup.JobObjects.Contains("file");

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void RemoveFile_FileNotInDirectory()
        {
            var backup = new BackupJob("backup", new MockRepository(), new SplitStorages());

            backup.AddFile("file");
            backup.RemoveFile("file");
            bool actual = backup.JobObjects.Contains("file");

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void CreateRestorePoint_AddFiles_StoragesInRestorePoint()
        {
            var backup = new BackupJob("backup", new MockRepository(), new SplitStorages());

            backup.AddFile("file1");
            backup.AddFile("file2");
            string name = backup.CreateRestorePoint();
            bool actual = backup.RestorePoints.Find(name).ContainsJobObject("file1") &&
                          backup.RestorePoints.Find(name).ContainsJobObject("file2");

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void CreateRestorePoint_TwoRestorePoint_InFirstOneFileInSecondTwoFiles()
        {
            var backup = new BackupJob("backup", new MockRepository(), new SplitStorages());

            backup.AddFile("file1");
            string name1 = backup.CreateRestorePoint();
            backup.AddFile("file2");
            string name2 = backup.CreateRestorePoint();
            bool actual = backup.RestorePoints.Find(name1).ContainsJobObject("file1") &&
                          backup.RestorePoints.Find(name2).ContainsJobObject("file1") &&
                          backup.RestorePoints.Find(name2).ContainsJobObject("file2");

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void CreateRestorePoint_AddTwoFilesRemoveOneFile_CreatedTwoPointsAndThreeStorages()
        {
            var backup = new BackupJob("backup", new MockRepository(), new SplitStorages());

            backup.AddFile("file1");
            backup.AddFile("file2");
            string name1 = backup.CreateRestorePoint();
            backup.RemoveFile("file2");
            string name2 = backup.CreateRestorePoint();
            bool actual = (backup.RestorePoints.Find(name1) != null) && (backup.RestorePoints.Find(name2) != null) &&
                          backup.RestorePoints.Find(name1).ContainsJobObject("file1") &&
                          backup.RestorePoints.Find(name1).ContainsJobObject("file2") &&
                          backup.RestorePoints.Find(name2).ContainsJobObject("file1");
            
            Assert.AreEqual(true, actual);
        }
    }
}