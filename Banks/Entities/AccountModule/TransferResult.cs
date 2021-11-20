namespace Banks.Entities.AccountModule
{
    public readonly struct TransferResult
    {
        public TransferResult(bool isSuccessful, int idTransfer)
        {
            IsSuccessful = isSuccessful;
            IdTransfer = idTransfer;
        }

        public bool IsSuccessful { get; }
        public int IdTransfer { get; }
    }
}