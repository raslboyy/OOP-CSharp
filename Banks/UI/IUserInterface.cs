namespace Banks.UI
{
    public interface IUserInterface
    {
        string ReadValue(string message);
        void WriteMessage(string message);
        void WriteWarning(string message);
    }
}