using Banks.UI.Commands;

namespace Banks.UI.Services
{
    public class BanksService : IBankService
    {
        private readonly IUserInterface _userInterface;

        public BanksService(IUserInterface userInterface) => _userInterface = userInterface;

        public void Run()
        {
            (bool wasSuccessful, bool shouldQuit) response = GetCommand("?").RunCommand();

            while (!response.shouldQuit)
            {
                string input = _userInterface.ReadValue("> ").ToLower();
                ACommand command = GetCommand(input);

                response = command.RunCommand();

                if (!response.wasSuccessful)
                {
                    _userInterface.WriteMessage("Enter ? to view options.");
                }
            }
        }

        private ACommand GetCommand(string input)
        {
            switch (input)
            {
                case "q":
                case "quit":
                    return new QuitCommand(_userInterface);
                case "?":
                    return new HelpCommand(_userInterface);
                case "add bank":
                    return new AddBankCommand(_userInterface);
                default:
                    return new UnknownCommand(_userInterface);
            }
        }
    }
}