using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule;
using BackupsExtra.Entities.StorageAlgorithmModule;

namespace BackupsExtra.Entities.RestorePointModule
{
    [DataContract]
    [KnownType(typeof(ByDateAlgorithm))]
    [KnownType(typeof(ByNumberAlgorithm))]
    [KnownType(typeof(ByIntersectionAlgorithm))]
    [KnownType(typeof(ByUnionAlgorithm))]
    [KnownType(typeof(LocalRepositoryExtra))]
    [KnownType(typeof(SingleStorageExtra))]
    [KnownType(typeof(SplitStoragesExtra))]
    public class RestorePointsStorageExtra : RestorePointsStorage
    {
        public RestorePointsStorageExtra(
            IRepositoryExtra repository,
            IStorageAlgorithmExtra storageAlgorithm,
            ILimitAlgorithm limitAlgorithm)
            : base(repository, storageAlgorithm)
        {
            LimitAlgorithm = limitAlgorithm;
            RepositoryExtra = repository;
            StorageAlgorithmExtra = storageAlgorithm;
        }

        [DataMember]
        protected ILimitAlgorithm LimitAlgorithm { get; private set; }
        [DataMember]
        protected IRepositoryExtra RepositoryExtra { get; private set; }
        [DataMember]
        protected IStorageAlgorithmExtra StorageAlgorithmExtra { get; private set; }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);
            LimitAlgorithm.Apply(this, RepositoryExtra, StorageAlgorithmExtra);
            return point;
        }
    }
}