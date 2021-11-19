namespace Banks.Entities.ClientModule.ClientBuilderModule
{
    public class ClientFirstNameBuilder<T> : ClientBuilder
        where T : ClientFirstNameBuilder<T>
    {
        public T SetFirstName(string name)
        {
            Client.FirstName = name;
            return (T)this;
        }
    }
}