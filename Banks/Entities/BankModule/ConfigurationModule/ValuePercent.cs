namespace Banks.Entities.BankModule.ConfigurationModule
{
    public readonly struct ValuePercent
    {
        public ValuePercent(double value, double percent)
        {
            Value = value;
            Percent = percent;
        }

        public double Value { get; }
        public double Percent { get; }
    }
}