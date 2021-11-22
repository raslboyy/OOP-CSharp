namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public class CreditCondition : IUpdateCreditCondition
    {
        public CreditCondition(double commission, double limit)
        {
            Commission = commission;
            Limit = limit;
        }

        public double Limit { get; private set; }
        public double Commission { get; private set; }
        public void UpdateLimit(double value) => Limit = value;

        public void UpdateCommission(double value) => Commission = value;
    }
}