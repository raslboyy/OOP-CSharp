using System;
using Shops.Tools;

namespace Shops.Entity.ProductModule
{
    public class ProductCountPrice : ICloneable
    {
        public ProductCountPrice(IProduct product, uint count, uint price)
        {
            Product = product ?? throw new ProductModuleException("Product cannot be null.");
            Count = count;
            Price = price;
        }

        public IProduct Product { get; }
        public uint Count { get; set; }
        public uint Price { get; set; }

        public object Clone() => MemberwiseClone();
    }
}