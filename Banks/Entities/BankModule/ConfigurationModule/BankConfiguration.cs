namespace Banks.Entities.BankModule.ConfigurationModule
{
    public class BankConfiguration : IUpdateBankConfiguration
    {
        public BankConfiguration(
            CreditCondition creditCondition,
            DebitCondition debitCondition,
            DepositCondition depositCondition,
            AccountCondition accountCondition)
        {
            CreditCondition = creditCondition;
            DebitCondition = debitCondition;
            DepositCondition = depositCondition;
            AccountCondition = accountCondition;
        }

        public CreditCondition CreditCondition { get; }
        public DebitCondition DebitCondition { get; }
        public DepositCondition DepositCondition { get; }
        public AccountCondition AccountCondition { get; }
        public IUpdateCreditCondition UpdateCreditCondition() => CreditCondition;

        public IUpdateDebitCondition UpdateDebitCondition() => DebitCondition;

        public IUpdateDepositCondition UpdateDepositCondition() => DepositCondition;
        public IUpdateAccountCondition UpdateAccountCondition() => AccountCondition;
    }
}