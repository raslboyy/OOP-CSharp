using Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule;

namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public interface IUpdateBankConfiguration
    {
        IUpdateCreditCondition UpdateCreditCondition();
        IUpdateDebitCondition UpdateDebitCondition();
        IUpdateDepositCondition UpdateDepositCondition();
        IUpdateAccountCondition UpdateAccountCondition();
    }
}