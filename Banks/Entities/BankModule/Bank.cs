using System;
using Banks.Entities.BankModule.ConfigurationModule;
using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;

namespace Banks.Entities.BankModule
{
    public class Bank : IBank, IBankManager
    {
        public Bank(string name, BankConfiguration configuration)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Configuration = configuration;
        }

        public string Name { get; set; }
        public BankConfiguration Configuration { get; }
        private ClientsStorage Clients { get; } = new ClientsStorage();

        public IClient AddClient(ClientBuilder builder)
        {
            Client client = builder.GetResult();
            client.Configuration = Configuration;
            Clients.AddClient(client);
            return client;
        }
    }
}