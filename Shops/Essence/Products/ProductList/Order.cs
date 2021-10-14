namespace Shops.Essence.Products.ProductList
{
    internal class Order : AProductList, IShopEvent
    {
        public Order()
        {
            Coast = 0u;
            Status = Status.Create;

            AddProduct += (price, count) => Coast += price * count;
            RemoveProduct += (price, count) => Coast -= price * count;
        }

        public delegate void OrderHandler(uint price, uint count = 1);

        public event OrderHandler AddProduct;
        public event OrderHandler RemoveProduct;
        public Status Status { get; }
        public uint Coast { get; private set; }

        public override bool Remove(ProductName name, uint count = 1)
        {
            uint price = Get(name).Price;
            if (!base.Remove(name, count)) return false;
            RemoveProduct?.Invoke(price, count);
            return true;
        }

        public override void Add(string name, uint price, uint count = 1)
        {
            base.Add(name, price, count);
            AddProduct?.Invoke(price, count);
        }
    }
}