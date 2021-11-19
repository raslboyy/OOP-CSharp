using System.Collections.Generic;
using System.Linq;
using Banks.Entities.AccountModule;

namespace Banks.Entities.ClientModule
{
    public class Client : IClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public bool IsGood { get; set; }
        private List<AAccount> Accounts { get; } = new List<AAccount>();
        public IAccount CreateDebitAccount(double value)
        {
            var account = new DebitAccount(value);
            Accounts.Add(account);
            return account;
        }

        public IAccount CreateDepositAccount(double value, int term)
        {
            var account = new DepositAccount(value, term);
            Accounts.Add(account);
            return account;
        }

        public IAccount CreateCreditAccount(double value)
        {
            var account = new CreditAccount(value);
            Accounts.Add(account);
            return account;
        }

        public IAccount GetAccount(int id) => Accounts.FirstOrDefault(account => account.Id == id);
    }
}