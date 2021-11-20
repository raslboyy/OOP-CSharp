using Banks.Entities.AccountModule;

namespace Banks.Entities.ClientModule
{
    public interface IClient
    {
        public bool IsGood { get; }
        public IAccount CreateDebitAccount(double value);
        public IAccount CreateDepositAccount(double value, int term);
        public IAccount CreateCreditAccount(double value);
    }
}