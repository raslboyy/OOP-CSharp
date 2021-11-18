namespace Banks.Entities.BankModule.ConfigurationModule
{
    public readonly struct Limits
    {
        public Limits(double lowerLimit, double upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public double LowerLimit { get; }
        public double UpperLimit { get; }
    }
}