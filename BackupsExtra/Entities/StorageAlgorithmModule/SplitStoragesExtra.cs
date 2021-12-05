using System;
using System.IO;
using System.Runtime.Serialization;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;

namespace BackupsExtra.Entities.StorageAlgorithmModule
{
    [DataContract]
    public class SplitStoragesExtra : SplitStorages, IStorageAlgorithmExtra
    {
        public IRestorePoint MergeRestorePoints(IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            foreach (IStorage storage in point1.GetStorages())
            {
                if (point2.ContainsJobObject(storage.JobObject.Name)) continue;
                point2.AddStorage(storage);
                repository.MoveZip(Path.Combine(point1.Name, storage.Name), Path.Combine(point2.Name, storage.Name));
            }

            repository.RemoveDirectory(point1.Name);
            return point2;
        }

        public void DeleteRestorePoint(IRepositoryExtra repository, IRestorePoint point)
        {
            repository.RemoveDirectory(point.Name);
        }

        public void Restore(IRepositoryExtra repository, IRestorePoint point, string path)
        {
            path ??= string.Empty;
            foreach (IStorage storage in point.GetStorages())
            {
                repository.RestoreZip(Path.Combine(point.Name, storage.Name));
                repository.CopyReplaceFile(Path.Combine(point.Name, storage.Name, storage.Name), Path.Combine(path, storage.Name));
                repository.RemoveDirectory(Path.Combine(point.Name, storage.Name));
            }
        }
    }
}