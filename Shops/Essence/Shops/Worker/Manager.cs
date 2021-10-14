using Shops.Essence.Products.ProductList;
using Shops.Tools.Shop;

namespace Shops.Essence.Shops.Worker
{
    internal class Manager : AWorker
    {
        public Manager(Shop shop)
            : base(shop)
        {
        }

        public void Work(Cart cart)
        {
            if (cart == null)
                throw new ManagerException("Cart cannot be null.");
            var replenishment = new Replenishment();
            StorageWorker storageWorker = InShop.StorageWorker;
            foreach (Cart.Item item in cart.List)
                replenishment.Add(item.Name, item.Price, item.Count);
            storageWorker.ProcessReplenishment(replenishment);
        }
    }
}