using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    [DataContract]
    public class RestorePointsStorageByDate : RestorePointsStorageExtra
    {
        public RestorePointsStorageByDate(IRepositoryExtra repository, IStorageAlgorithmExtra storageAlgorithm, int limitAge)
            : base(repository, storageAlgorithm)
        {
            if (limitAge <= 0)
                throw new RestorePointsStorageByDateException("ageLimit must be positive.");
            LimitAge = limitAge;
        }

        [DataMember]
        public int LimitAge { get; private set; }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);

            while (RestorePoints.First != null && RestorePoints.First.Value.Time < DateTime.Now.AddDays(-LimitAge))
            {
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