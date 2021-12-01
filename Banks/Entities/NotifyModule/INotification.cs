using Banks.Entities.ClientModule;

namespace Banks.Entities.NotifyModule
{
    public interface INotification
    {
        void Subscribe(IClientManager client);
    }
}