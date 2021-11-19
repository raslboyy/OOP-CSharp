namespace Banks.Entities.AccountModule
{
    public class DebitAccount : AAccount
    {
        public DebitAccount(double balance)
            : base(balance)
        {
        }

        public override bool Withdraw(double value)
        {
            if (Balance - value < 0)
                return false;
            Balance -= value;
            return true;
        }
    }
}