using System.Collections.Generic;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;
using NUnit.Framework;

namespace Banks.Tests
{
    public class AccountTests
    {
        [Test]
        public void TopUp_BalanceChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDebitAccount(bank);
            double startValue = account.Balance;
            
            const double value = 1000;
            account.TopUp(value);
            
            Assert.AreEqual(startValue + value, account.Balance);
        }

        [Test]
        public void Withdraw_DebitAccountEnoughMoney_ReturnTrueBalanceChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDebitAccount(bank);
            double startValue = account.Balance;
            
            const double value = 1000;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }
        
        [Test]
        public void Withdraw_DebitAccountNotEnoughMoney_ReturnFalseBalanceNotChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDebitAccount(bank);
            double startValue = account.Balance;
            
            const double value = 2000;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(false, actual);
            Assert.AreEqual(startValue, account.Balance);
        }

        [Test]
        public void Withdraw_DepositAccountEnoughTerm_ReturnTrueBalanceChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDepositAccount(bank);
            double startValue = account.Balance;
            
            const double value = 1000;
            ((AAccount)account).Age = 12;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }
        
        [Test]
        public void Withdraw_DepositAccountTermNotEnough_ReturnFalseBalanceNotChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultDepositAccount(bank);
            double startValue = account.Balance;
            
            const double value = 1000;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(false, actual);
            Assert.AreEqual(startValue, account.Balance);
        }

        [Test]
        public void Withdraw_CreditAccountLimitEnough_ReturnTrueBalanceChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultCreditAccount(bank);
            double startValue = account.Balance;
            
            const double value = 2000;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }
        
        [Test]
        public void Withdraw_CreditAccountLimitNotEnough_ReturnFalseBalanceNotChanged()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            IAccount account = CreateDefaultCreditAccount(bank);
            double startValue = account.Balance;
            
            const double value = 2001;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(false, actual);
            Assert.AreEqual(startValue, account.Balance);
        }

        [Test]
        public void Update_UpdateLimit_LimitChanged()
        {
            const double startValue = 0;
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last").SetAddress("Address").SetPassport("Passport");
            IClient client = bank.AddClient(builder);
            IAccount account = client.CreateCreditAccount(startValue);
            
            const double value = 1001;
            bank.Update().UpdateCreditCondition().UpdateLimit(-1001);
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }

        private static BankConfiguration CreateDefaultBankConfiguration()
        {
            var credit = new CreditCondition(15, -1000);
            var debit = new DebitCondition(15);
            var deposit = new DepositCondition(new List<ValuePercent>()
            {
                new ValuePercent(100, 2),
                new ValuePercent(500, 4),
                new ValuePercent(1000, 7)
            });
            var account = new AccountCondition(2000, 2000, 100);

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
        
        private static IAccount CreateDefaultCreditAccount(IBank bank)
        {
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last").SetAddress("Address").SetPassport("Passport");
            IClient client = bank.AddClient(builder);
            return client.CreateCreditAccount(1000);
        }
    }
}