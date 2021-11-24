using Banks.Entities.BankModule;

namespace Banks.UI.Commands
{
    public class BanksCommand : ANonTerminatingCommand
    {
        public BanksCommand(IUserInterface userInterface)
            : base(userInterface)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage(CentralBank.GetBanks());
            return true;
        }
    }
}