namespace Shops.Essence
{
    internal class AddressWithFlat : Address
    {
        public AddressWithFlat(string country, string city, string street, string building, string flat)
            : base(country, city, street, building)
        {
            Flat = flat;
        }

        public string Flat { get; }
    }
}