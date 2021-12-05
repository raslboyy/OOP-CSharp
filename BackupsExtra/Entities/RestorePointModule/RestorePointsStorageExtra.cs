using System;
using System.Linq;
using System.Runtime.Serialization;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule.IForLimitAlgorithmModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    [DataContract]
    [KnownType(typeof(DeleteLimitAlgorithm))]
    [KnownType(typeof(MergeLimitAlgorithm))]
    [KnownType(typeof(LocalRepositoryExtra))]
    [KnownType(typeof(SingleStorageExtra))]
    [KnownType(typeof(SplitStoragesExtra))]
    public abstract class RestorePointsStorageExtra : RestorePointsStorage, IRestorePointsStorageExtra
    {
        protected RestorePointsStorageExtra(IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm)
            : base(repository, storageAlgorithm)
        {
            LimitAlgorithm = new DeleteLimitAlgorithm();
            RepositoryExtra = repository;
            StorageAlgorithmExtra = storageAlgorithm;
        }

        [DataMember]
        public ILimitAlgorithm LimitAlgorithm { get; private set; }
        [DataMember]
        protected IRepositoryExtra RepositoryExtra { get; private set; }
        [DataMember]
        protected IStorageAlgorithmExtra StorageAlgorithmExtra { get; private set; }

        public void SetMergeLimitAlgorithm() => LimitAlgorithm = new MergeLimitAlgorithm();
        public void SetDeleteLimitAlgorithm() => LimitAlgorithm = new DeleteLimitAlgorithm();
        public void Restore(string name, string path)
        {
            IRestorePoint point = RestorePoints.FirstOrDefault(p => p.Name == name);
            if (point == null)
                throw new RestorePointsStorageExtraException("No such restore point exists.");
            StorageAlgorithmExtra.Restore(RepositoryExtra, point, path);
        }
    }
}