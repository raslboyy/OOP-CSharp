using System.Collections.Generic;
using Banks.Entities.BankModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule;
using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;
using Banks.Entities.NotifyModule;
using NUnit.Framework;

namespace Banks.Tests
{
    public class NotificationTests
    {
        [Test]
        public void Subscribe_DefaultScript_ClientIsNotified()
        {
            IBank bank = CentralBank.RegisterBank("Sber", CreateDefaultBankConfiguration());
            var builder = new LastClientBuilder();
            builder.SetFirstName("First").SetLastName("Last").SetAddress("fd").SetPassport("f");
            IClient client = bank.AddClient(builder);
            
            INotification notification = new Notification();
            notification = new CreditConditionLimitDecorator(notification);
            client.Subscribe(notification);
            bank.Update().UpdateCreditCondition().UpdateLimit(0);
            
            Assert.AreEqual(true, client.IsNotified);
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
    }
}