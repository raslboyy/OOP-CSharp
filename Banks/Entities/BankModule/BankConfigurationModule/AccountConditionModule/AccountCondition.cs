namespace Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule
{
    public class AccountCondition : IUpdateAccountCondition
    {
        public AccountCondition(double withdrawalLimit, double transferLimit, double limitForBadClients)
        {
            WithdrawalLimit = new Condition<double>(withdrawalLimit);
            TransferLimit = new Condition<double>(transferLimit);
            LimitForBadClients = new Condition<double>(limitForBadClients);
        }

        public Condition<double> WithdrawalLimit { get; }
        public Condition<double> TransferLimit { get; }
        public Condition<double> LimitForBadClients { get; }
        public void UpdateWithdrawalLimit(double value) => WithdrawalLimit.Set(value);
        public void UpdateTransferLimit(double value) => TransferLimit.Set(value);
        public void UpdateLimitForBadClients(double value) => LimitForBadClients.Set(value);
    }
}