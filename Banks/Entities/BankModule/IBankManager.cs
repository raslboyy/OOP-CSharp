using Banks.Entities.AccountModule;

namespace Banks.Entities.BankModule
{
    public interface IBankManager : IBank
    {
        public string Name { get; }
        AAccount FindAccount(int id);
        void SkipDays(int n);
    }
}