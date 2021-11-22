using Banks.Entities.BankModule.ConfigurationModule;

namespace Banks.Entities.AccountModule
{
    public class DepositAccount : AAccount
    {
        public DepositAccount(double balance, int term, BankConfiguration configuration)
            : base(balance, configuration)
        {
            Term = term;
        }

        public int Term { get; }

        public override bool Withdraw(double value)
        {
            if (value > Configuration.AccountCondition.WithdrawalLimit)
                return false;
            if (Age < Term)
                return false;
            Balance -= value;
            return true;
        }
    }
}