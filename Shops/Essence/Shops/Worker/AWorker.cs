using Shops.Tools.Shop;

namespace Shops.Essence.Shops.Worker
{
    internal abstract class AWorker
    {
        protected AWorker(Shop shop) => InShop = shop ?? throw new AWorkerException("Shop cannot be null.");

        protected Shop InShop { get; }
    }
}