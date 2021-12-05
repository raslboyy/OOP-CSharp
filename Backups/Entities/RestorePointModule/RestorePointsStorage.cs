using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.StorageAlgorithmModule;

namespace Backups.Entities.RestorePointModule
{
    [DataContract]
    [KnownType(typeof(LocalRepository))]
    [KnownType(typeof(MockRepository))]
    [KnownType(typeof(SingleStorage))]
    [KnownType(typeof(SplitStorages))]
    [KnownType(typeof(RestorePoint))]
    public class RestorePointsStorage
    {
        public RestorePointsStorage(IRepository repository, IStorageAlgorithm storageAlgorithm)
        {
            Repository = repository;
            StorageAlgorithm = storageAlgorithm;
            RestorePoints = new LinkedList<IRestorePoint>();
        }

        [DataMember]
        protected LinkedList<IRestorePoint> RestorePoints { get; private set; }
        [DataMember]
        private IRepository Repository { get; set; }
        [DataMember]
        private IStorageAlgorithm StorageAlgorithm { get; set; }

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