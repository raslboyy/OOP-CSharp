using Shops.Essence;
using Shops.Services;
using Shops.Tools.Shop;

namespace Shops.Entity.ForShop
{
    internal class Shop : IShop
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