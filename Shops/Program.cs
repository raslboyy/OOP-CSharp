using System;
using System.Collections;
using Shops.Essence;
using Shops.Essence.Customers;
using Shops.Services;

namespace Shops
{
    public class Program
    {
        private static void Main()
        {
            // Service service = CreateDefaultService();
            // ShopName shop = RegisterDefaultShop(service);
            // CustomerName customer = RegisterDefaultCustomer(service);
            //
            // service.AddToShopCart(shop, "Cheese", 10, 10);
            // service.AddToShopCart(shop, "Milk", 10, 5);
            // service.AddToShopCart(shop, "Ball", 100, 2);
            // service.Replenishment(shop);
            // service.AddToCustomerCart(customer, "Cheese", 5);
            // service.AddToCustomerCart(customer, "Milk", 1);
            // bool actual = service.Buy(customer, shop);
            //
            // Console.WriteLine(actual);
        }

        // private static CustomerName RegisterDefaultCustomer(Service service) =>
        //     service.RegisterCustomer("Customer", 100);
        //
        // private static ShopName RegisterDefaultShop(Service service) =>
        //     service.RegisterShop("Shop", CreateDefaultAddress());
        //
        // private static Address CreateDefaultAddress() => new Address("Country", "City", "Street", "Building");
        // private static Service CreateDefaultService() => new Service();
    }
}