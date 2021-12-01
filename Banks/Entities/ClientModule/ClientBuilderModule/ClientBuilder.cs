using Banks.Tools;

namespace Banks.Entities.ClientModule.ClientBuilderModule
{
    public class ClientBuilder
    {
        protected Client Client { get; } = new ();

        public Client GetResult()
        {
            if (Client.FirstName == null || Client.LastName == null)
                throw new ClientBuilderException("Not set FirstName and LastName.");
            if (Client.Address != null && Client.Passport != null)
                Client.IsGood = true;
            return Client;
        }
    }
}