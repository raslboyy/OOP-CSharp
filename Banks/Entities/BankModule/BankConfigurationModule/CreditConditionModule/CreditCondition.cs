namespace Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule
{
    public class CreditCondition : IUpdateCreditCondition
    {
        public CreditCondition(double commission, double limit)
        {
            Commission = new Condition<double>(commission);
            Limit = new Condition<double>(limit);
        }

        public Condition<double> Limit { get; }
        public Condition<double> Commission { get; }
        public void UpdateLimit(double value) => Limit.Set(value);
        public void UpdateCommission(double value) => Commission.Set(value);
    }
}