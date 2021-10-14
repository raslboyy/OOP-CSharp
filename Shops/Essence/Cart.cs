using System.Collections.Generic;

namespace Shops.Essence
{
    internal class Cart
    {
        public Cart()
        {
            List = new List<Item>();
        }

        public List<Item> List { get; }

        public void Add(string name, uint count, uint price = 0u) => List.Add(new Item(name, count, price));
        public void Clear() => List.Clear();

        public struct Item
        {
            public Item(string name, uint count, uint price)
            {
                Name = name;
                Count = count;
                Price = price;
            }

            public string Name { get; }
            public uint Count { get; }
            public uint Price { get; set; }
        }
    }
}