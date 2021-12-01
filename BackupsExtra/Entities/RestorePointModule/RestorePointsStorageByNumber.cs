using Backups.Entities.JobObjectModule;
using Backups.Entities.RepositoryModule;
using Backups.Entities.RestorePointModule;
using Backups.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule
{
    public class RestorePointsStorageByNumber : RestorePointsStorageExtra
    {
        public RestorePointsStorageByNumber(IRepository repository, IStorageAlgorithm storageAlgorithm, int limitSize)
            : base(repository, storageAlgorithm)
        {
            if (limitSize <= 0)
                throw new RestorePointStorageByNumberException("limitSize must be positive.");
            LimitSize = limitSize;
        }

        public int LimitSize { get; }

        public override IRestorePoint Add(JobObjectsStorage jobObjectsStorage)
        {
            IRestorePoint point = base.Add(jobObjectsStorage);
            if (RestorePoints.Count <= LimitSize) return point;
            if (RestorePoints.First == null)
                throw new RestorePointStorageByNumberException();
            if (RestorePoints.First.Next == null)
                throw new RestorePointStorageByNumberException();
            IRestorePoint point1 = RestorePoints.First.Value;
            IRestorePoint point2 = RestorePoints.First?.Next?.Value;
            IRestorePoint result = LimitAlgorithm.Execute(point1, point2);
            RestorePoints.RemoveFirst();
            RestorePoints.RemoveFirst();
            RestorePoints.AddFirst(result);
            return point;
        }
    }
}