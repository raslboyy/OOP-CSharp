using Banks.Entities.ClientModule;

namespace Banks.Entities.NotifyModule
{
    public abstract class NotificationDecorator : INotification
    {
        private INotification _wrappee;
        public NotificationDecorator(INotification wrappee) => _wrappee = wrappee;
        public virtual void Subscribe(IClientManager clientManager) => _wrappee.Subscribe(clientManager);
    }
}