using Banks.Entities.AccountModule;

namespace Banks.Entities.ClientModule
{
    public interface IClientManager
    {
        AAccount FindAccount(int id);
    }
}