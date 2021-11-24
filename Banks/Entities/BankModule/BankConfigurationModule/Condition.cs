using Banks.Entities.ClientModule;

namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public class Condition<T>
    {
        private readonly Subscribers _subscribers = new Subscribers();
        private T _value;

        public Condition(T value)
        {
            _value = value;
        }

        public static implicit operator T(Condition<T> condition) => condition._value;

        public void Set(T value)
        {
            _value = value;
            _subscribers.Notify();
        }

        public void AddSubscriber(IClientManager client) => _subscribers.Add(client);
    }
}