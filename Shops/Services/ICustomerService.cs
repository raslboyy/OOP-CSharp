using Shops.Essence;

namespace Shops.Services
{
    internal interface ICustomerService
    {
        CustomerName RegisterCustomer(string name, int balance);
        CustomerName RegisterOnlineCustomer(string name, int balance, Address address);
        CustomerName GetCustomerName(string name);
        void AddToCustomerCart(CustomerName customerName, string productName, uint count);
        ShopName FindCheapestShop(CustomerName customerName);
        int RequestBalance(CustomerName customerName);
        bool Buy(CustomerName customerName, ShopName shopName);
    }
}