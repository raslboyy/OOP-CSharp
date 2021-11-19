namespace Banks.Entities.AccountModule
{
    public class CreditAccount : AAccount
    {
        public CreditAccount(double balance)
            : base(balance)
        {
        }

        public override bool Withdraw(double value)
        {
            throw new System.NotImplementedException();
        }
    }
}