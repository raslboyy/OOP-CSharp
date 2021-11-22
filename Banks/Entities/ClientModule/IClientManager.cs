using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.BankConfigurationModule;

namespace Banks.Entities.ClientModule
{
    public interface IClientManager
    {
        bool IsGood { get; }
        BankConfiguration Configuration { get; }
        AAccount FindAccount(int id);
    }
}