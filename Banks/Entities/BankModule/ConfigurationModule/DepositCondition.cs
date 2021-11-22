using System.Collections.Generic;

namespace Banks.Entities.BankModule.ConfigurationModule
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