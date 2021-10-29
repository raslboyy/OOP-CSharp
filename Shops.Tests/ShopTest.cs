using NUnit.Framework;
using Shops.Entity.PersonModule;
using Shops.Entity.ProductModule;
using Shops.Entity.ShopModule;
using Shops.Services;

namespace Shops.Tests
{
    public class ShopTest
    {
        [Test]
        public void Buy_CorrectBuy_ReturnTrue()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IPerson person = CreateDefaultPerson();
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");
            var product3 = new Product("Product3");

            shop.AddProducts(
                new ProductCountPrice(product1, 1, 1),
                new ProductCountPrice(product2, 1, 1),
                new ProductCountPrice(product3, 1, 1));
            bool actual = shop.Buy(person, new ProductCount(product2, 1));

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Buy_NoProductInTheShop_ReturnFalse()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IPerson person = CreateDefaultPerson();
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop.AddProducts(
                new ProductCountPrice(product1, 1, 1));
            bool actual = shop.Buy(person, new ProductCount(product2, 1));

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Buy_NotEnoughProducts_ReturnFalse()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IPerson person = CreateDefaultPerson();
            var product = new Product("Product1");

            shop.AddProducts(
                new ProductCountPrice(product, 1, 1));
            bool actual = shop.Buy(person, new ProductCount(product, 2));

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Buy_NotEnoughCustomerBalance_ReturnFalse()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IPerson person = CreateDefaultPerson();
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop.AddProducts(
                new ProductCountPrice(product1, 10, 20),
                new ProductCountPrice(product2, 10, 30));
            bool actual = shop.Buy(person, new ProductCount(product1, 2), new ProductCount(product2, 3));

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void ChangePrice_PriceChanged()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IProduct product = CreateDefaultProduct(shopManager);

            shop.AddProducts(new ProductCountPrice(product, 1, 0));
            shop.ChangePrice(product, 1);
            int actual = (int) shop.GetProductInfo(product).Price;

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void FindCheapestShop_AnswerExist_ReturnCheapestShop()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop1 = shopManager.Create("Shop1");
            IShop shop2 = shopManager.Create("Shop2");
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop1.AddProducts(new ProductCountPrice(product1, 10, 1),
                new ProductCountPrice(product2, 10, 2));
            shop2.AddProducts(new ProductCountPrice(product2, 10, 1),
                new ProductCountPrice(product1, 10, 2));
            IShop actual = shopManager.FindCheapestShop(new ProductCount(product1, 2), new ProductCount(product2, 4));

            Assert.AreSame(shop2, actual);
        }

        [Test]
        public void FindCheapestShop_AnswerIsNotUnique_ReturnNull()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop1 = shopManager.Create("Shop1");
            IShop shop2 = shopManager.Create("Shop2");
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop1.AddProducts(new ProductCountPrice(product1, 10, 1),
                new ProductCountPrice(product2, 10, 1));
            shop2.AddProducts(new ProductCountPrice(product2, 10, 1),
                new ProductCountPrice(product1, 10, 1));
            IShop actual = shopManager.FindCheapestShop(new ProductCount(product1, 2), new ProductCount(product2, 3));

            Assert.AreSame(null, actual);
        }

        [Test]
        public void FindCheapest_NoAnswer_ReturnNull()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop1 = shopManager.Create("Shop1");
            IShop shop2 = shopManager.Create("Shop2");
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop1.AddProducts(new ProductCountPrice(product1, 10, 1));
            shop2.AddProducts(new ProductCountPrice(product1, 10, 1));
            IShop actual = shopManager.FindCheapestShop(new ProductCount(product1, 2));

            Assert.AreSame(null, actual);
        }

        [Test]
        public void Buy_DefaultOrder_ChangeBalance()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IPerson person = CreateDefaultPerson();
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop.AddProducts(
                new ProductCountPrice(product1, 10, 2),
                new ProductCountPrice(product2, 10, 3)
            );
            shop.Buy(person,
                new ProductCount(product1, 2),
                new ProductCount(product2, 2)
            );
            int expected = CreateDefaultPerson().Balance - (int)shop.GetProductInfo(product1).Price * 2 - (int)shop.GetProductInfo(product2).Price * 2;
            int actual = person.Balance;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Buy_DefaultOrder_ChangeStorage()
        {
            ShopManager shopManager = CreateDefaultManager();
            IShop shop = CreateDefaultShop(shopManager);
            IPerson person = CreateDefaultPerson();
            var product1 = new Product("Product1");
            var product2 = new Product("Product2");

            shop.AddProducts(
                new ProductCountPrice(product1, 10, 2),
                new ProductCountPrice(product2, 9, 3)
            );
            shop.Buy(person,
                new ProductCount(product1, 2),
                new ProductCount(product2, 2)
            );
            
            Assert.AreEqual(8, shop.GetProductInfo(product1).Count);
            Assert.AreEqual(7, shop.GetProductInfo(product2).Count);
        }

        private static ShopManager CreateDefaultManager() => new ShopManager();
        private static IShop CreateDefaultShop(IShopManager shopManager) => shopManager.Create("Shop");
        private static IPerson CreateDefaultPerson() => new Person(100);

        private static IProduct CreateDefaultProduct(IShopManager shopManager) =>
            shopManager.RegisterProduct("Product");
    }
}