using Shops.Tools.Shop;

namespace Shops.Entity.ForShop
{
    public abstract class AWorker
    {
        protected AWorker(IShop shop) => Shop = shop ?? throw new AWorkerException("Shop cannot be null.");

        protected IShop Shop { get; }
    }
}