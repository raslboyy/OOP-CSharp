using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Tools.Product;

namespace Shops.Entity.ForProduct
{
    public abstract class AProductList
    {
        private readonly List<IProduct> _products;

        protected AProductList() => _products = new List<IProduct>();

        public virtual void Add(AProductList other)
        {
            foreach (IProduct product in other._products)
                Add(product);
        }

        public virtual void Add(IProduct product)
        {
            IProduct oldProduct = Find(product);
            if (oldProduct != null)
            {
                uint count = oldProduct.Count + product.Count;
                uint price = oldProduct.Price > product.Price ? oldProduct.Price : product.Price;
                string name = oldProduct.Name.ToString();
                Remove(oldProduct);
                Add(new Product(name, price, count));
            }
            else
            {
                _products.Add(product);
            }
        }

        public virtual bool Remove(AProductList other)
        {
            foreach (IProduct product in other._products)
            {
                IProduct oldProduct = Find(product);
                if (oldProduct == null)
                    return false;
            }

            foreach (IProduct product in other._products)
                Remove(product);
            return true;
        }

        public virtual bool Remove(IProduct product)
        {
            IProduct oldProduct = Find(product);
            if (oldProduct == null || product.Count > oldProduct.Count)
                return false;
            string name = oldProduct.Name.ToString();
            uint price = oldProduct.Price;
            uint count = oldProduct.Count - product.Count;
            _products.Remove(oldProduct);
            _products.Add(new Product(name, price, count));
            return true;
        }

        public uint Count(ProductName name)
        {
            IProduct product = Find(name);
            return product?.Count ?? 0;
        }

        public uint GetCoast()
        {
            return _products.Aggregate<IProduct, uint>(0, (current, product) => current + product.GetCoast());
        }

        public IProduct Find(ProductName name) => Find(new Product(name.Name));

        protected IProduct Get(ProductName name)
        {
            IProduct product = Find(new Product(name.Name));
            if (product == null)
                throw new ProductListException("The product list does not contain this product.");
            return product;
        }

        protected IProduct Find(IProduct product) => _products.Find(value => Equals(value, product));
    }
}