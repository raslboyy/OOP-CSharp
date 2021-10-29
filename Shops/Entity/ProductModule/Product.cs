using System;
using Shops.Tools;

namespace Shops.Entity.ProductModule
{
    public class Product : IProduct
    {
        public Product(string name) =>
            Name = name ?? throw new ProductModuleException("Name cannot be null.");

        public string Name { get; }
    }
}