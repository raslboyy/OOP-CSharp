using System;
using Banks.Entities.BankModule.ConfigurationModule;
using Banks.Entities.ClientModule;

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
    }
}