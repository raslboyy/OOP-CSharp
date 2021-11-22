namespace Banks.Entities.BankModule.BankConfigurationModule
{
    public interface IUpdateAccountCondition
    {
        void UpdateWithdrawalLimit(double value);
        void UpdateTransferLimit(double value);
    }
}