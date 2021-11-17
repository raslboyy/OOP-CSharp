namespace Shops.Entity.PersonModule
{
    public class Person : IPerson
    {
        public Person(int balance) => Balance = balance;
        public int Balance { get; set; }
    }
}