using Shops.Essence.Products;
using Shops.Essence.Products.ProductList;
using Shops.Tools.Shop;

namespace Shops.Essence.Shops.Worker
{
    internal class StorageWorker : AWorker
    {
        private readonly Storage _storage;

        public StorageWorker(Shop shop)
            : base(shop)
        {
            _storage = new Storage();
        }

        public void ProcessOrder(Order order)
        {
            if (order == null)
                throw new StorageWorkerException("Order cannot be null.");
            foreach (Product item in order.GetProducts())
                _storage.Remove(item.Name, item.Count);
        }

        public void ProcessReplenishment(Replenishment replenishment)
        {
            if (replenishment == null)
                throw new StorageWorkerException("Replenishment cannot be null.");
            foreach (Product item in replenishment.GetProducts())
                _storage.Add(item.Name.ToString(), item.Price, item.Count);
        }

        public uint Count(string name) => _storage.Count(name);
        public uint GetPrice(string name) => _storage.GetPrice(new ProductName(name));
    }
}