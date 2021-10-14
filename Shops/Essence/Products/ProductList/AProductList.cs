using System.Collections.Generic;
using Shops.Tools.Product;

namespace Shops.Essence.Products.ProductList
{
    internal abstract class AProductList
    {
        private readonly Dictionary<Product, Product> _products;

        protected AProductList() => _products = new Dictionary<Product, Product>();

        public virtual void Add(string name, uint price, uint count = 1)
        {
            var product = new Product(name, price, count);
            if (_products.ContainsKey(product))
            {
                _products[product].AddCount(count);
                _products[product].UpdatePrice(price);
            }
            else
            {
                _products[product] = product;
            }
        }

        public IEnumerable<Product> GetProducts() => _products.Values;

        public virtual bool Remove(ProductName name, uint count = 1)
        {
            var product = new Product(name.Name);
            return _products.ContainsKey(product) && _products[product].SubtractCount(count);
        }

        public uint Count(string name)
        {
            Product product = Find(name);
            return product == null ? 0 : product.Count;
        }

        protected Product Find(string name)
        {
            var product = new Product(name);
            return _products.ContainsKey(product) ? _products[product] : null;
        }

        protected Product Get(ProductName name)
        {
            var product = new Product(name.Name);
            if (!_products.ContainsKey(product))
                throw new ProductListException("The product list does not contain this product.");
            return _products[product];
        }
    }
}