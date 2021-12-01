namespace Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule
{
    public class DebitCondition : IUpdateDebitCondition
    {
        public DebitCondition(double percent)
        {
            Percent = new Condition<double>(percent);
        }

        public Condition<double> Percent { get; }
        public void UpdatePercent(double value) => Percent.Set(value);
    }
}