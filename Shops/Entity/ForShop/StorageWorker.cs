using Shops.Entity.ForProduct;
using Shops.Tools.Shop;

namespace Shops.Entity.ForShop
{
    public class StorageWorker : AWorker
    {
        private readonly Storage _storage;

        public StorageWorker(IShop shop)
            : base(shop)
        {
            _storage = new Storage();
        }

        public void ProcessOrder(Order order)
        {
            if (order == null)
                throw new StorageWorkerException("Order cannot be null.");
            _storage.Remove(order);
        }

        public void ProcessReplenishment(Replenishment replenishment)
        {
            if (replenishment == null)
                throw new StorageWorkerException("Replenishment cannot be null.");
            _storage.Add(replenishment);
        }

        public uint Count(ProductName name) => _storage.Count(name);
        public uint GetPrice(ProductName name) => _storage.GetPrice(name);

        public IProduct FindProduct(string name) => _storage.Find(new ProductName(name));
    }
}