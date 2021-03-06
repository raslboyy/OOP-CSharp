using System.Collections.Generic;
using Banks.Entities.BankModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BankModuleTests
    {
        [Test]
        public void RegisterBank_DefaultBank_BankCreatedAndAdded()
        {
            var centralBank = CentralBank.GetInstance();
            BankConfiguration configuration = CreateDefaultBankConfiguration();

            var bank = (Bank) CentralBank.RegisterBank("default", configuration);

            Assert.AreEqual("default", bank.Name);
            Assert.AreEqual(configuration, bank.Configuration);
        }

        private static BankConfiguration CreateDefaultBankConfiguration()
        {
            var credit = new CreditCondition(15, 1000);
            var debit = new DebitCondition(15);
            var deposit = new DepositCondition(new List<ValuePercent>()
            {
                new ValuePercent(100, 2),
                new ValuePercent(500, 4),
                new ValuePercent(1000, 7)
            });
            var account = new AccountCondition(1000, 1000, 500);

            return new BankConfiguration(credit, debit, deposit, account);
        }
    }
}