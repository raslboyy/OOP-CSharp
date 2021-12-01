namespace Banks.Entities.ClientModule.ClientBuilderModule
{
    public class ClientLastNameBuilder<T> : ClientFirstNameBuilder<T>
        where T : ClientLastNameBuilder<T>
    {
        public T SetLastName(string lastName)
        {
            Client.LastName = lastName;
            return (T)this;
        }
    }
}