using Shops.Entity.PersonModule;
using Shops.Entity.ProductModule;

namespace Shops.Entity.ShopModule
{
    public interface IShop
    {
        string Name { get; }
        void AddProducts(params ProductCountPrice[] list);
        bool Buy(IPerson person, params ProductCount[] list);
        ProductCountPrice GetProductInfo(IProduct product);
        void ChangePrice(IProduct product, uint newPrice);
        uint GetCoast(params ProductCount[] list);
    }
}