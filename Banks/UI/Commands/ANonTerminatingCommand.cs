namespace Banks.UI.Commands
{
    public abstract class ANonTerminatingCommand : ACommand
    {
        protected ANonTerminatingCommand(IUserInterface userInterface)
            : base(false, userInterface)
        {
        }
    }
}