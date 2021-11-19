namespace Banks.Entities.AccountModule
{
    public class DepositAccount : AAccount
    {
        public DepositAccount(double balance, int term)
            : base(balance)
        {
            Term = term;
        }

        public int Term { get; }

        public override bool Withdraw(double value)
        {
            throw new System.NotImplementedException();
        }
    }
}