namespace Shops.Entity.ForProduct
{
    public class Order : AProductList
    {
        public Order()
        {
            Coast = 0u;

            // AddProduct += (price, count) => Coast += price * count;
            // RemoveProduct += (price, count) => Coast -= price * count;
        }

        public delegate void OrderHandler(uint price, uint count = 1);

        // public event OrderHandler AddProduct;
        // public event OrderHandler RemoveProduct;
        public uint Coast { get; private set; }

        // public override bool Remove(ProductName name, uint count = 1)
        // {
        //     uint price = Get(name).Price;
        //     if (!base.Remove(name, count)) return false;
        //     RemoveProduct?.Invoke(price, count);
        //     return true;
        // }

        // public override void Add(string name, uint price, uint count = 1)
        // {
        //     base.Add(name, price, count);
        //     AddProduct?.Invoke(price, count);
        // }
        public override void Add(AProductList other)
        {
            Coast += other.GetCoast();
            base.Add(other);
        }

        public override bool Remove(AProductList other)
        {
            bool result = base.Remove(other);
            if (result)
                Coast -= other.GetCoast();
            return result;
        }

        public override void Add(IProduct product)
        {
            Coast += product.GetCoast();
            base.Add(product);
        }

        public override bool Remove(IProduct product)
        {
            bool result = base.Remove(product);
            if (result)
                Coast -= product.GetCoast();
            return result;
        }
    }
}