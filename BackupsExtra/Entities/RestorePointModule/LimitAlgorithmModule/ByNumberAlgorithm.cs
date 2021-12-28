using System;
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
    public class ByNumberAlgorithm : ILimitAlgorithm
    {
        public ByNumberAlgorithm(IPointsDeleteAlgorithm pointsesDeleteAlgorithm, int limitSize)
        {
            PointsDeleteAlgorithm = pointsesDeleteAlgorithm;
            if (limitSize <= 0)
                throw new ByNumberAlgorithmException("limitSize must be positive.");
            LimitSize = limitSize;
        }

        [DataMember]
        public IPointsDeleteAlgorithm PointsDeleteAlgorithm { get; private set; }
        [DataMember]
        public int LimitSize { get; private set; }

        public void Apply(RestorePointsStorage restorePointsStorage, IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm)
        {
            int number =
                Math.Max(0, restorePointsStorage.RestorePoints.Count - LimitSize);
            PointsDeleteAlgorithm.Apply(restorePointsStorage, number, storageAlgorithm, repository);
        }
    }
}