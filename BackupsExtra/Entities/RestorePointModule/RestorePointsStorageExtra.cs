using System.Linq;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    [DataContract]
    [KnownType(typeof(ByDateAlgorithm))]
    [KnownType(typeof(ByNumberAlgorithm))]
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

        public void Restore(string name, string path)
        {
            IRestorePoint point = RestorePoints.FirstOrDefault(p => p.Name == name);
            if (point == null)
                throw new RestorePointsStorageExtraException("No such restore point exists.");
            StorageAlgorithmExtra.Restore(RepositoryExtra, point, path);
        }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);
            LimitAlgorithm.Apply(this, RepositoryExtra, StorageAlgorithmExtra);
            return point;
        }
    }
}