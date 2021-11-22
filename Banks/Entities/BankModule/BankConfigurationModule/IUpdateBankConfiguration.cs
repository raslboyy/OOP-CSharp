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