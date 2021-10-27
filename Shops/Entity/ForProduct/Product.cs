namespace Shops.Entity.ForProduct
{
    public class Product : IProduct
    {
        public Product(string name, uint price = 0, uint count = 1)
        {
            Name = new ProductName(name);
            Price = price;
            Count = count;
        }

        public Product(ProductName name, uint price = 0, uint count = 1)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public ProductName Name { get; }
        public uint Price { get; private set; }
        public uint Count { get; private set; }

        public static bool operator ==(Product left, Product right) =>
            ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));

        public static bool operator !=(Product left, Product right) => !(left == right);

        public bool UpdatePrice(uint price)
        {
            if (price <= Price)
                return false;
            Price = price;
            return true;
        }

        public void AddCount(uint count) => Count += count;

        public bool SubtractCount(uint count)
        {
            if (count > Count)
                return false;
            Count -= count;
            return true;
        }

        public uint GetCoast() => Count * Price;

        public override bool Equals(object obj) => Equals(obj as Product);

        public bool Equals(Product other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Name == other.Name;
        }

        public override int GetHashCode() => Name.GetHashCode();
    }
}