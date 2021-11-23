namespace Banks.UI.Commands
{
    public class HelpCommand : ANonTerminatingCommand
    {
        public HelpCommand(IUserInterface userInterface)
            : base(userInterface)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("It's Help.");
            return true;
        }
    }
}