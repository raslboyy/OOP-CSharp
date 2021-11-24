namespace Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule
{
    public interface IUpdateAccountCondition
    {
        void UpdateWithdrawalLimit(double value);
        void UpdateTransferLimit(double value);
        public void UpdateLimitForBadClients(double value);
    }
}