using System;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    [DataContract]
    public class RestorePointsStorageHybridByUnion : RestorePointsStorageExtra
    {
        public RestorePointsStorageHybridByUnion(IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm, int limitAge, int limitSize)
            : base(repository, storageAlgorithm)
        {
            if (LimitAge <= 0)
                throw new RestorePointsStorageHybridByUnionException("limitAge must be positive.");
            LimitAge = limitAge;
            if (limitSize <= 0)
                throw new RestorePointsStorageHybridByUnionException("limitSize must be positive.");
            LimitSize = limitSize;
        }

        [DataMember]
        public int LimitAge { get; private set; }
        [DataMember]
        public int LimitSize { get; private set; }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);

            while (RestorePoints.Count > LimitSize || (RestorePoints.First != null && RestorePoints.First.Value.Time < DateTime.Now.AddDays(-LimitAge)))
            {
                if (RestorePoints.First == null)
                    throw new RestorePointsStorageHybridByUnionException();
                IRestorePoint point1 = RestorePoints.First.Value;
                RestorePoints.RemoveFirst();
                IRestorePoint point2;
                if (RestorePoints.First != null)
                {
                    point2 = RestorePoints.First.Value;
                    RestorePoints.RemoveFirst();
                    RestorePoints.AddFirst(LimitAlgorithm.Execute(StorageAlgorithmExtra, RepositoryExtra, point1, point2));
                }
                else
                {
                    point2 = point1;
                    LimitAlgorithm.Execute(StorageAlgorithmExtra, RepositoryExtra, point1, point2);
                }
            }

            return point;
        }
    }
}