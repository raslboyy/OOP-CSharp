using Shops.Tools;

namespace Shops.Entity.ProductModule
{
    public readonly struct ProductCount
    {
        public ProductCount(IProduct product, uint count)
        {
            Product = product ?? throw new ProductModuleException("Product cannot be null.");
            Count = count;
        }

        public IProduct Product { get; }
        public uint Count { get; }
    }
}