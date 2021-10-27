using Shops.Essence;

namespace Shops.Entity.ForProduct
{
    internal class OnlineOrder : Order
    {
        public OnlineOrder(Address address)
        {
            Address = address;
        }

        public Address Address { get; }
    }
}