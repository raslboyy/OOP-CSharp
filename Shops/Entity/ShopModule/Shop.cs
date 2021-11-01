using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Entity.PersonModule;
using Shops.Entity.ProductModule;
using Shops.Tools;

namespace Shops.Entity.ShopModule
{
    public class Shop : IShop, IStorage
    {
        public Shop(string name)
        {
            Name = name ?? throw new ShopModuleException("Name cannot be null.");
            Products = new List<ProductCountPrice>();
        }

        public string Name { get; }
        private List<ProductCountPrice> Products { get; }

        public void AddProducts(params ProductCountPrice[] list)
        {
            foreach (ProductCountPrice product in list)
            {
                AddProduct(product);
            }
        }

        public bool Buy(IPerson person, params ProductCount[] list)
        {
            if (list.Any(product => !CheckProduct(product)))
            {
                return false;
            }

            int coast = (int)GetCoast(list);
            if (coast > person.Balance)
                return false;

            person.Balance -= coast;

            foreach (ProductCount product in list)
            {
                RemoveProduct(product);
            }

            return true;
        }

        public ProductCountPrice GetProductInfo(IProduct product)
        {
            ProductCountPrice productCountPrice = FindProduct(product);
            if (productCountPrice == null)
                throw new ShopModuleException("Shop does not contains this product");
            return productCountPrice;
        }

        public void ChangePrice(IProduct product, uint newPrice) => GetProductInfo(product).Price = newPrice;

        public uint GetCoast(params ProductCount[] list) =>
            (uint)list.Sum(product => (int)FindProduct(product.Product).Price * (int)product.Count);

        public void AddProduct(ProductCountPrice product)
        {
            ProductCountPrice item = FindProduct(product.Product);
            if (item == null)
            {
                Products.Add(product.DeepCopy());
            }
            else
            {
                item.Count += product.Count;
                item.Price = Math.Max(item.Price, product.Price);
            }
        }

        public void RemoveProduct(ProductCount product) =>
            FindProduct(product.Product).Count -= product.Count;

        public ProductCountPrice FindProduct(IProduct product) =>
            Products.Find(item => item.Product.Name == product.Name);

        public bool CheckProduct(ProductCount product)
        {
            ProductCountPrice item = FindProduct(product.Product);
            if (item == null)
                return false;
            return item.Count >= product.Count;
        }
    }
}