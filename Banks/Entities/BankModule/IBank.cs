using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;

namespace Banks.Entities.BankModule
{
    public interface IBank
    {
        IClient AddClient(ClientBuilder builder);
    }
}