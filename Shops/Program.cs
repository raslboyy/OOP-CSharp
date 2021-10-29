using System;
using System.Collections;
using Shops.Entity.ProductModule;

namespace Shops
{
    public class Program
    {
        private static void Main()
        {
            var p = new ProductCountPrice(new Product("fsdf"), 0, 4);
            Foo(p);
            Console.WriteLine(p.Count);
        }

        private static void Foo(ProductCountPrice p)
        {
            p = (ProductCountPrice)p.Clone();
            p.Count = 3;
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