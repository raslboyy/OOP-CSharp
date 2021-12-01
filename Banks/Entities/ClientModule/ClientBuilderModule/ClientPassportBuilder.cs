namespace Banks.Entities.ClientModule.ClientBuilderModule
{
    public class ClientPassportBuilder<T> : ClientAddressBuilder<T>
        where T : ClientPassportBuilder<T>
    {
        public T SetPassport(string passport)
        {
            Client.Passport = passport;
            return (T)this;
        }
    }
}