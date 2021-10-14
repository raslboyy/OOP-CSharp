using Shops.Essence.Products.ProductList;
using Shops.Services;
using Shops.Tools.Customer;

namespace Shops.Essence.Customers
{
    internal class Customer
    {
        public Customer(string name, int balance)
        {
            Name = new CustomerName(name);
            Balance = balance;
        }

        public CustomerName Name { get; }
        public int Balance { get; private set; }
        public virtual Order CreateOrder() => new Order();

        public virtual bool ChangeBalance(Order order)
        {
            if (order == null)
                throw new CustomerException("Order cannot be null.");
            if (Balance < order.Coast)
                return false;
            Balance -= (int)order.Coast;
            return true;
        }

        public override int GetHashCode() => Name.GetHashCode();
    }
}