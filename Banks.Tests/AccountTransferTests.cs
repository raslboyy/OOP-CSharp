using System.Collections.Generic;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;
using Banks.Tools;
using NUnit.Framework;

namespace Banks.Tests
{
    public class AccountTransferTests
    {
        [Test]
        public void Transfer_DefaultTransfer_ReturnTrueChangedTheBalanceOfBothAccounts()
        {
            IAccount account1 = CreateDefaultFromAccount();
            IAccount account2 = CreateDefaultToAccount();
            double startValue = account1.Balance;
            
            TransferResult actual = account1.TransferTo(account2.Id, startValue);

            Assert.AreEqual(true, actual.IsSuccessful);
            Assert.AreEqual(0, account1.Balance);
            Assert.AreEqual(startValue * 2, account2.Balance);
        }

        [Test]
        public void Transfer_NotEnoughMoney_ReturnFalseNotChangedTheBalanceOfBothAccounts()
        {
            IAccount account1 = CreateDefaultFromAccount();
            IAccount account2 = CreateDefaultToAccount();
            double startValue = account1.Balance;
            
            TransferResult actual = account1.TransferTo(account2.Id, startValue + 1);

            Assert.AreEqual(false, actual.IsSuccessful);
            Assert.AreEqual(startValue, account1.Balance);
            Assert.AreEqual(startValue, account2.Balance);
        }

        [Test]
        public void Transfer_NotFoundToAccount_ReturnFalseNotChangeBalance()
        {
            IAccount account1 = CreateDefaultFromAccount();
            double startValue = account1.Balance;
            
            TransferResult actual = account1.TransferTo(int.MaxValue, startValue);

            Assert.AreEqual(false, actual.IsSuccessful);
            Assert.AreEqual(startValue, account1.Balance);
        }

        [Test]
        public void CancelTransfer_DefaultCancel_MoneyReturned()
        {
            IAccount account1 = CreateDefaultFromAccount();
            IAccount account2 = CreateDefaultToAccount();
            double startValue = account1.Balance;
            
            TransferResult transfer = account1.TransferTo(account2.Id, startValue / 2);
            account1.TransferTo(account2.Id, startValue / 2);
            account1.CancelTransfer(transfer.IdTransfer);

            Assert.AreEqual(true, transfer.IsSuccessful);
            Assert.AreEqual(startValue / 2, account1.Balance);
            Assert.AreEqual(startValue * 2, account2.Balance);
        }

        [Test]
        public void CancelTransfer_CancelTwice_ThrowTransferExceptionMoneyNotReturned()
        {
            IAccount account1 = CreateDefaultFromAccount();
            IAccount account2 = CreateDefaultToAccount();
            double startValue = account1.Balance;
            
            TransferResult transfer = account1.TransferTo(account2.Id, startValue / 2);
            account1.TransferTo(account2.Id, startValue / 2);
            account1.CancelTransfer(transfer.IdTransfer);
            double expected = account1.Balance;
            
            Assert.Catch<TransferException>(() =>
            {
                account1.CancelTransfer(transfer.IdTransfer);
            });
            Assert.AreEqual(expected, account1.Balance);
        }
        
        [Test]
        public void CancelTransfer_IncorrectId_ThrowTransferExceptionMoneyNotReturned()
        {
            IAccount account1 = CreateDefaultFromAccount();
            double expected = account1.Balance;
            
            Assert.Catch<TransferException>(() =>
            {
                account1.CancelTransfer(int.MaxValue);
            });
            Assert.AreEqual(expected, account1.Balance);
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
            var account = new AccountCondition(1000, 1000, 500);

            return new BankConfiguration(credit, debit, deposit, account);
        }

        private static IAccount CreateDefaultFromAccount()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last").SetAddress("fd").SetPassport("f");
            IClient client = bank.AddClient(builder);
            return client.CreateDebitAccount(1000);
        }
        
        private static IAccount CreateDefaultToAccount()
        {
            IBank bank = CentralBank.RegisterBank("Tink", CreateDefaultBankConfiguration());
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last");
            IClient client = bank.AddClient(builder);
            return client.CreateDebitAccount(1000);
        }
    }
}