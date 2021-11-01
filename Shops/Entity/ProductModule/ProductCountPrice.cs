using System;
using Shops.Tools;

namespace Shops.Entity.ProductModule
{
    public class ProductCountPrice
    {
        public ProductCountPrice(IProduct product, uint count, uint price)
        {
            Product = product ?? throw new ProductModuleException("Product cannot be null.");
            Count = count;
            Price = price;
        }

        public IProduct Product { get; private set; }
        public uint Count { get; set; }
        public uint Price { get; set; }

        public ProductCountPrice DeepCopy()
        {
            var other = (ProductCountPrice)this.MemberwiseClone();
            other.Product = new Product(Product.Name);
            return other;
        }
    }
}