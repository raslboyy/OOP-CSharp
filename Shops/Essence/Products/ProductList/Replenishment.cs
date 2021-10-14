namespace Shops.Essence.Products.ProductList
{
    internal class Replenishment : AProductList, IShopEvent
    {
        public Replenishment()
        {
            Status = Status.Processing;
        }

        public Status Status { get; }
    }
}