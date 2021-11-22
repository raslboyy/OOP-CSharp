using System.Collections.Generic;
using System.Linq;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.BankConfigurationModule;

// Вся внешняя логика проходит через интерфейс IClient либо Билдер
namespace Banks.Entities.ClientModule
{
    public class Client : IClient, IClientManager
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public bool IsGood { get; set; }
        internal BankConfiguration Configuration { get; set; }
        private List<AAccount> Accounts { get; } = new List<AAccount>();

        public IAccount CreateDebitAccount(double value)
        {
            var account = new DebitAccount(value, Configuration);
            Accounts.Add(account);
            return account;
        }

        public IAccount CreateDepositAccount(double value, int term)
        {
            var account = new DepositAccount(value, term, Configuration);
            Accounts.Add(account);
            return account;
        }

        public IAccount CreateCreditAccount(double value)
        {
            var account = new CreditAccount(value, Configuration);
            Accounts.Add(account);
            return account;
        }

        public AAccount FindAccount(int id) => Accounts.FirstOrDefault(account => account.Id == id);
    }
}