namespace Banks.Entities.BankModule.ConfigurationModule
{
    public readonly struct DebitCondition
    {
        public DebitCondition(Limits limits, double percent)
        {
            Limits = limits;
            Percent = percent;
        }

        public Limits Limits { get; }
        public double Percent { get; }
    }
}