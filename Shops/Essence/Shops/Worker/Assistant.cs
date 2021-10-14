using Shops.Essence.Customers;
using Shops.Essence.Products.ProductList;
using Shops.Tools.Shop;

namespace Shops.Essence.Shops.Worker
{
    internal class Assistant : AWorker
    {
        public Assistant(Shop shop)
            : base(shop)
        {
        }

        public bool Work(Customer customer, Cart cart)
        {
            if (customer == null)
                throw new AssistantException("Customer cannot be null.");
            Order order = customer.CreateOrder();
            order = FillOrder(order, cart);
            if (order == null || customer.Balance < order.Coast)
                return false;
            StorageWorker storageWorker = InShop.StorageWorker;
            customer.ChangeBalance(order);
            storageWorker.ProcessOrder(order);
            return true;
        }

        public uint? GetCoast(Cart cart)
        {
            Order order = FillOrder(new Order(), cart);
            return order?.Coast;
        }

        private Order FillOrder(Order order, Cart cart)
        {
            if (cart == null)
                throw new AssistantException("Cart cannot be null.");
            if (order == null)
                throw new AssistantException("Order cannot be null");
            StorageWorker storageWorker = InShop.StorageWorker;
            foreach (Cart.Item item in cart.List)
            {
                if (storageWorker.Count(item.Name) < item.Count)
                    return null;
                uint price = storageWorker.GetPrice(item.Name);
                order.Add(item.Name, price, item.Count);
            }

            return order;
        }
    }
}