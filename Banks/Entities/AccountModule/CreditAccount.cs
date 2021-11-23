using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule.ClientConfigurationModule;

namespace Banks.Entities.AccountModule
{
    public class CreditAccount : AAccount
    {
        public CreditAccount(
            double balance,
            BankConfiguration bankConfiguration,
            ClientConfiguration clientConfiguration)
            : base(balance, bankConfiguration, clientConfiguration)
        {
        }

        public override bool Withdraw(double value)
        {
            if (value > ClientConfiguration.WithdrawalLimit)
                return false;
            if (Balance - value >= 0)
            {
                Balance -= value;
            }
            else
            {
                if (Balance - value - BankConfiguration.CreditCondition.Commission <
                    BankConfiguration.CreditCondition.Limit)
                    return false;
                Balance -= value + BankConfiguration.CreditCondition.Commission;
            }

            return true;
        }

        protected override void CalculatePercentages()
        {
        }
    }
}