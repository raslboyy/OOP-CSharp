namespace Banks.Entities.BankModule.ConfigurationModule
{
    public interface IUpdateAccountCondition
    {
        void UpdateWithdrawalLimit(double value);
        void UpdateTransferLimit(double value);
    }
}