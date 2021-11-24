using System;
using Banks.Entities.BankModule;
using Banks.Entities.ClientModule.ClientBuilderModule;

namespace Banks.UI.Commands
{
    public class AddClientCommand : ANonTerminatingCommand, IParameterisedCommand
    {
        public AddClientCommand(IUserInterface userInterface)
            : base(userInterface)
        {
        }

        private string Bank { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Passport { get; set; }
        private string Address { get; set; }
        private LastClientBuilder Builder { get; } = new ();

        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(Bank))
            {
                Bank = GetParameter("bank name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                FirstName = GetParameter("first name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                LastName = GetParameter("last name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Passport))
                Passport = GetParameter("passport");
            if (string.IsNullOrWhiteSpace(Address))
                Address = GetParameter("address");

            return true;
        }

        protected override bool InternalCommand()
        {
            try
            {
                Builder.SetFirstName(FirstName)
                    .SetLastName(LastName)
                    .SetAddress(Address)
                    .SetPassport(Passport);
                CentralBank.FindBank(Bank).AddClient(Builder);
            }
            catch (Exception exception)
            {
                Interface.WriteWarning(exception.Message);
            }

            return true;
        }
    }
}