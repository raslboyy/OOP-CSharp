using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule.ClientConfigurationModule;

namespace Banks.Entities.AccountModule
{
    public class DebitAccount : AAccount
    {
        public DebitAccount(
            double balance,
            BankConfiguration bankConfiguration,
            ClientConfiguration clientConfiguration)
            : base(balance, bankConfiguration, clientConfiguration)
        {
            Percent = BankConfiguration.DebitCondition.Percent / 365;
        }

        private double Percent { get; }

        public override bool Withdraw(double value)
        {
            if (value > ClientConfiguration.WithdrawalLimit)
                return false;
            if (Balance - value < 0)
                return false;
            Balance -= value;
            return true;
        }

        protected override void CalculatePercentages() =>
            PercentagesValue += Balance * Percent;
    }
}