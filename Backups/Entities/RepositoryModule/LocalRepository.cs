using System;
using System.IO;
using System.IO.Compression;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;
using Backups.Tools;

namespace Backups.Entities.RepositoryModule
{
    public class LocalRepository : IRepository
    {
        protected const string RootPath = ".backup";
        protected const string JobObjects = "JobObjects";

        public LocalRepository()
        {
            Directory.CreateDirectory(RootPath);
            CreateDirectory(JobObjects);
        }

        public static void CreateFile(string name)
        {
            string path = Path.Combine(RootPath, name);
            File.Create(path);
        }

        public static void CreateDirectory(string name)
        {
            string path = Path.Combine(RootPath, name);
            Directory.CreateDirectory(path);
        }

        public static void CopyFile(string from, string to) => File.Copy(from, to);

        public static void ToZip(IRestorePoint restorePoint, IStorage storage)
        {
            string jobObjectPath = Path.Combine(RootPath, JobObjects, storage.JobObject.Name);

            CreateDirectory(Path.Combine(restorePoint.Name, storage.Name));
            string startPath = Path.Combine(RootPath, restorePoint.Name, storage.Name);
            string copyPath = Path.Combine(startPath, storage.JobObject.Name);
            CopyFile(jobObjectPath, copyPath);
            string zipPath = Path.Combine(RootPath, restorePoint.Name, storage.Name + ".zip");

            ZipFile.CreateFromDirectory(startPath, zipPath);
            File.Delete(copyPath);
            Directory.Delete(startPath);
        }

        public void AddJobObject(IJobObject jobObject)
        {
            if (jobObject == null)
                throw new ArgumentNullException(nameof(jobObject));
            string from = jobObject.Name;
            string to = Path.Combine(RootPath, JobObjects, jobObject.Name);
            if (!File.Exists(from))
                throw new RepositoryException("File of jobObject not found.");
            RemoveJobObject(jobObject);
            CopyFile(from, to);
        }

        public void RemoveJobObject(IJobObject jobObject)
        {
            if (jobObject == null)
                throw new ArgumentNullException(nameof(jobObject));
            string path = Path.Combine(RootPath, JobObjects, jobObject.Name);
            if (File.Exists(path))
                File.Delete(path);
        }

        public void UpdateJobObject(IJobObject jobObject) => AddJobObject(jobObject);

        public void SplitStorages(IRestorePoint restorePoint)
        {
            if (restorePoint == null)
                throw new ArgumentNullException(nameof(restorePoint));
            CreateDirectory(restorePoint.Name);
            foreach (IStorage storage in restorePoint.GetStorages())
            {
                ToZip(restorePoint, storage);
            }
        }

        public void SingleStorage(IRestorePoint restorePoint)
        {
            if (restorePoint == null)
                throw new ArgumentNullException(nameof(restorePoint));
            string startPath = Path.Combine(RootPath, JobObjects);
            string zipPath = Path.Combine(RootPath, restorePoint.Name + ".zip");
            ZipFile.CreateFromDirectory(startPath, zipPath);
        }
    }
}