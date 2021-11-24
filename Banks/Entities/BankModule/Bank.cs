using System;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;

namespace Banks.Entities.BankModule
{
    public class Bank : IBankManager
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

        public IUpdateBankConfiguration Update() => Configuration;

        public AAccount FindAccount(int id) => Clients.FindAccount(id);
        public void SkipDays(int n) => Clients.SkipDays(n);
    }
}