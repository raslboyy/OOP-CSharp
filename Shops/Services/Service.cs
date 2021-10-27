using System.Collections.Generic;
using System.Linq;
using Shops.Entity;
using Shops.Entity.ForCustomer;
using Shops.Entity.ForProduct;
using Shops.Entity.ForShop;
using Shops.Essence;
using Shops.Essence.Customers;

namespace Shops.Services
{
    public class Service : ICustomerService, IShopService
    {
        private readonly List<IShop> _shops;

        public Service()
        {
            _shops = new List<IShop>();
        }

        public ICustomer RegisterCustomer(string name, int balance) => new Customer(name, balance);

        public ICustomer RegisterOnlineCustomer(string name, int balance, Address address) =>
            new OnlineCustomer(name, balance, address);

        public IShop FindCheapestShop(params NeededProductAndCount[] list)
        {
            uint? min = null;
            IShop cheapestShop = null;
            foreach (IShop shop in _shops)
            {
                uint? coast = new Assistant(shop).GetCoast(list);
                if (coast == null || (min != null && !(coast < min))) continue;
                min = coast;
                cheapestShop = shop;
            }

            return cheapestShop;
        }

        public IProduct FindProduct(IShop shop, string name) => shop.StorageWorker.FindProduct(name);

        public bool Buy(ICustomer customer, IShop shop, params NeededProductAndCount[] list)
        {
            var productList = list.Select(item => new Product(item.Product.Name, item.Product.Price, item.Count)).Cast<IProduct>().ToList();
            return new Assistant(shop).Work(customer, productList.ToArray());
        }

        public IShop RegisterShop(string name, Address address) => AddShop(new Shop(name, address));

        public void Replenishment(IShop shop, params IProduct[] list) => new Manager(shop).Work(list);

        public void ChangePrice(IShop shop, string productName, uint newPrice) =>
            Replenishment(shop, new Product(productName, newPrice, 0));

        public uint GetPrice(IShop shop, string productName) =>
            shop.StorageWorker.GetPrice(new ProductName(productName));

        public bool ContainsProduct(IShop shop, string productName) =>
            shop.StorageWorker.Count(new ProductName(productName)) > 0;

        private IShop AddShop(IShop shop)
        {
            _shops.Add(shop);
            return shop;
        }
    }
}