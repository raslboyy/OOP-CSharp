using Banks.Entities.ClientModule;

namespace Banks.Entities.NotifyModule
{
    public abstract class NotificationDecorator : INotification
    {
        private INotification _wrappee;
        protected NotificationDecorator(INotification wrappee) => _wrappee = wrappee;
        public virtual void Subscribe(IClientManager client) => _wrappee.Subscribe(client);
    }
}