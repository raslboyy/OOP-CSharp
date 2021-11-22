namespace Banks.Entities.BankModule.ConfigurationModule
{
    public interface IUpdateBankConfiguration
    {
        IUpdateCreditCondition UpdateCreditCondition();
        IUpdateDebitCondition UpdateDebitCondition();
        IUpdateDepositCondition UpdateDepositCondition();
    }
}