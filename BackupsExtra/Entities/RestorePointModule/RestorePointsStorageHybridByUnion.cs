using System;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageHybridByUnion : RestorePointsStorageExtra
    {
        public RestorePointsStorageHybridByUnion(IRepositoryExtra repository, IStorageAlgorithm storageAlgorithm, int limitAge, int limitSize)
            : base(repository, storageAlgorithm)
        {
            if (LimitAge <= 0)
                throw new RestorePointsStorageHybridByUnionException("limitAge must be positive.");
            LimitAge = limitAge;
            if (limitSize <= 0)
                throw new RestorePointsStorageHybridByUnionException("limitSize must be positive.");
            LimitSize = limitSize;
        }

        public int LimitAge { get; }
        public int LimitSize { get; }

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
                }
                else
                {
                    point2 = point1;
                }

                IRestorePoint result = LimitAlgorithm.Execute(RepositoryExtra, point1, point2);
                RestorePoints.AddFirst(result);
            }

            return point;
        }
    }
}