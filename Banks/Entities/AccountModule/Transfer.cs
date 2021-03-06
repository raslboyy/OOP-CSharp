using System;
using System.Collections.Generic;
using Banks.Entities.BankModule;
using Banks.Tools;

namespace Banks.Entities.AccountModule
{
    public class Transfer
    {
        public Transfer(AAccount account)
        {
            Account = account ?? throw new ArgumentNullException(nameof(account));
        }

        private AAccount Account { get; }
        private List<AAccount.Snapshot> History { get; } = new List<AAccount.Snapshot>();

        public TransferResult Execute(int accountId, double value)
        {
            if (value <= 0)
                throw new TransferException("Value for Transfer must be positive.");
            if (value > Account.ClientConfiguration.TransferLimit)
                return new TransferResult(false, -1);
            AAccount account = CentralBank.FindAccount(accountId);
            if (account == null || !Account.Withdraw(value))
                return new TransferResult(false, -1);

            account.TopUp(value);
            History.Add(new AAccount.Snapshot(value));
            return new TransferResult(true, History.Count - 1);
        }

        public void Cancel(int id)
        {
            if (id >= History.Count)
                throw new TransferException("Incorrect transfer id");
            if (History[id] == null)
                throw new TransferException("This transfer has already been canceled.");
            Account.Restore(History[id]);
            History[id] = null;
        }
    }
}