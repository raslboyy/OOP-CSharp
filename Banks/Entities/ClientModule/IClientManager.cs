using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.BankConfigurationModule;

namespace Banks.Entities.ClientModule
{
    public interface IClientManager
    {
        bool IsGood { get; }
        bool IsNotified { get; set; }
        BankConfiguration Configuration { get; }
        AAccount FindAccount(int id);
        void SkipDays(int n = 1);
    }
}