using System.Collections.Generic;
using Banks.Entities.ClientModule;

namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public class Subscribers
    {
        private readonly List<IClientManager> _clients = new ();
        public void Add(IClientManager client) => _clients.Add(client);

        public void Notify()
        {
            _clients.ForEach(client => client.IsNotified = true);
        }
    }
}