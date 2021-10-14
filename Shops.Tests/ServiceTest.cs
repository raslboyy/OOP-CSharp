using NUnit.Framework;
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
            ShopName shop = RegisterDefaultShop(service);
            CustomerName customer = RegisterDefaultCustomer(service);

            service.AddToShopCart(shop, "Cheese", 10, 10);
            service.AddToShopCart(shop, "Milk", 10, 5);
            service.AddToShopCart(shop, "Ball", 100, 2);
            service.Replenishment(shop);
            service.AddToCustomerCart(customer, "Cheese", 5);
            service.AddToCustomerCart(customer, "Milk", 1);
            bool actual = service.Buy(customer, shop);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void ChangePrice_PriceChanged()
        {
            Service service = CreateDefaultService();
            ShopName shop = RegisterDefaultShop(service);

            uint expected = 10;
            service.AddToShopCart(shop, "Cheese", 10, 0);
            service.Replenishment(shop);
            service.ChangePrice(shop, "Cheese", expected);
            uint actual = service.GetPrice(shop, "Cheese");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(10u, 100u, 1u)]
        [TestCase(100u, 10u, 2u)]
        public void FindCheapestShop_AnswerExist_ReturnCheapestShop(uint price1, uint price2, uint expectedNumber)
        {
            Service service = CreateDefaultService();
            CustomerName customer = RegisterDefaultCustomer(service);
            ShopName shop1 = service.RegisterShop("Shop1", CreateDefaultAddress());
            ShopName shop2 = service.RegisterShop("Shop2", CreateDefaultAddress());

            service.AddToShopCart(shop1, "default", 1, price1);
            service.AddToShopCart(shop2, "default", 1, price2);
            service.Replenishment(shop1);
            service.Replenishment(shop2);
            service.AddToCustomerCart(customer, "default", 1);
            ShopName actual = service.FindCheapestShop(customer);

            Assert.AreEqual((expectedNumber == 1 ? shop1 : shop2), actual);
        }

        [Test]
        public void FindCheapestShop_AnswerDoesntExist_ReturnNullShop()
        {
            Service service = CreateDefaultService();
            CustomerName customer = RegisterDefaultCustomer(service);
            ShopName shop1 = service.RegisterShop("Shop1", CreateDefaultAddress());
            ShopName shop2 = service.RegisterShop("Shop2", CreateDefaultAddress());

            service.AddToShopCart(shop1, "default", 9, 0);
            service.AddToShopCart(shop2, "otherDefault", 10, 0);
            service.Replenishment(shop1);
            service.Replenishment(shop2);
            service.AddToCustomerCart(customer, "default", 10);
            ShopName actual = service.FindCheapestShop(customer);

            Assert.AreEqual(null, actual);
        }

        [Test]
        public void Buy_DefaultOrder_ChangeBalanceAndChangeStorage()
        {
            const int startBalance = 100;
            Service service = CreateDefaultService();
            CustomerName customer = service.RegisterCustomer("Customer", startBalance);
            ShopName shop = RegisterDefaultShop(service);

            const int defaultPrice = 1;
            service.AddToShopCart(shop, "Product1", 10, defaultPrice);
            service.AddToShopCart(shop, "Product2", 10, defaultPrice);
            service.Replenishment(shop);
            service.AddToCustomerCart(customer, "Product1", 10);
            service.AddToCustomerCart(customer, "Product2", 3);
            service.Buy(customer, shop);
            (int, bool) actual = (service.RequestBalance(customer), service.ContainsProduct(shop, "Product1"));

            (int, bool) expected = (startBalance - defaultPrice * 13, false);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Buy_BalanceIsntEnough_BuyReturnFalse()
        {
            const int startBalance = 10;
            Service service = CreateDefaultService();
            CustomerName customer = service.RegisterCustomer("Customer", startBalance);
            ShopName shop = RegisterDefaultShop(service);

            const int defaultPrice = 1;
            service.AddToShopCart(shop, "Product1", 10, defaultPrice);
            service.AddToShopCart(shop, "Product2", 10, defaultPrice);
            service.Replenishment(shop);
            service.AddToCustomerCart(customer, "Product1", 10);
            service.AddToCustomerCart(customer, "Product2", 3);
            bool actual = service.Buy(customer, shop);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Buy_NoSuchProduct_BuyReturnFalse()
        {
            const int startBalance = 100;
            Service service = CreateDefaultService();
            CustomerName customer = service.RegisterCustomer("Customer", startBalance);
            ShopName shop = RegisterDefaultShop(service);

            const int defaultPrice = 1;
            service.AddToShopCart(shop, "Product1", 1, defaultPrice);
            service.AddToShopCart(shop, "Product2", 1, defaultPrice);
            service.Replenishment(shop);
            service.AddToCustomerCart(customer, "Product1", 10);
            service.AddToCustomerCart(customer, "Product2", 3);
            bool actual = service.Buy(customer, shop);

            Assert.AreEqual(false, actual);
        }

        private static CustomerName RegisterDefaultCustomer(Service service) =>
            service.RegisterCustomer("Customer", 100);

        private static ShopName RegisterDefaultShop(Service service) =>
            service.RegisterShop("Shop", CreateDefaultAddress());

        private static Address CreateDefaultAddress() => new Address("Country", "City", "Street", "Building");
        private static Service CreateDefaultService() => new Service();
    }
}