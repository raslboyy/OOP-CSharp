using Shops.Entity.ForProduct;
using Shops.Tools.Shop;

namespace Shops.Entity.ForShop
{
    internal class Manager : AWorker
    {
        public Manager(IShop shop)
            : base(shop)
        {
        }

        public void Work(params IProduct[] list)
        {
            var replenishment = new Replenishment();
            StorageWorker storageWorker = Shop.StorageWorker;
            foreach (IProduct product in list)
                replenishment.Add(product);
            storageWorker.ProcessReplenishment(replenishment);
        }
    }
}