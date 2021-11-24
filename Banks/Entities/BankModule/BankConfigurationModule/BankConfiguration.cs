using Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule;

namespace Banks.Entities.BankModule.BankConfigurationModule
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