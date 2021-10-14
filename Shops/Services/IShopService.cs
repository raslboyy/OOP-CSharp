using Shops.Essence;

namespace Shops.Services
{
    internal interface IShopService
    {
        ShopName RegisterShop(string name, Address address);
        ShopName GetShopName(string name);
        void AddToShopCart(ShopName shopName, string productName, uint count, uint price);
        void Replenishment(ShopName shopName);
        void ChangePrice(ShopName shopName, string productName, uint newPrice);
        bool ContainsProduct(ShopName shopName, string productName);
        uint GetPrice(ShopName shopName, string productName);
    }
}