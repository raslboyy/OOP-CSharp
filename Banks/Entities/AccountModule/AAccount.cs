using Banks.Entities.BankModule.ConfigurationModule;

// Вся внешняя логика проходит через интерфейс IAccount
namespace Banks.Entities.AccountModule
{
    public abstract class AAccount : IAccount
    {
        protected AAccount(double balance, BankConfiguration configuration)
        {
            Balance = balance;
            Configuration = configuration;
            Id = IdCount++;
            Percentages = 0;
            Age = 0;
            Transfer = new Transfer(this);
        }

        public int Id { get; }
        public double Balance { get; protected set; }

        // public set for tests (to correct)
        public int Age { get; set; }
        public BankConfiguration Configuration { get; }
        protected double Percentages { get; set; }
        private static int IdCount { get; set; }
        private Transfer Transfer { get; }

        public bool TopUp(double value)
        {
            Balance += value;
            return true;
        }

        public abstract bool Withdraw(double value);

        public TransferResult TransferTo(int accountId, double value) => Transfer.Execute(accountId, value);

        public void CancelTransfer(int transferId) => Transfer.Cancel(transferId);

        public void Restore(Snapshot snapshot) => Balance += snapshot.Value;

        public class Snapshot
        {
            public Snapshot(double value) => Value = value;
            public double Value { get; }
        }
    }
}