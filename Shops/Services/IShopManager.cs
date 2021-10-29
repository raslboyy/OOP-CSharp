using Shops.Entity.ProductModule;
using Shops.Entity.ShopModule;

namespace Shops.Services
{
    public interface IShopManager
    {
        IShop Create(string name);
        IProduct RegisterProduct(string name);
        IShop FindCheapestShop(params ProductCount[] list);
    }
}