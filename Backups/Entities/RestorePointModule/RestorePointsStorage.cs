using System.Collections.Generic;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;

namespace Backups.Entities.RestorePointModule
{
    public class RestorePointsStorage
    {
        public RestorePointsStorage(IRepository repository, IStorageAlgorithm storageAlgorithm)
        {
            Repository = repository;
            StorageAlgorithm = storageAlgorithm;
            RestorePoints = new List<IRestorePoint>();
        }

        private IRepository Repository { get; }
        private IStorageAlgorithm StorageAlgorithm { get; }
        private List<IRestorePoint> RestorePoints { get; }

        public IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            var point = new RestorePoint(jobObjectsStorage, Repository, RestorePoints.Count);
            RestorePoints.Add(point);
            StorageAlgorithm.SaveRestorePoint(Repository, point);
            return point;
        }

        public IRestorePoint Find(string name) => RestorePoints.Find(point => point.Name == name);
    }
}