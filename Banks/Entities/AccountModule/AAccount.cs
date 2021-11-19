namespace Banks.Entities.AccountModule
{
    public abstract class AAccount : IAccount
    {
        protected AAccount(double balance)
        {
            Balance = balance;
            Id = IdCount++;
            Percentages = 0;
        }

        public int Id { get; }
        public double Percentages { get; protected set; }
        public double Balance { get; protected set; }
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