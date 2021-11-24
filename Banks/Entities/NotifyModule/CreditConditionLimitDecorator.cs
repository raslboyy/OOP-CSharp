using Banks.Entities.ClientModule;

namespace Banks.Entities.NotifyModule
{
    public class CreditConditionLimitDecorator : NotificationDecorator, INotification
    {
        public CreditConditionLimitDecorator(INotification wrappee)
            : base(wrappee)
        {
        }

        public override void Subscribe(IClientManager client)
        {
            base.Subscribe(client);
            client.Configuration.CreditCondition.Limit.AddSubscriber(client);
        }
    }
}