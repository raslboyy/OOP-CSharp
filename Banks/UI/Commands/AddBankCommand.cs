using Banks.Entities.BankModule.BankConfigurationModule;

namespace Banks.UI.Commands
{
    public class AddBankCommand : ANonTerminatingCommand, IParameterisedCommand
    {
        public AddBankCommand(IUserInterface userInterface)
            : base(userInterface)
        {
        }

        private string BankName { get; set; }
        private BankConfiguration BankConfiguration { get; set; }

        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(BankName))
                BankName = GetParameter("name");
            if (string.IsNullOrWhiteSpace(BankName))
                return false;
            return !string.IsNullOrWhiteSpace(BankName);
        }

        protected override bool InternalCommand()
        {
            return true;
        }
    }
}