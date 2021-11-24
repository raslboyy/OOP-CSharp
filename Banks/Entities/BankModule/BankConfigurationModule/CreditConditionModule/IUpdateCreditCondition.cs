namespace Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule
{
    public interface IUpdateCreditCondition
    {
        void UpdateLimit(double value);
        void UpdateCommission(double value);
    }
}