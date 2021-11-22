using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule.ClientConfigurationModule;

namespace Banks.Entities.AccountModule
{
    public class DepositAccount : AAccount
    {
        public DepositAccount(
            double balance,
            int term,
            BankConfiguration bankConfiguration,
            ClientConfiguration clientConfiguration)
            : base(balance, bankConfiguration, clientConfiguration)
        {
            Term = term;
        }

        public int Term { get; }

        public override bool Withdraw(double value)
        {
            if (value > ClientConfiguration.WithdrawalLimit)
                return false;
            if (Age < Term)
                return false;
            Balance -= value;
            return true;
        }

        protected override void CalculatePercentages()
        {
        }
    }
}