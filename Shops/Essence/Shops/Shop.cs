using Shops.Essence.Shops.Worker;
using Shops.Services;
using Shops.Tools.Shop;

namespace Shops.Essence.Shops
{
    internal class Shop
    {
        public Shop(string name, Address address)
        {
            Name = new ShopName(name);
            Address = address ?? throw new ShopException("Address cannot be null.");
            StorageWorker = new StorageWorker(this);
        }

        public StorageWorker StorageWorker { get; }
        public ShopName Name { get; }
        public Address Address { get; }
        public override int GetHashCode() => Name.GetHashCode();
    }
}