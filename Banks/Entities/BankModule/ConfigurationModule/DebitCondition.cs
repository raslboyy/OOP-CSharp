namespace Banks.Entities.BankModule.ConfigurationModule
{
    public readonly struct DebitCondition
    {
        public DebitCondition(double percent)
        {
            Percent = percent;
        }

        public double Percent { get; }
    }
}