using Shops.Entity.ForCustomer;
using Shops.Entity.ForProduct;
using Shops.Tools.Shop;

namespace Shops.Entity.ForShop
{
    internal class Assistant : AWorker
    {
        public Assistant(IShop shop)
            : base(shop)
        {
        }

        public bool Work(ICustomer customer, params IProduct[] list)
        {
            if (customer == null)
                throw new AssistantException("Customer cannot be null.");
            Order order = customer.CreateOrder();
            order = FillOrder(order, list);
            if (order == null || customer.Balance < order.Coast)
                return false;
            StorageWorker storageWorker = Shop.StorageWorker;
            customer.ChangeBalance(order);
            storageWorker.ProcessOrder(order);
            return true;
        }

        public uint? GetCoast(params IProduct[] list)
        {
            Order order = FillOrder(new Order(), list);
            return order?.Coast;
        }

        private Order FillOrder(Order order, params IProduct[] list)
        {
            if (order == null)
                throw new AssistantException("Order cannot be null");
            StorageWorker storageWorker = Shop.StorageWorker;
            foreach (IProduct product in list)
            {
                if (storageWorker.Count(product.Name) < product.Count)
                    return null;
                order.Add(product);
            }

            return order;
        }
    }
}