namespace Banks.Entities.ClientModule.ClientBuilderModule
{
    public class ClientAddressBuilder<T> : ClientLastNameBuilder<T>
        where T : ClientAddressBuilder<T>
    {
        public T SetAddress(string address)
        {
            Client.Address = address;
            return (T)this;
        }
    }
}