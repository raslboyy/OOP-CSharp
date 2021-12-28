using System.Runtime.Serialization;
using Backups.Entities.RestorePointModule;
using BackupsExtra.Entities.RepositoryModule;
using BackupsExtra.Entities.StorageAlgorithmModule;
using BackupsExtra.Tools;

namespace BackupsExtra.Entities.RestorePointModule.LimitAlgorithmModule
{
    [DataContract]
    public class PointsDeleteAlgorithm : IPointsDeleteAlgorithm
    {
        public void Apply(RestorePointsStorage restorePointsStorage, int number, IStorageAlgorithmExtra storageAlgorithm, IRepositoryExtra repository)
        {
            for (int i = 0; i < number; i++)
            {
                if (restorePointsStorage.RestorePoints.Count < 2)
                    throw new PointsDeleteAlgorithmException("Size of restorePointsStorage is less then 2.");
                IRestorePoint point0 = restorePointsStorage.RestorePoints[0];
                IRestorePoint point1 = restorePointsStorage.RestorePoints[1];
                restorePointsStorage.RestorePoints[1] = Execute(storageAlgorithm, repository, point0, point1);
                restorePointsStorage.RestorePoints.RemoveAt(0);
            }
        }

        private static IRestorePoint Execute(IStorageAlgorithmExtra storageAlgorithm, IRepositoryExtra repository, IRestorePoint point1, IRestorePoint point2)
        {
            storageAlgorithm.DeleteRestorePoint(repository, point1);
            return point2;
        }
    }
}