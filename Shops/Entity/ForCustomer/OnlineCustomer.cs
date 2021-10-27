using Shops.Entity;
using Shops.Entity.ForCustomer;
using Shops.Entity.ForProduct;

namespace Shops.Essence.Customers
{
    internal class OnlineCustomer : Customer
    {
        public OnlineCustomer(string name, int balance, Address address)
            : base(name, balance)
        {
            Address = address;
        }

        public Address Address { get; }

        public override Order CreateOrder() => new OnlineOrder(Address);
    }
}