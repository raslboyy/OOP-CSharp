using System.Collections.Generic;
using System.Linq;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;

namespace Backups.Entities.RestorePointModule
{
    public class RestorePointsStorage : IRestorePointsStorage
    {
        public RestorePointsStorage(IRepository repository, IStorageAlgorithm storageAlgorithm)
        {
            Repository = repository;
            StorageAlgorithm = storageAlgorithm;
            RestorePoints = new LinkedList<IRestorePoint>();
        }

        private IRepository Repository { get; }
        private IStorageAlgorithm StorageAlgorithm { get; }
        private LinkedList<IRestorePoint> RestorePoints { get; }

        public virtual IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            var point = new RestorePoint(jobObjectsStorage, Repository, RestorePoints.Count);
            RestorePoints.AddLast(point);
            StorageAlgorithm.SaveRestorePoint(Repository, point);
            return point;
        }

        public IRestorePoint Find(string name) => RestorePoints.LastOrDefault(point => point.Name == name);
    }
}