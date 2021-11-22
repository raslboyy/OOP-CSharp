namespace Banks.Entities.BankModule.ConfigurationModule
{
    public class DebitCondition : IUpdateDebitCondition
    {
        public DebitCondition(double percent)
        {
            Percent = percent;
        }

        public double Percent { get; private set; }
        public void UpdatePercent(double value) => Percent = value;
    }
}