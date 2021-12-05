using System;
using System.Runtime.Serialization;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;

namespace Backups.Entities.StorageAlgorithmModule
{
    [DataContract]
    public class SingleStorage : IStorageAlgorithm
    {
        public void SaveRestorePoint(IRepository repository, IRestorePoint restorePoint) =>
            repository.SingleStorage(restorePoint);
    }
}