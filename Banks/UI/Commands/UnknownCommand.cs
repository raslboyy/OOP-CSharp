namespace Banks.UI.Commands
{
    public class UnknownCommand : ANonTerminatingCommand
    {
        public UnknownCommand(IUserInterface userInterface)
            : base(userInterface)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteWarning("Unable to determine the desired command.");
            return false;
        }
    }
}