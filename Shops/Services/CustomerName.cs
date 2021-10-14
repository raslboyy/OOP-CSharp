namespace Shops.Services
{
    public readonly struct CustomerName
    {
        public CustomerName(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static bool operator ==(CustomerName left, CustomerName right) => left.Equals(right);
        public static bool operator !=(CustomerName left, CustomerName right) => !(left == right);
        public override bool Equals(object obj) => obj is CustomerName other && Equals(other);
        public bool Equals(CustomerName other) => Name.Equals(other.Name);
        public override int GetHashCode() => Name != null ? Name.GetHashCode() : 0;
    }
}