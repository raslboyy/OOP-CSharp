using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Tools;

namespace Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule
{
    public class DepositCondition : IUpdateDepositCondition
    {
        public DepositCondition(List<ValuePercent> percents)
        {
            Percents = percents ?? throw new ArgumentNullException(nameof(percents));
        }

        private List<ValuePercent> Percents { get; }

        public double GetPercent(double value)
        {
            ValuePercent? valuePercent = Percents.FirstOrDefault(item => item.Value > value);
            if (valuePercent == null)
                throw new DepositConditionException("Deposit condition is invalid for this value.");
            return ((ValuePercent)valuePercent).Percent;
        }
    }
}