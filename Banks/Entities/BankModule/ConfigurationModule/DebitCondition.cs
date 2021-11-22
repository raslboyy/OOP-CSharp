namespace Banks.Entities.BankModule.ConfigurationModule
{
    public class DebitCondition
    {
        public DebitCondition(double percent)
        {
            Percent = percent;
        }

        public double Percent { get; }
    }
}