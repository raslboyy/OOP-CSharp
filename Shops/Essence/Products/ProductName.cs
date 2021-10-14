namespace Shops.Essence.Products
{
    internal readonly struct ProductName
    {
        public ProductName(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static bool operator ==(ProductName left, ProductName right) => left.Equals(right);

        public static bool operator !=(ProductName left, ProductName right) => !(left == right);

        public override bool Equals(object obj) => obj is ProductName other && Equals(other);
        public bool Equals(ProductName other) => Name.Equals(other.Name);

        public override int GetHashCode() => Name != null ? Name.GetHashCode() : 0;

        public override string ToString() => Name;
    }
}