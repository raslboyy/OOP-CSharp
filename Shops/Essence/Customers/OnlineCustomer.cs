using Shops.Essence.Products.ProductList;

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