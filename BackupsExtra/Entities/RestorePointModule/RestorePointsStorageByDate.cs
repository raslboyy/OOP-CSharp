using System;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageByDate : RestorePointsStorageExtra
    {
        public RestorePointsStorageByDate(IRepository repository, IStorageAlgorithm storageAlgorithm, int ageLimit)
            : base(repository, storageAlgorithm)
        {
            AgeLimit = ageLimit;
            if (ageLimit <= 0)
                throw new RestorePointsStorageByDateException("ageLimit must be positive.");
        }

        public int AgeLimit { get; }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);
            while (RestorePoints.First != null && RestorePoints.First.Value.Time < DateTime.Now.AddDays(-AgeLimit))
            {
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

                IRestorePoint result = LimitAlgorithm.Execute(point1, point2);
                RestorePoints.AddFirst(result);
            }

            return point;
        }
    }
}