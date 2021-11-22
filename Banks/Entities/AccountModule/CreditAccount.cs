using Banks.Entities.BankModule.BankConfigurationModule;

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
            if (value > Configuration.AccountCondition.WithdrawalLimit)
                return false;
            if (Balance - value < Configuration.CreditCondition.Limit)
                return false;
            Balance -= value;
            return true;
        }
    }
}