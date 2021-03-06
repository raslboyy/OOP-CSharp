using System.Collections.Generic;
using System.Linq;
using Banks.Entities.AccountModule;

namespace Banks.Entities.ClientModule
{
    public class ClientsStorage
    {
        private List<IClientManager> Clients { get; } = new ();
        public void AddClient(Client client) => Clients.Add(client);

        public AAccount FindAccount(int id)
        {
            IClientManager client = Clients.FirstOrDefault(client => client.FindAccount(id) != null);
            return client?.FindAccount(id);
        }

        public void SkipDays(int n) => Clients.ForEach(client => client.SkipDays(n));
    }
}