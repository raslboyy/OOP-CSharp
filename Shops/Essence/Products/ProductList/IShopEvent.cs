using System;

namespace Shops.Essence.Products.ProductList
{
    internal interface IShopEvent
    {
        public Status Status { get; }
        public static DateTime GetDate() => DateTime.Now;
    }
}