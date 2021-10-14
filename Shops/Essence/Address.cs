namespace Shops.Essence
{
    public class Address
    {
        public Address(string country, string city, string street, string building)
        {
            Country = country;
            City = city;
            Street = street;
            Building = building;
        }

        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string Building { get; }
    }
}