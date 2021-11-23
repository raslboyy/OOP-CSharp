using System.Collections.Generic;
using Banks.Entities.ClientModule;

namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public class Subscribers
    {
        private List<IClientManager> Clients { get; }
        public void Add(IClientManager client) => Clients.Add(client);

        public void Notify()
        {
        }
    }
}