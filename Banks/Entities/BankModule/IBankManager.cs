using Banks.Entities.AccountModule;

namespace Banks.Entities.BankModule
{
    public interface IBankManager
    {
        AAccount FindAccount(int id);
        void SkipDays(int n);
    }
}