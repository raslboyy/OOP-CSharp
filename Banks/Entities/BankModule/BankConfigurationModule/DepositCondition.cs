using System.Collections.Generic;

namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public class DepositCondition : IUpdateDepositCondition
    {
        public DepositCondition(List<ValuePercent> percents)
        {
            Percents = percents;
        }

        public List<ValuePercent> Percents { get; }
        public void AddValuePercent(double value, double percent) => Percents.Add(new ValuePercent(value, percent));
    }
}