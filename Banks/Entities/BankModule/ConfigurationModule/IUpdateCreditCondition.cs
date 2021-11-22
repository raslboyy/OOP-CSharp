namespace Banks.Entities.BankModule.ConfigurationModule
{
    public interface IUpdateCreditCondition
    {
        void UpdateLimit(double value);
        void UpdateCommission(double value);
    }
}