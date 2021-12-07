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
    public class ByIntersectionAlgorithm : ILimitAlgorithm
    {
        public ByIntersectionAlgorithm(IPointsDeleteAlgorithm pointsDeleteAlgorithm, int limitAge, int limitSize)
        {
            PointsDeleteAlgorithm = pointsDeleteAlgorithm;
            if (limitSize <= 0)
                throw new ByIntersectionAlgorithmException("limitSize must be positive.");
            if (limitAge <= 0)
                throw new ByIntersectionAlgorithmException("ageLimit must be positive.");
        }

        [DataMember]
        public IPointsDeleteAlgorithm PointsDeleteAlgorithm { get; private set; }
        [DataMember]
        public int LimitSize { get; private set; }
        [DataMember]
        public int LimitAge { get; private set; }

        public void Apply(RestorePointsStorage restorePointsStorage, IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm)
        {
            int number =
                Math.Max(0, LimitSize - restorePointsStorage.RestorePoints.Count);
            number =
                Math.Min(number, restorePointsStorage.RestorePoints.Count(point => point.Time < DateTime.Now.AddDays(-LimitAge)));
            PointsDeleteAlgorithm.Apply(restorePointsStorage, number, storageAlgorithm, repository);
        }
    }
}