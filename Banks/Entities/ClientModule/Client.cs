using System.Collections.Generic;
using System.Linq;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.ClientModule.ClientConfigurationModule;
using Banks.Entities.NotifyModule;

namespace Banks.Entities.ClientModule
{
    public class Client : IClient, IClientManager
    {
        private bool _isGood;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }

        public bool IsGood
        {
            get
            {
                if (Address != null && Passport != null)
                    _isGood = true;
                return _isGood;
            }
            set => _isGood = value;
        }

        public bool IsNotified { get; set; }

        public BankConfiguration Configuration { get; set; }
        private List<AAccount> Accounts { get; } = new List<AAccount>();

        public IAccount CreateDebitAccount(double value)
        {
            var account = new DebitAccount(value, Configuration, new ClientConfiguration(this));
            Accounts.Add(account);
            return account;
        }

        public IAccount CreateDepositAccount(double value, int term)
        {
            var account = new DepositAccount(value, term, Configuration, new ClientConfiguration(this));
            Accounts.Add(account);
            return account;
        }

        public IAccount CreateCreditAccount(double value)
        {
            var account = new CreditAccount(value, Configuration, new ClientConfiguration(this));
            Accounts.Add(account);
            return account;
        }

        public void Subscribe(INotification notification) => notification.Subscribe(this);

        public AAccount FindAccount(int id) => Accounts.FirstOrDefault(account => account.Id == id);
        public void SkipDays(int n) => Accounts.ForEach(account => account.SkipDays(n));
    }
}