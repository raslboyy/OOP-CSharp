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
            Interface.WriteMessage("/help\n" +
                                   "/add-bank\n" +
                                   "/add-client\n" +
                                   "/banks\n" +
                                   "/clients\n" +
                                   "/quit");
            return true;
        }
    }
}