using Shops.Entity.ForProduct;
using Shops.Entity.ForShop;
using Shops.Essence;

namespace Shops.Services
{
    public interface IShopService
    {
        IShop RegisterShop(string name, Address address);
        void Replenishment(IShop shop, params IProduct[] list);
        void ChangePrice(IShop shop, string productName, uint newPrice);
        bool ContainsProduct(IShop shop, string productName);
        uint GetPrice(IShop shop, string productName);
    }
}