namespace Banks.Entities.ClientModule
{
    public class Client : IClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public bool IsGood { get; set; }
    }
}