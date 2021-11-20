using System.Collections.Generic;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.ConfigurationModule;
using NUnit.Framework;

namespace Banks.Tests
{
    public class AccountTests
    {
        [Test]
        public void TopUp_BalanceChanged()
        {
            const double startValue = 100;
            var account = new DebitAccount(startValue, CreateDefaultBankConfiguration());

            const double value = 100;
            account.TopUp(value);
            
            Assert.AreEqual(startValue + value, account.Balance);
        }

        [Test]
        public void Withdraw_DebitAccountEnoughMoney_ReturnTrueBalanceChanged()
        {
            const double startValue = 100;
            var account = new DebitAccount(startValue, CreateDefaultBankConfiguration());

            const double value = 100;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }
        
        [Test]
        public void Withdraw_DebitAccountNotEnoughMoney_ReturnFalseBalanceNotChanged()
        {
            const double startValue = 100;
            var account = new DebitAccount(startValue, CreateDefaultBankConfiguration());

            const double value = 200;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(false, actual);
            Assert.AreEqual(startValue, account.Balance);
        }

        [Test]
        public void Withdraw_DepositAccountEnoughTerm_ReturnTrueBalanceChanged()
        {
            const double startValue = 100;
            var account = new DepositAccount(startValue, 12, CreateDefaultBankConfiguration());

            const double value = 100;
            account.Age = 12;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }
        
        [Test]
        public void Withdraw_DepositAccountTermNotEnough_ReturnFalseBalanceNotChanged()
        {
            const double startValue = 100;
            var account = new DepositAccount(startValue, 12, CreateDefaultBankConfiguration());

            const double value = 100;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(false, actual);
            Assert.AreEqual(startValue, account.Balance);
        }

        [Test]
        public void Withdraw_CreditAccountLimitEnough_ReturnTrueBalanceChanged()
        {
            const double startValue = 0;
            var account = new CreditAccount(startValue, CreateDefaultBankConfiguration());

            const double value = 1000;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(true, actual);
            Assert.AreEqual(startValue - value, account.Balance);
        }
        
        [Test]
        public void Withdraw_CreditAccountLimitNotEnough_ReturnFalseBalanceNotChanged()
        {
            const double startValue = 0;
            var account = new CreditAccount(startValue, CreateDefaultBankConfiguration());

            const double value = 1001;
            bool actual = account.Withdraw(value);
            
            Assert.AreEqual(false, actual);
            Assert.AreEqual(startValue, account.Balance);
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

            return new BankConfiguration(credit, debit, deposit);
        }
    }
}