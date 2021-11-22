using Banks.Entities.BankModule.ConfigurationModule;

namespace Banks.Entities.AccountModule
{
    public class DebitAccount : AAccount
    {
        public DebitAccount(double balance, BankConfiguration configuration)
            : base(balance, configuration)
        {
        }

        public override bool Withdraw(double value)
        {
            if (value > Configuration.AccountCondition.WithdrawalLimit)
                return false;
            if (Balance - value < 0)
                return false;
            Balance -= value;
            return true;
        }
    }
}