namespace Shops.Essence.Products.ProductList
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