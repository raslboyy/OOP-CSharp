namespace Shops.Entity.ForProduct
{
    internal class Storage : AProductList
    {
        public uint GetPrice(ProductName name) => Get(name).Price;
    }
}