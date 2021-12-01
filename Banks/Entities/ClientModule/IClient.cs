using Banks.Entities.AccountModule;
using Banks.Entities.NotifyModule;

namespace Banks.Entities.ClientModule
{
    public interface IClient
    {
        string Address { get; set; }
        string Passport { get; set; }
        bool IsGood { get; }
        bool IsNotified { get; }
        IAccount CreateDebitAccount(double value);
        IAccount CreateDepositAccount(double value, int term);
        IAccount CreateCreditAccount(double value);
        void Subscribe(INotification notification);
    }
}