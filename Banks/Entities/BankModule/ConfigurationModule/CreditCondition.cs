namespace Banks.Entities.BankModule.ConfigurationModule
{
    public readonly struct CreditCondition
    {
        public CreditCondition(Limits limits, double commission)
        {
            Limits = limits;
            Commission = commission;
        }

        public Limits Limits { get; }
        public double Commission { get; }
    }
}