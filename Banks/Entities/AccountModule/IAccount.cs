namespace Banks.Entities.AccountModule
{
    public interface IAccount
    {
        double Balance { get; }
        int Age { get; }
        bool TopUp(double value);
        bool Withdraw(double value);

        // bool Transfer(int accountId, double value);
    }
}