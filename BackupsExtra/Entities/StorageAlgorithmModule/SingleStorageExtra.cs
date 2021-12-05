using System.IO;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;

namespace BackupsExtra.Entities.StorageAlgorithmModule
{
    public class SingleStorageExtra : SingleStorage, IStorageAlgorithmExtra
    {
        public IRestorePoint MergeRestorePoints(IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            repository.RemoveZip(point1.Name);
            return point2;
        }

        public void DeleteRestorePoint(IRepositoryExtra repository, IRestorePoint point)
        {
            repository.RemoveZip(point.Name);
        }

        public void Restore(IRepositoryExtra repository, IRestorePoint point, string path)
        {
            path ??= string.Empty;
            repository.RestoreZip(point.Name);
            foreach (IStorage storage in point.GetStorages())
            {
                repository.CopyReplaceFile(Path.Combine(point.Name, storage.Name), Path.Combine(path, storage.Name));
            }

            repository.RemoveDirectory(point.Name);
        }
    }
}