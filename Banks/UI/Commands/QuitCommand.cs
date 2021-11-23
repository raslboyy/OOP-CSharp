namespace Banks.UI.Commands
{
    public class QuitCommand : ACommand
    {
        public QuitCommand(IUserInterface userInterface)
            : base(true, userInterface)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("Good Bye!");
            return true;
        }
    }
}