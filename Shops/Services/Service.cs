using System.Collections.Generic;
using Shops.Essence;
using Shops.Essence.Customers;
using Shops.Essence.Shops;
using Shops.Essence.Shops.Worker;
using Shops.Tools.Service;

namespace Shops.Services
{
    public class Service : ICustomerService, IShopService
    {
        private readonly Dictionary<int, Cart> _shopCarts;
        private readonly Dictionary<int, Cart> _customerCarts;
        private readonly Dictionary<int, Shop> _shops;
        private readonly Dictionary<int, Customer> _customers;

        public Service()
        {
            _shopCarts = new Dictionary<int, Cart>();
            _customerCarts = new Dictionary<int, Cart>();
            _shops = new Dictionary<int, Shop>();
            _customers = new Dictionary<int, Customer>();
        }

        public CustomerName RegisterCustomer(string name, int balance) => AddCustomer(new Customer(name, balance)).Name;

        public CustomerName RegisterOnlineCustomer(string name, int balance, Address address) =>
            AddCustomer(new OnlineCustomer(name, balance, address)).Name;

        public CustomerName GetCustomerName(string name) => GetCustomer(new CustomerName(name)).Name;

        public void AddToCustomerCart(CustomerName customerName, string productName, uint count) =>
            _customerCarts[customerName.GetHashCode()].Add(productName, count);

        public ShopName FindCheapestShop(CustomerName customerName)
        {
            Cart cart = _customerCarts[customerName.GetHashCode()];
            uint? min = null;
            ShopName cheapestShop = null;
            foreach ((int key, Shop shop) in _shops)
            {
                uint? coast = new Assistant(shop).GetCoast(cart);
                if (coast == null || (min != null && !(coast < min))) continue;
                min = coast;
                cheapestShop = shop.Name;
            }

            return cheapestShop;
        }

        public int RequestBalance(CustomerName customerName) => _customers[customerName.GetHashCode()].Balance;

        public bool Buy(CustomerName customerName, ShopName shopName)
        {
            Customer customer = _customers[customerName.GetHashCode()];
            Cart cart = _customerCarts[customerName.GetHashCode()];
            Shop shop = _shops[shopName.GetHashCode()];
            var assistant = new Assistant(shop);

            bool result = assistant.Work(customer, cart);
            if (result)
                cart.Clear();
            return result;
        }

        public ShopName RegisterShop(string name, Address address) => AddShop(new Shop(name, address)).Name;

        public ShopName GetShopName(string name) => GetShop(new ShopName(name)).Name;

        public void AddToShopCart(ShopName shopName, string productName, uint count, uint price) =>
            _shopCarts[shopName.GetHashCode()].Add(productName, count, price);

        public void Replenishment(ShopName shopName)
        {
            Shop shop = _shops[shopName.GetHashCode()];
            Cart cart = _shopCarts[shopName.GetHashCode()];
            var manager = new Manager(shop);
            manager.Work(cart);

            cart.Clear();
        }

        public void ChangePrice(ShopName shopName, string productName, uint newPrice)
        {
            AddToShopCart(shopName, productName, 0, newPrice);
            Replenishment(shopName);
        }

        public uint GetPrice(ShopName shopName, string productName) =>
            _shops[shopName.GetHashCode()].StorageWorker.GetPrice(productName);

        public bool ContainsProduct(ShopName shopName, string productName) =>
            _shops[shopName.GetHashCode()].StorageWorker.Count(productName) > 0;

        private Customer AddCustomer(Customer customer)
        {
            var customerCart = new Cart();
            _customers.Add(customer.GetHashCode(), customer);
            _customerCarts.Add(customer.GetHashCode(), customerCart);
            return customer;
        }

        private Customer GetCustomer(CustomerName name)
        {
            int key = name.GetHashCode();
            if (!_customers.ContainsKey(key))
                throw new ServiceException("There is no customer in the system with that name.");
            return _customers[key];
        }

        private Shop AddShop(Shop shop)
        {
            var shopCart = new Cart();
            _shops.Add(shop.GetHashCode(), shop);
            _shopCarts.Add(shop.GetHashCode(), shopCart);
            return shop;
        }

        private Shop GetShop(ShopName name)
        {
            int key = name.GetHashCode();
            if (!_shops.ContainsKey(key))
                throw new ServiceException("There is no shop in the system with that name.");
            return _shops[key];
        }
    }
}