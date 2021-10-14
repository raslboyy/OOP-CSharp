namespace Shops.Essence.Products.ProductList
{
    internal class Storage : AProductList
    {
        public uint GetPrice(ProductName name) => Get(name).Price;
    }
}