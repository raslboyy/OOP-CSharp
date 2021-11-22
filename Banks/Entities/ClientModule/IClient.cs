using Banks.Entities.AccountModule;

namespace Banks.Entities.ClientModule
{
    public interface IClient
    {
        public string Address { get; set; }
        public string Passport { get; set; }
        public bool IsGood { get; }
        public IAccount CreateDebitAccount(double value);
        public IAccount CreateDepositAccount(double value, int term);
        public IAccount CreateCreditAccount(double value);
    }
}