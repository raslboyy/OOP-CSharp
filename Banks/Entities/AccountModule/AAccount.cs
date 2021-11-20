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
        }

        public int Id { get; }
        public double Balance { get; protected set; }

        // public set for tests (to correct)
        public int Age { get; set; }
        protected double Percentages { get; set; }
        protected BankConfiguration Configuration { get; }
        private static int IdCount { get; set; }

        public bool TopUp(double value)
        {
            Balance += value;
            return true;
        }

        public abstract bool Withdraw(double value);

        // public abstract bool Transfer(int accountId, double value);
    }
}