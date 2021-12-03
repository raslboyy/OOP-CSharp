using System;
using System.Collections.Generic;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageByDate : RestorePointsStorageExtra
    {
        public RestorePointsStorageByDate(IRepository repository, IStorageAlgorithm storageAlgorithm, int limitAge)
            : base(repository, storageAlgorithm)
        {
            if (limitAge <= 0)
                throw new RestorePointsStorageByDateException("ageLimit must be positive.");
            LimitAge = limitAge;
        }

        public int LimitAge { get; }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);
            {
                LinkedListNode<IRestorePoint> point1 = null;
                do
                {
                    LinkedListNode<IRestorePoint> point2 = point1;
                    point1 = RestorePoints.First;
                    RestorePoints.RemoveFirst();
                    if (point1 != null && point2 != null)
                        point1.ValueRef = LimitAlgorithm.Execute(point1.Value, point2.Value);
                }
                while (RestorePoints.First != null && RestorePoints.First.Value.Time < DateTime.Now.AddDays(-LimitAge));
            }

            return point;
        }
    }
}