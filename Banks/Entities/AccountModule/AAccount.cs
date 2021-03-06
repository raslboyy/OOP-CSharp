using System;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule.ClientConfigurationModule;
using Banks.Tools;

namespace Banks.Entities.AccountModule
{
    public abstract class AAccount : IAccount
    {
        protected AAccount(double balance, BankConfiguration bankConfiguration, ClientConfiguration clientConfiguration)
        {
            Balance = balance;
            BankConfiguration = bankConfiguration ?? throw new ArgumentNullException(nameof(bankConfiguration));
            ClientConfiguration = clientConfiguration ?? throw new ArgumentNullException(nameof(clientConfiguration));
            Id = IdCount++;
            PercentagesValue = 0;
            Age = 0;
            Transfer = new Transfer(this);
        }

        public int Id { get; }
        public double Balance { get; protected set; }
        public int Age { get; private set; }
        public ClientConfiguration ClientConfiguration { get; }
        public double PercentagesValue { get; protected set; }
        protected BankConfiguration BankConfiguration { get; }
        private static int IdCount { get; set; }
        private Transfer Transfer { get; }

        public bool TopUp(double value)
        {
            Balance += value;
            return true;
        }

        public abstract bool Withdraw(double value);

        public TransferResult TransferTo(int accountId, double value) => Transfer.Execute(accountId, value);

        public void SkipDays(int n)
        {
            if (n <= 0)
                throw new AAccountException("N must be positive.");
            Age += n;
            for (int i = 0; i < n; i++)
                CalculatePercentages();
            if (Age % 30 == 0)
            {
                ChargePercentages();
            }
        }

        public void CancelTransfer(int transferId) => Transfer.Cancel(transferId);

        public void Restore(Snapshot snapshot) => Balance += snapshot.Value;

        protected abstract void CalculatePercentages();

        private void ChargePercentages()
        {
            Balance += PercentagesValue;
            PercentagesValue = 0;
        }

        public class Snapshot
        {
            public Snapshot(double value) => Value = value;
            public double Value { get; }
        }
    }
}