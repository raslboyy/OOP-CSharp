namespace Banks.UI.Commands
{
    public abstract class ACommand
    {
        private readonly bool _isTerminatingCommand;

        protected ACommand(bool commandIsTerminating, IUserInterface userInterface)
        {
            _isTerminatingCommand = commandIsTerminating;
            Interface = userInterface;
        }

        protected IUserInterface Interface { get; }

        public (bool wasSuccessful, bool shouldQuit) RunCommand()
        {
            if (this is not IParameterisedCommand parameterisedCommand)
                return (InternalCommand(), _isTerminatingCommand);

            bool allParametersCompleted = false;
            while (allParametersCompleted == false)
            {
                allParametersCompleted = parameterisedCommand.GetParameters();
            }

            return (InternalCommand(), _isTerminatingCommand);
        }

        protected abstract bool InternalCommand();

        protected string GetParameter(string parameterName)
        {
            return Interface.ReadValue($"Enter {parameterName}:");
        }
    }
}