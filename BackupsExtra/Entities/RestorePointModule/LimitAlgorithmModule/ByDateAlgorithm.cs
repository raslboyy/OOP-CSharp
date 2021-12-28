using System;
using System.Linq;
using System.Runtime.Serialization;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule
{
    [DataContract]
    [KnownType(typeof(PointsDeleteAlgorithm))]
    [KnownType(typeof(PointsMergeAlgorithm))]
    public class ByDateAlgorithm : ILimitAlgorithm
    {
        public ByDateAlgorithm(IPointsDeleteAlgorithm pointsDeleteAlgorithm, int limitAge)
        {
            if (limitAge <= 0)
                throw new ByDateAlgorithmException("ageLimit must be positive.");
            PointsDeleteAlgorithm = pointsDeleteAlgorithm;
        }

        [DataMember]
        public IPointsDeleteAlgorithm PointsDeleteAlgorithm { get; private set; }
        [DataMember]
        public int LimitAge { get; private set; }

        public void Apply(RestorePointsStorage restorePointsStorage, IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm)
        {
            int number =
                restorePointsStorage.RestorePoints.Count(point => point.Time < DateTime.Now.AddDays(-LimitAge));
            PointsDeleteAlgorithm.Apply(restorePointsStorage, number, storageAlgorithm, repository);
        }
    }
}