using System;

namespace Banks.Entities.ClientModule.ClientConfigurationModule
{
    public class ClientConfiguration
    {
        public ClientConfiguration(IClientManager client) =>
            Client = client ?? throw new ArgumentNullException(nameof(client));

        public double TransferLimit =>
            Client.IsGood
                ? Client.Configuration.AccountCondition.TransferLimit
                : Client.Configuration.AccountCondition.LimitForBadClients;

        public double WithdrawalLimit =>
            Client.IsGood
                ? Client.Configuration.AccountCondition.WithdrawalLimit
                : Client.Configuration.AccountCondition.LimitForBadClients;

        private IClientManager Client { get; }
    }
}