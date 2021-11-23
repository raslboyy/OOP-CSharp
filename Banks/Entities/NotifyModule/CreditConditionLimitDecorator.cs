using Banks.Entities.ClientModule;

namespace Banks.Entities.NotifyModule
{
    public class CreditConditionLimitDecorator : NotificationDecorator
    {
        public CreditConditionLimitDecorator(INotification wrappee)
            : base(wrappee)
        {
        }

        public override void Subscribe(IClientManager clientManager)
        {
            base.Subscribe(clientManager);
            clientManager.Configuration.CreditCondition.LimitSubscribers.Add(clientManager);
        }
    }
}