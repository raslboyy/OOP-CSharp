using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Entity.ProductModule;
using Shops.Entity.ShopModule;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        public ShopManager() => Shops = new List<IShop>();
        private List<IShop> Shops { get; }

        public IShop Create(string name)
        {
            var shop = new Shop(name);
            Shops.Add(shop);
            return shop;
        }

        public IProduct RegisterProduct(string name) => new Product(name);

        public IShop FindCheapestShop(params ProductCount[] list)
        {
            uint min = Shops.Aggregate(uint.MaxValue, (current, shop) => Math.Min(current, shop.GetCoast(list)));
            return Shops.Count(item => item.GetCoast(list) == min) != 1 ? null : Shops.FirstOrDefault(item => item.GetCoast(list) == min);
        }
    }
}