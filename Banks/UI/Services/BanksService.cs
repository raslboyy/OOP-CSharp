using Banks.UI.Commands;

namespace Banks.UI.Services
{
    public class BanksService : IBankService
    {
        private readonly IUserInterface _userInterface;

        public BanksService(IUserInterface userInterface) => _userInterface = userInterface;

        public void Run()
        {
            (bool wasSuccessful, bool shouldQuit) response = GetCommand("/help").RunCommand();

            while (!response.shouldQuit)
            {
                string input = _userInterface.ReadValue("> ").ToLower();
                ACommand command = GetCommand(input);

                response = command.RunCommand();

                if (!response.wasSuccessful)
                {
                    _userInterface.WriteMessage("Enter /help to view options.");
                }
            }
        }

        private ACommand GetCommand(string input)
        {
            return input switch
            {
                "/quit" => new QuitCommand(_userInterface),
                "/add-bank" => new AddBankCommand(_userInterface),
                "/add-client" => new AddClientCommand(_userInterface),
                "/banks" => new BanksCommand(_userInterface),
                "/help" => new HelpCommand(_userInterface),
                _ => new UnknownCommand(_userInterface)
            };
        }
    }
}