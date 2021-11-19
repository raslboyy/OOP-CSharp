using Banks.Entities.BankModule.ConfigurationModule;

namespace Banks.Entities.AccountModule
{
    public class CreditAccount : AAccount
    {
        public CreditAccount(double balance, BankConfiguration configuration)
            : base(balance, configuration)
        {
        }

        public override bool Withdraw(double value)
        {
            if (Balance - value < Configuration.CreditCondition.Limit)
                return false;
            Balance -= value;
            return true;
        }
    }
}