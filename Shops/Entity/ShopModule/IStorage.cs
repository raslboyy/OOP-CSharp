using Shops.Entity.ProductModule;

namespace Shops.Entity.ShopModule
{
    public interface IStorage
    {
        void AddProduct(ProductCountPrice product);
        void RemoveProduct(ProductCount product);
        ProductCountPrice FindProduct(IProduct product);
        bool CheckProduct(ProductCount product);
        uint GetCoast(params ProductCount[] list);
    }
}