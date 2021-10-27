using Shops.Entity;
using Shops.Entity.ForCustomer;
using Shops.Entity.ForProduct;
using Shops.Entity.ForShop;
using Shops.Essence;

namespace Shops.Services
{
    public interface ICustomerService
    {
        ICustomer RegisterCustomer(string name, int balance);
        ICustomer RegisterOnlineCustomer(string name, int balance, Address address);
        IShop FindCheapestShop(params NeededProductAndCount[] list);
        IProduct FindProduct(IShop shop, string name);
        bool Buy(ICustomer customer, IShop shop, params NeededProductAndCount[] list);
    }
}