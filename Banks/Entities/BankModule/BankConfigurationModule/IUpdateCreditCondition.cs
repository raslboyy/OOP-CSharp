namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public interface IUpdateCreditCondition
    {
        void UpdateLimit(double value);
        void UpdateCommission(double value);
    }
}