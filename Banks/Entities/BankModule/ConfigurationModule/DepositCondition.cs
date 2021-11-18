using System.Collections.Generic;

namespace Banks.Entities.BankModule.ConfigurationModule
{
    public readonly struct DepositCondition
    {
        public DepositCondition(Limits limits)
        {
            Percents = new List<ValuePercent>();
            Limits = limits;
        }

        public List<ValuePercent> Percents { get; }
        public Limits Limits { get; }
        public void AddValuePercent(double value, double percent) => Percents.Add(new ValuePercent(value, percent));
    }
}