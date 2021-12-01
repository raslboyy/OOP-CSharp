using System.Collections.Generic;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule;
using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;
using NUnit.Framework;

namespace Banks.Tests
{
    public class CentralBankTests
    {
        [Test]
        public void SkipDays_Skip1Day_PercentagesAreNotCharged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDebitAccount(bank);

            double expected = account.Balance;
            CentralBank.SkipDays(1);
            double actual = account.Balance;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculatePercentagesDebitAccount_Skip2Days_PercentagesValueIsActual()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDebitAccount(bank);

            double percent = CreateDefaultBankConfiguration().DebitCondition.Percent / 365;
            double expected = account.Balance * percent;
            CentralBank.SkipDays(1);
            account.TopUp(1000);
            expected += account.Balance * percent;
            CentralBank.SkipDays(1);
            
            Assert.AreEqual(expected, account.PercentagesValue);
        }

        [Test]
        public void CalculatePercentagesDepositAccount_Skip2Days_PercentagesValueIsActual()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDepositAccount(bank);

            double percent = CreateDefaultBankConfiguration().DepositCondition.GetPercent(account.Balance) / 365;
            double expected = account.Balance * percent;
            CentralBank.SkipDays(1);
            account.TopUp(10000);
            expected += account.Balance * percent;
            CentralBank.SkipDays(1);
            
            Assert.AreEqual(expected, account.PercentagesValue);
        }

        [Test]
        public void SkipDays_Skip30Days_PercentagesAreNotCharged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDebitAccount(bank);

            double percent = CreateDefaultBankConfiguration().DebitCondition.Percent / 365;
            double expected = account.Balance + account.Balance * percent;
            CentralBank.SkipDays(1);
            account.TopUp(1000);
            expected += 1000 + account.Balance * percent;
            CentralBank.SkipDays(1);
            expected += account.Balance * percent * 28;
            CentralBank.SkipDays(28);
            
            Assert.AreEqual(expected, account.Balance);
        }
        private static BankConfiguration CreateDefaultBankConfiguration()
        {
            var credit = new CreditCondition(0, -1000);
            var debit = new DebitCondition(0.15);
            var deposit = new DepositCondition(new List<ValuePercent>()
            {
                new ValuePercent(100, 2),
                new ValuePercent(500, 4),
                new ValuePercent(10000, 7)
            });
            var account = new AccountCondition(2000, 2000, 2000);

            return new BankConfiguration(credit, debit, deposit, account);
        }
        
        private static IAccount CreateDefaultDebitAccount(IBank bank)
        {
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last");
            IClient client = bank.AddClient(builder);
            return client.CreateDebitAccount(1000);
        }
        
        private static IAccount CreateDefaultDepositAccount(IBank bank)
        {
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last");
            IClient client = bank.AddClient(builder);
            return client.CreateDepositAccount(1000, 12);
        }
    }
}