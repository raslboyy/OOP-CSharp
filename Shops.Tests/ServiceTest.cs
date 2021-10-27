using NUnit.Framework;
using Shops.Entity;
using Shops.Entity.ForCustomer;
using Shops.Entity.ForProduct;
using Shops.Entity.ForShop;
using Shops.Essence;
using Shops.Services;

namespace Shops.Tests
{
    public class ServiceTest
    {
        [Test]
        public void Replenishment_AddProducts_ProductsCanBeBought()
        {
            Service service = CreateDefaultService();
            IShop shop = RegisterDefaultShop(service);
            ICustomer customer = RegisterDefaultCustomer(service);

            service.Replenishment(shop,
                new Product("Cheese", 10, 10),
                new Product("Milk", 10, 5),
                new Product("Ball", 100, 2)
            );
            bool actual = service.Buy(customer, shop,
                new NeededProductAndCount(service.FindProduct(shop, "Cheese"), 5),
                new NeededProductAndCount(service.FindProduct(shop, "Milk"), 1)
            );

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void ChangePrice_PriceChanged()
        {
            Service service = CreateDefaultService();
            IShop shop = RegisterDefaultShop(service);

            const uint expected = 10;
            service.Replenishment(shop, new Product("Cheese", 10, 0));
            service.ChangePrice(shop, "Cheese", expected);
            uint actual = service.GetPrice(shop, "Cheese");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10u, 100u, 1u)]
        [TestCase(100u, 10u, 2u)]
        public void FindCheapestShop_AnswerExist_ReturnCheapestShop(uint price1, uint price2, uint expectedNumber)
        {
            Service service = CreateDefaultService();
            ICustomer customer = RegisterDefaultCustomer(service);
            IShop shop1 = service.RegisterShop("Shop1", CreateDefaultAddress());
            IShop shop2 = service.RegisterShop("Shop2", CreateDefaultAddress());

            service.Replenishment(shop1, new Product("default", price1, 1));
            service.Replenishment(shop2, new Product("default", price2, 1));
            IShop actual = service.FindCheapestShop(new NeededProductAndCount(service.FindProduct(shop1, "default"), 1));

            Assert.AreEqual((expectedNumber == 1 ? shop1 : shop2), actual);
        }

        [Test]
        public void FindCheapestShop_AnswerDoesntExist_ReturnNullShop()
        {
            Service service = CreateDefaultService();
            ICustomer customer = RegisterDefaultCustomer(service);
            IShop shop1 = service.RegisterShop("Shop1", CreateDefaultAddress());
            IShop shop2 = service.RegisterShop("Shop2", CreateDefaultAddress());

            service.Replenishment(shop1, new Product("default", 9, 0));
            service.Replenishment(shop2, new Product("otherDefault", 10, 0));
            IShop actual = service.FindCheapestShop(new Product("default", 10));

            Assert.AreEqual(null, actual);
        }

        [Test]
        public void Buy_DefaultOrder_ChangeBalanceAndChangeStorage()
        {
            const int startBalance = 100;
            Service service = CreateDefaultService();
            ICustomer customer = service.RegisterCustomer("Customer", startBalance);
            IShop shop = RegisterDefaultShop(service);

            const int defaultPrice = 1;
            service.Replenishment(shop,
                new Product("Product1", defaultPrice, 10),
                new Product("Product2", defaultPrice, 10)
            );
            service.Buy(customer, shop,
                new NeededProductAndCount(service.FindProduct(shop, "Product1"), 10),
                new NeededProductAndCount(service.FindProduct(shop, "Product2"), 3)
            );
            (int, bool) actual = (customer.Balance, service.ContainsProduct(shop, "Product1"));

            (int, bool) expected = (startBalance - defaultPrice * 13, false);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Buy_BalanceIsNotEnough_BuyReturnFalse()
        {
            const int startBalance = 10;
            Service service = CreateDefaultService();
            ICustomer customer = service.RegisterCustomer("Customer", startBalance);
            IShop shop = RegisterDefaultShop(service);

            const int defaultPrice = 1;
            service.Replenishment(shop,
                new Product("Product1", 10, defaultPrice),
                new Product("Product2", 10, defaultPrice)
            );
            bool actual = service.Buy(customer, shop,
                new Product("Product1", 10),
                new Product("Product2", 3)
            );

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Buy_NoSuchProduct_BuyReturnFalse()
        {
            const int startBalance = 100;
            Service service = CreateDefaultService();
            ICustomer customer = service.RegisterCustomer("Customer", startBalance);
            IShop shop = RegisterDefaultShop(service);

            const int defaultPrice = 1;
            service.Replenishment(shop,
                new Product("Product1", 1, defaultPrice),
                new Product("Product2", 1, defaultPrice)
            );
            bool actual = service.Buy(customer, shop,
                new Product("Product1", 10),
                new Product("Product2", 3)
            );

            Assert.AreEqual(false, actual);
        }

        private static ICustomer RegisterDefaultCustomer(ICustomerService service) =>
            service.RegisterCustomer("Customer", 100);

        private static IShop RegisterDefaultShop(IShopService service) =>
            service.RegisterShop("Shop", CreateDefaultAddress());

        private static Address CreateDefaultAddress() => new Address("Country", "City", "Street", "Building");
        private static Service CreateDefaultService() => new Service();
    }
}