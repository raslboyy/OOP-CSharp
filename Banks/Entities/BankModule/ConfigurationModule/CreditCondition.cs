namespace Banks.Entities.BankModule.ConfigurationModule
{
    public class CreditCondition
    {
        public CreditCondition(double commission, double limit)
        {
            Commission = commission;
            Limit = limit;
        }

        public double Limit { get; }
        public double Commission { get; }
    }
}