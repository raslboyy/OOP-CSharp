using System.Linq;
using Shops.Entity.PersonModule;
using Shops.Entity.ProductModule;

namespace Shops.Entity.ShopModule
{
    public static class StorageManager
    {
        public static void AddProducts(IStorage storage, params ProductCountPrice[] list)
        {
            foreach (ProductCountPrice product in list)
            {
                storage.AddProduct(product);
            }
        }

        public static bool Buy(IStorage storage, IPerson person, params ProductCount[] list)
        {
            if (list.Any(product => !storage.CheckProduct(product)))
            {
                return false;
            }

            int coast = (int)storage.GetCoast(list);
            if (coast > person.Balance)
                return false;

            person.Balance -= coast;

            foreach (ProductCount product in list)
            {
                storage.RemoveProduct(product);
            }

            return true;
        }
    }
}