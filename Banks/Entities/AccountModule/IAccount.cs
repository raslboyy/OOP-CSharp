namespace Banks.Entities.AccountModule
{
    public interface IAccount
    {
        double Balance { get; }
        double PercentagesValue { get; }
        int Age { get; }
        int Id { get; }
        bool TopUp(double value);
        bool Withdraw(double value);
        TransferResult TransferTo(int accountId, double value);
        void CancelTransfer(int transferId);
    }
}