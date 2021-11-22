namespace Banks.Entities.BankModule.ConfigurationModule
{
    public class BankConfiguration : IUpdateBankConfiguration
    {
        public BankConfiguration(
            CreditCondition creditCondition,
            DebitCondition debitCondition,
            DepositCondition depositCondition)
        {
            CreditCondition = creditCondition;
            DebitCondition = debitCondition;
            DepositCondition = depositCondition;
        }

        public CreditCondition CreditCondition { get; }
        public DebitCondition DebitCondition { get; }
        public DepositCondition DepositCondition { get; }
        public IUpdateCreditCondition UpdateCreditCondition() => CreditCondition;

        public IUpdateDebitCondition UpdateDebitCondition() => DebitCondition;

        public IUpdateDepositCondition UpdateDepositCondition() => DepositCondition;
    }
}