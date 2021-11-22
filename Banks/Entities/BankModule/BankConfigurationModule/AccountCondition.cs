namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public class AccountCondition : IUpdateAccountCondition
    {
        public AccountCondition(double withdrawalLimit, double transferLimit, double limitForBadClients)
        {
            WithdrawalLimit = withdrawalLimit;
            TransferLimit = transferLimit;
            LimitForBadClients = limitForBadClients;
        }

        public double WithdrawalLimit { get; private set; }
        public double TransferLimit { get; private set; }
        public double LimitForBadClients { get; private set; }
        public void UpdateWithdrawalLimit(double value) => WithdrawalLimit = value;
        public void UpdateTransferLimit(double value) => TransferLimit = value;
        public void UpdateLimitForBadClients(double value) => LimitForBadClients = value;
    }
}