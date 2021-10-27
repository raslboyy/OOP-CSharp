namespace Shops.Services
{
    public class ShopName
    {
        public ShopName(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static bool operator ==(ShopName left, ShopName right) =>
            ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));

        public static bool operator !=(ShopName left, ShopName right) => !(left == right);
        public override bool Equals(object obj) => Equals(obj as ShopName);

        public bool Equals(ShopName other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return ReferenceEquals(this, other) || Name.Equals(other.Name);
        }

        public override int GetHashCode() => Name != null ? Name.GetHashCode() : 0;
    }
}